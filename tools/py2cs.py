"""
Generates the REST classes of csharp-openhab-rest-client from python-openhab-rest-client.

The Python library is the reference: every method of a REST class is translated
statement by statement (same endpoint, headers, query parameters, body, status
handling and messages) – once synchronously and once with async/await. Python values
become V (a JsonNode plus the StatusResponse marker) handled by the runtime in
src/OpenHABRestClient/Internal/Py.cs; try/except becomes try/catch. Only a small,
regular subset of Python is supported; anything else raises an error so that nothing
is translated silently wrong.

Naming: Python class Items -> OpenHABRestClient.Items, method getItems -> Items.GetItems
and Items.GetItemsAsync. Parameters keep the Python names, order and defaults
(None -> null); use C# named arguments for the optional ones:

    JsonNode? r = items.GetItems(tags: "Light", fields: "name,state");
    JsonNode? r = await items.GetItemsAsync(tags: "Light", cancellationToken: ct);

Usage: python3 py2cs.py <path to python-openhab-rest-client/openhab> <repository root>
       python3 py2cs.py --readme <path>     (method tables for README.md)
"""
import ast
import glob
import json
import os
import sys

SKIP_FILES = ("Async", "__", "Client", "SSE")
CS_KEYWORDS = {"abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char",
               "checked", "class", "const", "continue", "decimal", "default", "delegate", "do",
               "double", "else", "enum", "event", "explicit", "extern", "false", "finally",
               "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int",
               "interface", "internal", "is", "lock", "long", "namespace", "new", "null",
               "object", "operator", "out", "override", "params", "private", "protected",
               "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof",
               "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true",
               "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using",
               "virtual", "void", "volatile", "while"}

NAME_TYPES = {"language": "str", "prefix": "str", "typeFilter": "str", "moduleTypeUID": "str",
              "channelTypeUID": "str", "itemType": "str", "tags": "str",
              "summary": "bool", "staticDataOnly": "bool"}


def csname(n):
    """C# name of a parameter (keywords get an @)."""
    return "@" + n if n in CS_KEYWORDS else n


def pascal(n):
    return n[0].upper() + n[1:]


class Unsupported(Exception):
    pass


def cstr(s):
    return json.dumps(s, ensure_ascii=False)


def ptype(arg, default):
    """Python type of a parameter: str, bool, int, float, json."""
    if arg.annotation is not None:
        a = ast.unparse(arg.annotation)
        t = {"str": "str", "bool": "bool", "int": "int", "float": "float",
             "dict": "json", "list": "json"}.get(a)
        if not t:
            raise Unsupported(f"annotation {a}")
        return t
    if arg.arg in NAME_TYPES:
        return NAME_TYPES[arg.arg]
    if isinstance(default, ast.Constant):
        v = default.value
        if isinstance(v, bool):
            return "bool"
        if isinstance(v, str):
            return "str"
        if isinstance(v, int):
            return "int"
        if isinstance(v, float):
            return "float"
    return "json"


class Method:
    def __init__(self, cls, fn):
        self.cls, self.fn, self.name = cls, fn, fn.name
        a = fn.args
        args = a.args[1:]
        defaults = [None] * (len(args) - len(a.defaults)) + list(a.defaults)
        self.params = []   # (name, type, default node or None, required)
        for arg, d in zip(args, defaults):
            self.params.append((arg.arg, ptype(arg, d), d, d is None))
        self.private = fn.name.startswith("_")
        self.stream = False

    def impl(self, asyn):
        return f"{self.name.lstrip('_')}_" + ("A" if asyn else "S")

    @property
    def pub(self):
        return pascal(self.name)

    @property
    def required(self):
        return [p for p in self.params if p[3]]

    @property
    def optional(self):
        return [p for p in self.params if not p[3]]


def always_returns(stmts):
    for s in stmts:
        if isinstance(s, (ast.Return, ast.Raise)):
            return True
        if isinstance(s, ast.If) and s.orelse and always_returns(s.body) and always_returns(s.orelse):
            return True
        if isinstance(s, ast.Try) and always_returns(s.body) and \
                all(always_returns(h.body) for h in s.handlers):
            return True
    return False


class Translator:
    def __init__(self, method, methods, asyn):
        self.m, self.methods, self.asyn = method, methods, asyn
        self.where = f"{method.cls}.{method.name}"
        self.errname = None     # name of the exception variable in an except block
        self.tmp = 0

    def fail(self, what):
        raise Unsupported(f"{self.where}: {what}")

    def aw(self, call):
        return f"(await {call}.ConfigureAwait(false))" if self.asyn else call

    def cond(self, n):
        code, kind = self.expr(n)
        return code if kind == "bool" else f"R.Truthy({code})"

    def obj(self, n):
        code, kind = self.expr(n)
        if kind == "bool":
            return f"R.Bool({code})"
        if kind == "stream":
            self.fail("stream used as value")
        return code

    def expr(self, n):
        m = getattr(self, "e_" + type(n).__name__, None)
        if not m:
            self.fail(f"expression {ast.unparse(n)}")
        return m(n)

    def e_Constant(self, n):
        v = n.value
        if v is None:
            return "V.None", "obj"
        if v is True or v is False:
            return f"R.B({'true' if v else 'false'})", "obj"
        if isinstance(v, str):
            return f"R.S({cstr(v)})", "obj"
        if isinstance(v, int):
            return f"R.I({v})", "obj"
        if isinstance(v, float):
            return f"R.D({v!r})", "obj"
        self.fail(f"constant {v!r}")

    def e_Name(self, n):
        if n.id == self.errname:
            self.fail("exception object used as value")
        return f"v_{n.id}", "obj"

    def e_JoinedStr(self, n):
        parts = []
        for v in n.values:
            if isinstance(v, ast.Constant):
                parts.append(f"R.S({cstr(v.value)})")
            elif isinstance(v, ast.FormattedValue):
                if v.format_spec is not None or v.conversion != -1:
                    self.fail("format spec")
                parts.append(self.strarg(v.value))
        return f"R.Cat({', '.join(parts)})", "obj"

    def strarg(self, n):
        """str(x) inside an f-string – handles str(err)."""
        if isinstance(n, ast.Name) and n.id == self.errname:
            return "R.ExcStr(e_err)"
        if isinstance(n, ast.Call) and isinstance(n.func, ast.Name) and n.func.id == "str" \
                and isinstance(n.args[0], ast.Name) and n.args[0].id == self.errname:
            return "R.ExcStr(e_err)"
        return self.obj(n)

    def e_Dict(self, n):
        if not n.keys:
            return "R.Dict()", "obj"
        parts = []
        for k, v in zip(n.keys, n.values):
            if not (isinstance(k, ast.Constant) and isinstance(k.value, (str, int))):
                self.fail(f"dict key {ast.unparse(k) if k else '**'}")
            parts.append(f"({cstr(str(k.value))}, {self.obj(v)})")
        return f"R.Dict({', '.join(parts)})", "obj"

    def e_List(self, n):
        if not n.elts:
            return "R.List()", "obj"
        return f"R.List({', '.join(self.obj(e) for e in n.elts)})", "obj"

    e_Tuple = e_List

    def e_Subscript(self, n):
        if isinstance(n.slice, ast.Slice):
            self.fail("slice")
        return f"R.Get({self.obj(n.value)}, {self.obj(n.slice)})", "obj"

    def e_Attribute(self, n):
        src = ast.unparse(n)
        if self.errname and src == f"{self.errname}.response.status_code":
            return "R.ExcStatus(e_err)", "obj"
        self.fail(f"attribute {src}")

    def e_BoolOp(self, n):
        # short-circuit like Python: the right side is only evaluated if needed
        vals = [self.obj(v) for v in n.values]
        out = vals[-1]
        for v in reversed(vals[:-1]):
            self.tmp += 1
            t = f"t_{self.tmp}"
            if isinstance(n.op, ast.And):
                out = f"({v} is var {t} ? (R.Truthy({t}) ? {out} : {t}) : V.None)"
            else:
                out = f"({v} is var {t} ? (R.Truthy({t}) ? {t} : {out}) : V.None)"
        return out, "obj"

    def e_UnaryOp(self, n):
        if isinstance(n.op, ast.Not):
            return f"!{self.cond(n.operand)}", "bool"
        if isinstance(n.op, ast.USub) and isinstance(n.operand, ast.Constant):
            v = n.operand.value
            return (f"R.I(-{v})" if isinstance(v, int) else f"R.D(-{v!r})"), "obj"
        self.fail(ast.unparse(n))

    def e_IfExp(self, n):
        return f"({self.cond(n.test)} ? {self.obj(n.body)} : {self.obj(n.orelse)})", "obj"

    def e_Compare(self, n):
        if len(n.ops) != 1:
            self.fail(ast.unparse(n))
        op, L, Rr = n.ops[0], n.left, n.comparators[0]
        none_r = isinstance(Rr, ast.Constant) and Rr.value is None
        if isinstance(op, (ast.Is, ast.IsNot)):
            if not none_r:
                self.fail("'is' with something else than None")
            code = f"R.IsNone({self.obj(L)})"
            return (code if isinstance(op, ast.Is) else f"!{code}"), "bool"
        lc, rc = self.obj(L), self.obj(Rr)
        if isinstance(op, ast.Eq):
            return f"R.Eq({lc}, {rc})", "bool"
        if isinstance(op, ast.NotEq):
            return f"!R.Eq({lc}, {rc})", "bool"
        if isinstance(op, ast.In):
            return f"R.Contains({rc}, {lc})", "bool"
        if isinstance(op, ast.NotIn):
            return f"!R.Contains({rc}, {lc})", "bool"
        sym = {ast.Lt: "<", ast.Gt: ">", ast.LtE: "<=", ast.GtE: ">="}[type(op)]
        return f"(R.Cmp({lc}, {rc}) {sym} 0)", "bool"

    def e_DictComp(self, n):
        gen = n.generators[0]
        if (len(n.generators) == 1 and ast.unparse(gen.iter).endswith(".items()")
                and len(gen.ifs) == 1 and ast.unparse(n.key) == ast.unparse(gen.target.elts[0])
                and ast.unparse(n.value) == ast.unparse(gen.target.elts[1])
                and ast.unparse(gen.ifs[0]) == f"{gen.target.elts[1].id} is not None"):
            return f"R.WithoutNone({self.obj(gen.iter.func.value)})", "obj"
        self.fail(f"dict comprehension {ast.unparse(n)}")

    @staticmethod
    def kwargs(n):
        return {k.arg: k.value for k in n.keywords}

    def call_args(self, names, n):
        vals = [None] * len(names)
        for i, a in enumerate(n.args):
            vals[i] = a
        for k in n.keywords:
            if k.arg not in names:
                self.fail(f"keyword {k.arg}")
            vals[names.index(k.arg)] = k.value
        return vals

    def default_value(self, node):
        if node is None:
            return "V.None"
        return self.obj(node)

    def e_Call(self, n):
        f = n.func
        src = ast.unparse(f)
        kw = self.kwargs(n)
        a_ct = ", ct" if self.asyn else ""
        sfx = "Async" if self.asyn else ""
        if src.startswith("self.client.") or src == "client.executeSSE":
            verb = f.attr
            path = n.args[0] if n.args else kw.pop("endpoint", None) or kw.pop("url")
            h = self.obj(kw["headers"]) if "headers" in kw else "V.None"
            prm = self.obj(kw["params"]) if "params" in kw else "V.None"
            data = self.obj(kw["data"]) if "data" in kw else "V.None"
            if verb in ("get", "post", "put", "delete"):
                return self.aw(f'R.Http{sfx}(C, "{verb}", {self.obj(path)}, {h}, {data}, {prm}{a_ct})'), "obj"
            if verb == "executeSSE":
                return self.aw(f"R.Sse{sfx}(C, {self.obj(path)}, {h}, {prm}{a_ct})"), "stream"
            self.fail(f"client.{verb}")
        if isinstance(f, ast.Attribute) and isinstance(f.value, ast.Name) and f.value.id == "self":
            target = self.methods.get(f.attr)
            if target is None:
                self.fail(f"unknown method self.{f.attr}")
            vals = self.call_args([p[0] for p in target.params], n)
            args = ["C"] + (["ct"] if self.asyn else [])
            for (pname, t, d, req), v in zip(target.params, vals):
                if v is None:
                    if req:
                        self.fail(f"missing argument {pname}")
                    args.append(self.default_value(d))
                else:
                    args.append(self.obj(v))
            return self.aw(f"{target.impl(self.asyn)}({', '.join(args)})"), \
                "stream" if target.stream else "obj"
        if isinstance(f, ast.Name):
            name = f.id
            if name == "str":
                a0 = n.args[0]
                if isinstance(a0, ast.Name) and a0.id == self.errname:
                    return "R.ExcStr(e_err)", "obj"
                return f"R.Str({self.obj(a0)})", "obj"
            if name == "isinstance":
                t = ast.unparse(n.args[1])
                fn = {"StatusResponse": "R.IsStatus", "dict": "R.IsDict", "list": "R.IsList",
                      "(list, tuple)": "R.IsList", "str": "R.IsStr", "bool": "R.IsBool"}.get(t)
                if not fn:
                    self.fail(f"isinstance {t}")
                return f"{fn}({self.obj(n.args[0])})", "bool"
            if name == "quote":
                safe = kw.get("safe")
                s = safe.value if isinstance(safe, ast.Constant) else "/"
                return f"R.Quote({self.obj(n.args[0])}, {cstr(s)})", "obj"
            if name == "urlencode":
                return f"R.UrlEncode({self.obj(n.args[0])})", "obj"
            if name == "dict":
                return f"R.Copy({self.obj(n.args[0])})", "obj"
            if name == "len":
                return f"R.Len({self.obj(n.args[0])})", "obj"
            if name == "_openStream":
                names = ["client", "topics", "path", "headers", "errors"]
                vals = self.call_args(names, n)
                a = [self.obj(v) if v is not None else "V.None" for v in vals[1:]]
                return self.aw(f"R.OpenStream{sfx}(C, {', '.join(a)}{a_ct})"), "stream"
            self.fail(f"call {name}")
        if isinstance(f, ast.Attribute):
            a = f.attr
            vsrc = ast.unparse(f.value)
            if vsrc == "json" and a == "dumps":
                return f"R.Dumps({self.obj(n.args[0])})", "obj"
            if vsrc == "urllib.parse" and a == "quote":
                safe = kw.get("safe")
                s = safe.value if isinstance(safe, ast.Constant) else "/"
                return f"R.Quote({self.obj(n.args[0])}, {cstr(s)})", "obj"
            obj = self.obj(f.value)
            args = [self.obj(x) for x in n.args]
            if a == "get":
                return f"R.GetOr({obj}, {', '.join(args)})", "obj"
            if a == "lower":
                return f"R.Lower({obj})", "obj"
            if a == "strip" and not args:
                return f"R.Strip({obj})", "obj"
            if a == "rstrip":
                return f"R.RStrip({obj}, {args[0]})", "obj"
            if a == "split":
                return f"R.Split({obj}, {args[0]})", "obj"
            if a == "join":
                return f"R.Join({obj}, {args[0]})", "obj"
        self.fail(f"call {ast.unparse(n)}")

    # ------------------------------------------------------------------ statements
    def block(self, stmts, ind):
        out = []
        for s in stmts:
            out += self.stmt(s, ind)
            if always_returns([s]):
                break
        return out

    def ret(self, value, p):
        stream = self.m.stream
        wrap = "R.AsStream" if stream else ""
        if value is None:
            return [f"{p}return {wrap}(V.None);"] if stream else [f"{p}return V.None;"]
        code, kind = self.expr(value)
        if kind == "bool":
            code, kind = f"R.Bool({code})", "obj"
        if stream and kind != "stream":
            return [f"{p}return R.AsStream({code});"]
        if not stream and kind == "stream":
            self.fail("stream returned from a normal method")
        return [f"{p}return {code};"]

    def stmt(self, s, ind):
        p = "    " * ind
        if isinstance(s, ast.Expr) and isinstance(s.value, ast.Constant):
            return []
        if isinstance(s, ast.Expr) and isinstance(s.value, ast.Call):
            code, kind = self.expr(s.value)
            return [f"{p}_ = {code};"]
        if isinstance(s, ast.Return):
            return self.ret(s.value, p)
        if isinstance(s, ast.Assign):
            if len(s.targets) != 1:
                self.fail("multiple assignment")
            t = s.targets[0]
            if isinstance(t, ast.Name):
                return [f"{p}v_{t.id} = {self.obj(s.value)};"]
            if isinstance(t, ast.Subscript) and isinstance(t.value, ast.Name):
                return [f"{p}R.Set(v_{t.value.id}, {self.obj(t.slice)}, {self.obj(s.value)});"]
            self.fail(f"assignment to {ast.unparse(t)}")
        if isinstance(s, ast.If):
            out = [f"{p}if ({self.cond(s.test)})", p + "{"] + self.block(s.body, ind + 1)
            orelse = s.orelse
            while len(orelse) == 1 and isinstance(orelse[0], ast.If):
                e = orelse[0]
                out += [p + "}", f"{p}else if ({self.cond(e.test)})", p + "{"] + self.block(e.body, ind + 1)
                orelse = e.orelse
            if orelse:
                out += [p + "}", f"{p}else", p + "{"] + self.block(orelse, ind + 1)
            return out + [p + "}"]
        if isinstance(s, ast.Try):
            if s.orelse or s.finalbody:
                self.fail("try/else/finally")
            out = [f"{p}try", p + "{"] + self.block(s.body, ind + 1)
            for h in s.handlers:
                t = ast.unparse(h.type)
                if t.endswith("HTTPError"):
                    ctype = "HttpError"
                elif t.endswith("RequestException"):
                    ctype = "RequestException"
                else:
                    self.fail(f"except {t}")
                old = self.errname
                self.errname = h.name
                body = self.block(h.body, ind + 1)
                self.errname = old
                var = " e_err" if h.name and any("e_err" in l for l in body) else ""
                out += [p + "}", f"{p}catch ({ctype}{var})", p + "{"] + body
            return out + [p + "}"]
        if isinstance(s, ast.Pass):
            return []
        self.fail(f"statement {type(s).__name__}: {ast.unparse(s)[:80]}")


def returns_stream(fn, methods):
    for n in ast.walk(fn):
        if isinstance(n, ast.Return) and isinstance(n.value, ast.Call):
            src = ast.unparse(n.value.func)
            if src in ("_openStream", "self.client.executeSSE", "client.executeSSE"):
                return True
            if src.startswith("self.") and src[5:] in methods and methods[src[5:]].stream:
                return True
    return False


def xml(s):
    return s.replace("&", "&amp;").replace("<", "&lt;").replace(">", "&gt;")


def doc_comment(fn, names=None, ind="        "):
    """Python docstring as XML documentation: summary, params, returns."""
    doc = ast.get_docstring(fn) or ""
    summary, params, returns, cur = [], {}, [], None
    for raw in doc.splitlines():
        l = raw.strip()
        if l.startswith(":param "):
            name, _, text = l[7:].partition(":")
            params[name.strip()] = [text.strip()]
            cur = params[name.strip()]
        elif l.startswith(":return:") or l.startswith(":returns:"):
            returns = [l.split(":", 2)[2].strip()]
            cur = returns
        elif l.startswith(":"):
            cur = None
        elif cur is not None and l:
            cur.append(l)
        elif cur is None:
            summary.append(l)
    while summary and not summary[-1]:
        summary.pop()
    out = [f"{ind}/// <summary>"]
    out += [f"{ind}/// {xml(l)}".rstrip() for l in (summary or [fn.name])]
    out.append(f"{ind}/// </summary>")
    low = {k.lower(): v for k, v in params.items()}
    for name in names or []:
        text = low.get(name.lower(), ["(see the openHAB REST API documentation)"])
        out.append(f'{ind}/// <param name="{name}">{xml(" ".join(text))}</param>')
    if returns:
        out.append(f"{ind}/// <returns>{xml(' '.join(returns))}</returns>")
    return out


PUB_REQ = {"str": "string", "bool": "bool", "int": "int", "float": "double", "json": "object"}
PUB_OPT_NONE = {"str": "string?", "bool": "bool?", "int": "int?", "float": "double?", "json": "object?"}


def is_none_default(d):
    return d is None or (isinstance(d, ast.Constant) and d.value is None)


def default_cs(t, d, where):
    if is_none_default(d):
        return "null"
    if isinstance(d, ast.Constant):
        v = d.value
        if isinstance(v, bool):
            return "true" if v else "false"
        if isinstance(v, str):
            return cstr(v)
        if isinstance(v, (int, float)):
            return repr(v)
    if isinstance(d, (ast.Dict, ast.List)) and not (d.keys if isinstance(d, ast.Dict) else d.elts):
        return "null"
    raise Unsupported(f"{where}: default {ast.unparse(d)}")


def param_type(t, d, req):
    if req:
        return PUB_REQ[t]
    if is_none_default(d) or t == "json":
        return PUB_OPT_NONE[t]
    return PUB_REQ[t]


def signature(m):
    where = f"{m.cls}.{m.name}"
    parts = [f"{PUB_REQ[t]} {csname(n)}" for n, t, d, r in m.required]
    for n, t, d, r in m.optional:
        parts.append(f"{param_type(t, d, False)} {csname(n)} = {default_cs(t, d, where)}")
    return parts


def arg_code(n, t, d, r):
    """Conversion of a public argument to V."""
    if t == "json" and not r and isinstance(d, ast.Dict):
        return f"R.ArgOr({csname(n)}, R.Dict())"
    if t == "json" and not r and isinstance(d, ast.List):
        return f"R.ArgOr({csname(n)}, R.List())"
    return f"R.Arg({csname(n)})"


def wrap(prefix, params, suffix, indent="        "):
    """Declaration wrapped at 110 columns, parameters aligned after the parenthesis."""
    one = f"{indent}{prefix}({', '.join(params)}){suffix}"
    if len(one) <= 110 or not params:
        return [one]
    pad = " " * (len(indent) + len(prefix) + 1)
    lines, cur = [], f"{indent}{prefix}("
    for i, p in enumerate(params):
        piece = p + ("," if i < len(params) - 1 else f"){suffix}")
        if cur.endswith("(") or len(cur) + 1 + len(piece) <= 110:
            cur += ("" if cur.endswith("(") else " ") + piece
        else:
            lines.append(cur)
            cur = pad + piece
    return lines + [cur]


def impl_code(m, methods, asyn):
    tr = Translator(m, methods, asyn)
    fn = m.fn
    assigned = {t.id for n in ast.walk(fn) if isinstance(n, ast.Assign)
                for t in n.targets if isinstance(t, ast.Name)}
    params = [p[0] for p in m.params]
    locals_ = sorted(assigned - set(params))
    if m.stream:
        rtype = "async Task<EventStream>" if asyn else "EventStream"
    else:
        rtype = "async Task<V>" if asyn else "V"
    sig = ["OpenHABClient C"] + (["CancellationToken ct"] if asyn else []) + [f"V v_{n}" for n in params]
    out = wrap(f"static {rtype} {m.impl(asyn)}", sig, "")
    out.append("        {")
    for v in locals_:
        out.append(f"            V v_{v} = V.None;")
    body = tr.block(fn.body, 3)
    out += body
    if not always_returns(fn.body):
        out.append("            return R.AsStream(V.None);" if m.stream else "            return V.None;")
    out.append("        }")
    if asyn and not any("await" in l for l in body):
        # nothing to wait for: keep the method synchronous internally
        out[0:len(wrap(f"static {rtype} {m.impl(asyn)}", sig, ""))] = \
            wrap(f"static {rtype.replace('async ', '')} {m.impl(asyn)}", sig, "")
        out = [l.replace("return R.AsStream(", "return R.AsStreamAsync(") if m.stream else
               l.replace("            return V.None;", "            return Task.FromResult(V.None);")
               for l in out]
        out = [fix_sync_return(l, m) for l in out]
    return out


def fix_sync_return(line, m):
    s = line.strip()
    if m.stream or not s.startswith("return ") or "Task.FromResult" in s:
        return line
    ind = line[:len(line) - len(line.lstrip())]
    return f"{ind}return Task.FromResult({s[7:-1]});"


def public_code(m):
    args = ["_client"] + [arg_code(*p) for p in m.params]
    sargs = ", ".join(args)
    aargs = ", ".join(["_client", "cancellationToken"] + args[1:])
    ret = "EventStream" if m.stream else "JsonNode?"
    sig = signature(m)
    out = doc_comment(m.fn, [p[0] for p in m.params])
    out += wrap(f"public {ret} {m.pub}", sig, "")
    fin = "R.FinishStream" if m.stream else "R.Finish"
    out.append(f"            => {fin}(() => {m.impl(False)}({sargs}));")
    out.append("")
    out.append(f"        /// <summary>Asynchronous <see cref=\"{m.pub}\"/>.</summary>")
    out += wrap(f"public Task<{ret}> {m.pub}Async", sig + ["CancellationToken cancellationToken = default"], "")
    out.append(f"            => {fin}Async(() => {m.impl(True)}({aargs}));")
    out.append("")
    return out


def load_classes(src):
    files = sorted(f for f in glob.glob(os.path.join(src, "*.py"))
                   if not os.path.basename(f).startswith(SKIP_FILES))
    result = []
    for f in files:
        tree = ast.parse(open(f, encoding="utf-8").read())
        for c in tree.body:
            if not isinstance(c, ast.ClassDef):
                continue
            fns = [fn for fn in c.body if isinstance(fn, ast.FunctionDef) and fn.name != "__init__"]
            methods = {fn.name: Method(c.name, fn) for fn in fns}
            for _ in range(3):
                for m in methods.values():
                    m.stream = returns_stream(m.fn, methods)
            result.append((os.path.basename(f), c, methods))
    return result


HEADER = """// Generated from python-openhab-rest-client by tools/py2cs.py – do not edit.
#pragma warning disable CS1998, CS0168, CS0219, IDE0059
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{"""


def generate(src, root):
    errors = []
    files = {}
    count = 0
    for fname, c, methods in load_classes(src):
        try:
            code = []
            cdoc = (ast.get_docstring(c) or f"openHAB REST API: {c.name}.").strip().splitlines()
            code.append("    /// <summary>")
            code += [f"    /// {xml(l.strip())}".rstrip() for l in cdoc]
            code.append("    /// </summary>")
            code.append(f"    public sealed class {c.name}")
            code.append("    {")
            code.append("        readonly OpenHABClient _client;")
            code.append("")
            code.append(f"        /// <summary>Creates the {c.name} class for a connected client.</summary>")
            code.append(f"        public {c.name}(OpenHABClient client) => _client = client;")
            code.append("")
            for m in methods.values():
                if not m.private:
                    code += public_code(m)
                    count += 1
            for m in methods.values():
                code += impl_code(m, methods, False) + [""]
                code += impl_code(m, methods, True) + [""]
            while code[-1] == "":
                code.pop()
            code.append("    }")
        except Unsupported as e:
            errors.append(str(e))
            continue
        base = fname[:-3]
        files.setdefault(base, []).append("\n".join(code))
    outdir = os.path.join(root, "src", "OpenHABRestClient", "Generated")
    os.makedirs(outdir, exist_ok=True)
    for f in glob.glob(os.path.join(outdir, "*.cs")):
        os.remove(f)
    for base, classes in files.items():
        with open(os.path.join(outdir, base + ".cs"), "w", encoding="utf-8") as fh:
            fh.write(HEADER + "\n" + "\n\n".join(classes) + "\n}\n")
    if errors:
        print("\n".join(errors), file=sys.stderr)
        sys.exit(1)
    print(f"{len(files)} files, {sum(len(v) for v in files.values())} classes, {count} methods")


def readme_tables(src):
    out = []
    for fname, c, methods in load_classes(src):
        out.append(f"### {c.name}\n")
        out.append("| Method | Required | Optional | Result |")
        out.append("|---|---|---|---|")
        for m in methods.values():
            if m.private:
                continue
            req = ", ".join(p[0] for p in m.required)
            opt = ", ".join(p[0] for p in m.optional)
            out.append(f"| `{m.pub}` / `{m.pub}Async` | {req} | {opt} | "
                       f"{'`EventStream`' if m.stream else '`JsonNode?`'} |")
        out.append("")
    return "\n".join(out)


def main():
    if sys.argv[1] == "--readme":
        print(readme_tables(sys.argv[2]))
        return
    generate(sys.argv[1], sys.argv[2])


if __name__ == "__main__":
    main()
