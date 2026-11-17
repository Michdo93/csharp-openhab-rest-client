using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace OpenHABRestClient
{
    /// <summary>
    /// Helpers for the results of the REST methods: errors are <c>{"error": "…"}</c>, empty
    /// successes <c>{"message": "OK"}</c> or <c>{"status": 200}</c>, everything else is the JSON
    /// that openHAB sends.
    /// <code>
    /// var r = items.GetItem("Wohnzimmer_Licht");
    /// if (r.IsError()) Console.WriteLine(r.ErrorMessage());
    /// else Console.WriteLine(r.Str("state"));
    /// </code>
    /// </summary>
    public static class OpenHABResults
    {
        /// <summary>True if the result is an error object <c>{"error": …}</c>.</summary>
        public static bool IsError(this JsonNode? result) =>
            result is JsonObject o && o.ContainsKey("error");

        /// <summary>The error message, or "" if the result is not an error.</summary>
        public static string ErrorMessage(this JsonNode? result)
        {
            if (result is not JsonObject o || !o.TryGetPropertyValue("error", out var e)) return "";
            if (e is JsonValue v && v.GetValueKind() == JsonValueKind.String) return v.GetValue<string>();
            if (e is JsonObject eo && eo.TryGetPropertyValue("message", out var m) && m is JsonValue mv &&
                mv.GetValueKind() == JsonValueKind.String) return mv.GetValue<string>();
            return "error";
        }

        /// <summary>
        /// The value at a dotted path such as <c>"payload.value"</c> or <c>"members.0.name"</c>,
        /// or null if it does not exist.
        /// </summary>
        public static JsonNode? At(this JsonNode? value, string path)
        {
            var cur = value;
            if (string.IsNullOrEmpty(path)) return cur;
            foreach (var part in path.Split('.'))
            {
                switch (cur)
                {
                    case JsonArray a:
                        if (!int.TryParse(part, NumberStyles.Integer, CultureInfo.InvariantCulture, out var i))
                            return null;
                        if (i < 0) i += a.Count;
                        if (i < 0 || i >= a.Count) return null;
                        cur = a[i];
                        break;
                    case JsonObject o:
                        if (!o.TryGetPropertyValue(part, out cur)) return null;
                        break;
                    default:
                        return null;
                }
            }
            return cur;
        }

        /// <summary>The string at <paramref name="path"/>, or <paramref name="fallback"/>.</summary>
        public static string Str(this JsonNode? value, string path = "", string fallback = "")
        {
            var x = value.At(path);
            return x is JsonValue v && v.GetValueKind() == JsonValueKind.String ? v.GetValue<string>() : fallback;
        }

        /// <summary>
        /// The number at <paramref name="path"/> – also from strings such as <c>"21.5 °C"</c> –,
        /// or <paramref name="fallback"/>.
        /// </summary>
        public static double Num(this JsonNode? value, string path = "", double fallback = double.NaN)
        {
            var x = value.At(path);
            if (x is not JsonValue v) return fallback;
            if (v.GetValueKind() == JsonValueKind.Number) return Internal.R.Dbl(v);
            if (v.GetValueKind() != JsonValueKind.String) return fallback;
            var s = v.GetValue<string>().TrimStart();
            var n = 0;
            while (n < s.Length && (char.IsDigit(s[n]) || "+-.eE".IndexOf(s[n]) >= 0)) n++;
            while (n > 0 && !double.TryParse(s.Substring(0, n), NumberStyles.Float, CultureInfo.InvariantCulture, out _)) n--;
            return n > 0 ? double.Parse(s.Substring(0, n), NumberStyles.Float, CultureInfo.InvariantCulture) : fallback;
        }

        /// <summary>The boolean at <paramref name="path"/>, or <paramref name="fallback"/>.</summary>
        public static bool Bool(this JsonNode? value, string path = "", bool fallback = false)
        {
            var x = value.At(path);
            if (x is JsonValue v)
            {
                if (v.GetValueKind() == JsonValueKind.True) return true;
                if (v.GetValueKind() == JsonValueKind.False) return false;
            }
            return fallback;
        }

        /// <summary>The elements of an array result (empty for errors and other values).</summary>
        public static JsonArray List(this JsonNode? value, string path = "") =>
            value.At(path) as JsonArray ?? new JsonArray();
    }
}
