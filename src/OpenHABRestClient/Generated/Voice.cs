// Generated from python-openhab-rest-client by tools/py2cs.py – do not edit.
#pragma warning disable CS1998, CS0168, CS0219, IDE0059
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// openHAB REST API: Voice.
    /// </summary>
    public sealed class Voice
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the Voice class for a connected client.</summary>
        public Voice(OpenHABClient client) => _client = client;

        /// <summary>
        /// Gets the default voice.
        /// </summary>
        /// <param name="language">(see the openHAB REST API documentation)</param>
        /// <returns>A dictionary with the details of the default voice.</returns>
        public JsonNode? GetDefaultVoice(string? language = null)
            => R.Finish(() => getDefaultVoice_S(_client, R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetDefaultVoice"/>.</summary>
        public Task<JsonNode?> GetDefaultVoiceAsync(string? language = null,
                                                    CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getDefaultVoice_A(_client, cancellationToken, R.Arg(language)));

        /// <summary>
        /// Start dialog processing for a given audio source.
        /// </summary>
        /// <param name="sourceID">The ID of the audio source.</param>
        /// <param name="ksID">The ID of the keyword spotter (optional).</param>
        /// <param name="sttID">The ID of the speech-to-text system (optional).</param>
        /// <param name="ttsID">The ID of the text-to-speech system (optional).</param>
        /// <param name="voiceID">The ID of the voice (optional).</param>
        /// <param name="hliIDs">A comma-separated list of interpreter IDs (optional).</param>
        /// <param name="sinkID">The ID of the audio output (optional).</param>
        /// <param name="keyword">The keyword used to start the dialog (optional).</param>
        /// <param name="listeningItem">The name of the item to listen to (optional).</param>
        /// <param name="language">The language for the request (optional).</param>
        /// <returns>The response from the server.</returns>
        public JsonNode? StartDialog(string sourceID, string? ksID = null, string? sttID = null,
                                     string? ttsID = null, string? voiceID = null, string? hliIDs = null,
                                     string? sinkID = null, string? keyword = null,
                                     string? listeningItem = null, string? language = null)
            => R.Finish(() => startDialog_S(_client, R.Arg(sourceID), R.Arg(ksID), R.Arg(sttID), R.Arg(ttsID), R.Arg(voiceID), R.Arg(hliIDs), R.Arg(sinkID), R.Arg(keyword), R.Arg(listeningItem), R.Arg(language)));

        /// <summary>Asynchronous <see cref="StartDialog"/>.</summary>
        public Task<JsonNode?> StartDialogAsync(string sourceID, string? ksID = null, string? sttID = null,
                                                string? ttsID = null, string? voiceID = null,
                                                string? hliIDs = null, string? sinkID = null,
                                                string? keyword = null, string? listeningItem = null,
                                                string? language = null,
                                                CancellationToken cancellationToken = default)
            => R.FinishAsync(() => startDialog_A(_client, cancellationToken, R.Arg(sourceID), R.Arg(ksID), R.Arg(sttID), R.Arg(ttsID), R.Arg(voiceID), R.Arg(hliIDs), R.Arg(sinkID), R.Arg(keyword), R.Arg(listeningItem), R.Arg(language)));

        /// <summary>
        /// Stop dialog processing for a given audio source.
        /// </summary>
        /// <param name="sourceID">The ID of the audio source.</param>
        /// <returns>The response from the server.</returns>
        public JsonNode? StopDialog(string sourceID)
            => R.Finish(() => stopDialog_S(_client, R.Arg(sourceID)));

        /// <summary>Asynchronous <see cref="StopDialog"/>.</summary>
        public Task<JsonNode?> StopDialogAsync(string sourceID, CancellationToken cancellationToken = default)
            => R.FinishAsync(() => stopDialog_A(_client, cancellationToken, R.Arg(sourceID)));

        /// <summary>
        /// Get the list of all interpreters.
        /// </summary>
        /// <param name="language">The language for the request (optional).</param>
        /// <returns>A list of interpreters if successful.</returns>
        public JsonNode? GetInterpreters(string? language = null)
            => R.Finish(() => getInterpreters_S(_client, R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetInterpreters"/>.</summary>
        public Task<JsonNode?> GetInterpretersAsync(string? language = null,
                                                    CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getInterpreters_A(_client, cancellationToken, R.Arg(language)));

        /// <summary>
        /// Sends a text to the default human language interpreter.
        /// </summary>
        /// <param name="text">The text to be interpreted.</param>
        /// <param name="language">The language of the text.</param>
        /// <returns>The response from the server.</returns>
        public JsonNode? InterpretText(string text, string? language = null)
            => R.Finish(() => interpretText_S(_client, R.Arg(text), R.Arg(language)));

        /// <summary>Asynchronous <see cref="InterpretText"/>.</summary>
        public Task<JsonNode?> InterpretTextAsync(string text, string? language = null,
                                                  CancellationToken cancellationToken = default)
            => R.FinishAsync(() => interpretText_A(_client, cancellationToken, R.Arg(text), R.Arg(language)));

        /// <summary>
        /// Gets a single interpreter.
        /// </summary>
        /// <param name="interpreterID">The ID of the interpreter.</param>
        /// <param name="language">The language for the request (optional).</param>
        /// <returns>The details of the interpreter.</returns>
        public JsonNode? GetInterpreter(string interpreterID, string? language = null)
            => R.Finish(() => getInterpreter_S(_client, R.Arg(interpreterID), R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetInterpreter"/>.</summary>
        public Task<JsonNode?> GetInterpreterAsync(string interpreterID, string? language = null,
                                                   CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getInterpreter_A(_client, cancellationToken, R.Arg(interpreterID), R.Arg(language)));

        /// <summary>
        /// Sends a text to a given human language interpreter(s).
        /// </summary>
        /// <param name="text">The text to be interpreted.</param>
        /// <param name="IDs">A list of interpreter IDs.</param>
        /// <param name="language">The language of the text.</param>
        /// <returns>The response from the server.</returns>
        public JsonNode? InterpretTextBatch(string text, object IDs, string? language = null)
            => R.Finish(() => interpretTextBatch_S(_client, R.Arg(text), R.Arg(IDs), R.Arg(language)));

        /// <summary>Asynchronous <see cref="InterpretTextBatch"/>.</summary>
        public Task<JsonNode?> InterpretTextBatchAsync(string text, object IDs, string? language = null,
                                                       CancellationToken cancellationToken = default)
            => R.FinishAsync(() => interpretTextBatch_A(_client, cancellationToken, R.Arg(text), R.Arg(IDs), R.Arg(language)));

        /// <summary>
        /// Executes a simple dialog sequence without keyword spotting for a given audio source.
        /// </summary>
        /// <param name="sourceID">The ID of the audio source.</param>
        /// <param name="sttID">The ID of the speech-to-text system.</param>
        /// <param name="ttsID">The ID of the text-to-speech system.</param>
        /// <param name="voiceID">The ID of the voice.</param>
        /// <param name="hliIDs">A list of interpreter IDs (optional).</param>
        /// <param name="sinkID">The ID of the audio output (optional).</param>
        /// <param name="listeningItem">The name of the item to listen to (optional).</param>
        /// <param name="language">The language for the request (optional).</param>
        /// <returns>The response from the server.</returns>
        public JsonNode? ListenAndAnswer(string sourceID, string sttID, string ttsID, string voiceID,
                                         object hliIDs, string sinkID, string listeningItem,
                                         string? language = null)
            => R.Finish(() => listenAndAnswer_S(_client, R.Arg(sourceID), R.Arg(sttID), R.Arg(ttsID), R.Arg(voiceID), R.Arg(hliIDs), R.Arg(sinkID), R.Arg(listeningItem), R.Arg(language)));

        /// <summary>Asynchronous <see cref="ListenAndAnswer"/>.</summary>
        public Task<JsonNode?> ListenAndAnswerAsync(string sourceID, string sttID, string ttsID,
                                                    string voiceID, object hliIDs, string sinkID,
                                                    string listeningItem, string? language = null,
                                                    CancellationToken cancellationToken = default)
            => R.FinishAsync(() => listenAndAnswer_A(_client, cancellationToken, R.Arg(sourceID), R.Arg(sttID), R.Arg(ttsID), R.Arg(voiceID), R.Arg(hliIDs), R.Arg(sinkID), R.Arg(listeningItem), R.Arg(language)));

        /// <summary>
        /// Speaks a given text with a given voice through the given audio sink.
        /// </summary>
        /// <param name="text">The text to be spoken.</param>
        /// <param name="voiceID">The ID of the voice.</param>
        /// <param name="sinkID">The ID of the audio output.</param>
        /// <param name="volume">The volume level (default: 100).</param>
        /// <returns>The response from the server.</returns>
        public JsonNode? SayText(string text, string voiceID, string sinkID, string volume = "100")
            => R.Finish(() => sayText_S(_client, R.Arg(text), R.Arg(voiceID), R.Arg(sinkID), R.Arg(volume)));

        /// <summary>Asynchronous <see cref="SayText"/>.</summary>
        public Task<JsonNode?> SayTextAsync(string text, string voiceID, string sinkID, string volume = "100",
                                            CancellationToken cancellationToken = default)
            => R.FinishAsync(() => sayText_A(_client, cancellationToken, R.Arg(text), R.Arg(voiceID), R.Arg(sinkID), R.Arg(volume)));

        /// <summary>
        /// Get the list of all voices.
        /// </summary>
        /// <param name="language">(see the openHAB REST API documentation)</param>
        /// <returns>A list of voices if successful.</returns>
        public JsonNode? GetVoices(string? language = null)
            => R.Finish(() => getVoices_S(_client, R.Arg(language)));

        /// <summary>Asynchronous <see cref="GetVoices"/>.</summary>
        public Task<JsonNode?> GetVoicesAsync(string? language = null,
                                              CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getVoices_A(_client, cancellationToken, R.Arg(language)));

        static V getDefaultVoice_S(OpenHABClient C, V v_language)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.S("/voice/defaultvoice"), R.Dict(("Accept", R.S("application/json")), ("Accept-Language", v_language)), V.None, V.None);
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("No default voice was found.")));
                }
                else
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("No default voice was found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getDefaultVoice_A(OpenHABClient C, CancellationToken ct, V v_language)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.S("/voice/defaultvoice"), R.Dict(("Accept", R.S("application/json")), ("Accept-Language", v_language)), V.None, V.None, ct).ConfigureAwait(false));
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("No default voice was found.")));
                }
                else
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("No default voice was found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V startDialog_S(OpenHABClient C, V v_sourceID, V v_ksID, V v_sttID, V v_ttsID, V v_voiceID,
                               V v_hliIDs, V v_sinkID, V v_keyword, V v_listeningItem, V v_language)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "post", R.S("/voice/dialog/start"), (R.Truthy(v_language) ? R.Dict(("Accept-Language", v_language)) : R.Dict()), V.None, R.Dict(("sourceId", v_sourceID), ("ksId", v_ksID), ("sttId", v_sttID), ("ttsId", v_ttsID), ("voiceId", v_voiceID), ("hliIds", v_hliIDs), ("sinkId", v_sinkID), ("keyword", v_keyword), ("listeningItem", v_listeningItem)));
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (R.Eq(v_status_code, R.I(400)))
                {
                    return R.Dict(("error", R.S("Services are missing or language is not supported by services or dialog processing is already started for the audio source.")));
                }
                else
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Services are missing or language is not supported by services or dialog processing is already started for the audio source.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> startDialog_A(OpenHABClient C, CancellationToken ct, V v_sourceID, V v_ksID,
                                           V v_sttID, V v_ttsID, V v_voiceID, V v_hliIDs, V v_sinkID,
                                           V v_keyword, V v_listeningItem, V v_language)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "post", R.S("/voice/dialog/start"), (R.Truthy(v_language) ? R.Dict(("Accept-Language", v_language)) : R.Dict()), V.None, R.Dict(("sourceId", v_sourceID), ("ksId", v_ksID), ("sttId", v_sttID), ("ttsId", v_ttsID), ("voiceId", v_voiceID), ("hliIds", v_hliIDs), ("sinkId", v_sinkID), ("keyword", v_keyword), ("listeningItem", v_listeningItem)), ct).ConfigureAwait(false));
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (R.Eq(v_status_code, R.I(400)))
                {
                    return R.Dict(("error", R.S("Services are missing or language is not supported by services or dialog processing is already started for the audio source.")));
                }
                else
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Services are missing or language is not supported by services or dialog processing is already started for the audio source.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V stopDialog_S(OpenHABClient C, V v_sourceID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "post", R.S("/voice/dialog/stop"), V.None, V.None, R.Dict(("sourceId", v_sourceID)));
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (R.Eq(v_status_code, R.I(405)))
                {
                    return R.Dict(("error", R.S("No dialog processing is started for the audio source.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("No audio source was found.")));
                }
                else
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("No audio source was found.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("No dialog processing is started for the audio source.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> stopDialog_A(OpenHABClient C, CancellationToken ct, V v_sourceID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "post", R.S("/voice/dialog/stop"), V.None, V.None, R.Dict(("sourceId", v_sourceID)), ct).ConfigureAwait(false));
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (R.Eq(v_status_code, R.I(405)))
                {
                    return R.Dict(("error", R.S("No dialog processing is started for the audio source.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("No audio source was found.")));
                }
                else
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("No audio source was found.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("No dialog processing is started for the audio source.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getInterpreters_S(OpenHABClient C, V v_language)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Accept", R.S("application/json")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = R.Http(C, "get", R.S("/voice/interpreters"), v_headers, V.None, V.None);
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (!R.Eq(v_status_code, R.I(200)))
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getInterpreters_A(OpenHABClient C, CancellationToken ct, V v_language)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Accept", R.S("application/json")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.S("/voice/interpreters"), v_headers, V.None, V.None, ct).ConfigureAwait(false));
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (!R.Eq(v_status_code, R.I(200)))
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V interpretText_S(OpenHABClient C, V v_text, V v_language)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Content-Type", R.S("text/plain")), ("Accept", R.S("text/plain")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = R.Http(C, "post", R.S("/voice/interpreters"), v_headers, v_text, V.None);
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (R.Eq(v_status_code, R.I(400)))
                {
                    return R.Dict(("error", R.Cat(R.S("Interpretation exception occurs: "), R.ExcStr(e_err))));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("No human language interpreter was found.")));
                }
                else
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("No human language interpreter was found.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Interpretation exception occurs.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> interpretText_A(OpenHABClient C, CancellationToken ct, V v_text, V v_language)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Content-Type", R.S("text/plain")), ("Accept", R.S("text/plain")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = (await R.HttpAsync(C, "post", R.S("/voice/interpreters"), v_headers, v_text, V.None, ct).ConfigureAwait(false));
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (R.Eq(v_status_code, R.I(400)))
                {
                    return R.Dict(("error", R.Cat(R.S("Interpretation exception occurs: "), R.ExcStr(e_err))));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("No human language interpreter was found.")));
                }
                else
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("No human language interpreter was found.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Interpretation exception occurs.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getInterpreter_S(OpenHABClient C, V v_interpreterID, V v_language)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Accept", R.S("application/json")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/voice/interpreters/"), v_interpreterID), v_headers, V.None, V.None);
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Interpreter not found.")));
                }
                else
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("Interpreter not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getInterpreter_A(OpenHABClient C, CancellationToken ct, V v_interpreterID,
                                              V v_language)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Accept", R.S("application/json")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/voice/interpreters/"), v_interpreterID), v_headers, V.None, V.None, ct).ConfigureAwait(false));
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("Interpreter not found.")));
                }
                else
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("Interpreter not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V interpretTextBatch_S(OpenHABClient C, V v_text, V v_IDs, V v_language)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Content-Type", R.S("text/plain")), ("Accept", R.S("text/plain")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = R.Http(C, "post", R.Cat(R.S("/voice/interpreters/"), R.Join(R.S(","), v_IDs)), v_headers, v_text, V.None);
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (R.Eq(v_status_code, R.I(400)))
                {
                    return R.Dict(("error", R.Cat(R.S("Interpretation exception occurs: "), R.ExcStr(e_err))));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("No human language interpreter was found.")));
                }
                else
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("No human language interpreter was found.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Interpretation exception occurs.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> interpretTextBatch_A(OpenHABClient C, CancellationToken ct, V v_text, V v_IDs,
                                                  V v_language)
        {
            V v_headers = V.None;
            V v_response = V.None;
            V v_status_code = V.None;
            v_headers = R.Dict(("Content-Type", R.S("text/plain")), ("Accept", R.S("text/plain")));
            if (R.Truthy(v_language))
            {
                R.Set(v_headers, R.S("Accept-Language"), v_language);
            }
            try
            {
                v_response = (await R.HttpAsync(C, "post", R.Cat(R.S("/voice/interpreters/"), R.Join(R.S(","), v_IDs)), v_headers, v_text, V.None, ct).ConfigureAwait(false));
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (R.Eq(v_status_code, R.I(400)))
                {
                    return R.Dict(("error", R.Cat(R.S("Interpretation exception occurs: "), R.ExcStr(e_err))));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("No human language interpreter was found.")));
                }
                else
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("No human language interpreter was found.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Interpretation exception occurs.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V listenAndAnswer_S(OpenHABClient C, V v_sourceID, V v_sttID, V v_ttsID, V v_voiceID,
                                   V v_hliIDs, V v_sinkID, V v_listeningItem, V v_language)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "post", R.S("/voice/listenandanswer"), (R.Truthy(v_language) ? R.Dict(("Accept-Language", v_language)) : R.Dict()), V.None, R.Dict(("sourceId", v_sourceID), ("sttId", v_sttID), ("ttsId", v_ttsID), ("voiceId", v_voiceID), ("hliIds", (R.Truthy(v_hliIDs) ? R.Join(R.S(","), v_hliIDs) : V.None)), ("sinkId", v_sinkID), ("listeningItem", v_listeningItem)));
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (R.Eq(v_status_code, R.I(400)))
                {
                    return R.Dict(("error", R.S("Services are missing or language is not supported by services or dialog processing is already started for the audio source.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("One of the given ids is wrong.")));
                }
                else
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("One of the given ids is wrong.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Services are missing or language is not supported by services or dialog processing is already started for the audio source.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> listenAndAnswer_A(OpenHABClient C, CancellationToken ct, V v_sourceID, V v_sttID,
                                               V v_ttsID, V v_voiceID, V v_hliIDs, V v_sinkID,
                                               V v_listeningItem, V v_language)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "post", R.S("/voice/listenandanswer"), (R.Truthy(v_language) ? R.Dict(("Accept-Language", v_language)) : R.Dict()), V.None, R.Dict(("sourceId", v_sourceID), ("sttId", v_sttID), ("ttsId", v_ttsID), ("voiceId", v_voiceID), ("hliIds", (R.Truthy(v_hliIDs) ? R.Join(R.S(","), v_hliIDs) : V.None)), ("sinkId", v_sinkID), ("listeningItem", v_listeningItem)), ct).ConfigureAwait(false));
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (R.Eq(v_status_code, R.I(400)))
                {
                    return R.Dict(("error", R.S("Services are missing or language is not supported by services or dialog processing is already started for the audio source.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("One of the given ids is wrong.")));
                }
                else
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            else if (R.Eq(v_status_code, R.I(404)))
            {
                return R.Dict(("error", R.S("One of the given ids is wrong.")));
            }
            else if (R.Eq(v_status_code, R.I(400)))
            {
                return R.Dict(("error", R.S("Services are missing or language is not supported by services or dialog processing is already started for the audio source.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V sayText_S(OpenHABClient C, V v_text, V v_voiceID, V v_sinkID, V v_volume)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "post", R.S("/voice/say"), R.Dict(("Content-Type", R.S("text/plain"))), v_text, R.Dict(("voiceid", v_voiceID), ("sinkid", v_sinkID), ("volume", v_volume)));
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (!R.Eq(v_status_code, R.I(200)))
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> sayText_A(OpenHABClient C, CancellationToken ct, V v_text, V v_voiceID,
                                       V v_sinkID, V v_volume)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "post", R.S("/voice/say"), R.Dict(("Content-Type", R.S("text/plain"))), v_text, R.Dict(("voiceid", v_voiceID), ("sinkid", v_sinkID), ("volume", v_volume)), ct).ConfigureAwait(false));
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (!R.Eq(v_status_code, R.I(200)))
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getVoices_S(OpenHABClient C, V v_language)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.S("/voice/voices"), R.Dict(("Accept", R.S("application/json")), ("Accept-Language", v_language)), V.None, V.None);
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (!R.Eq(v_status_code, R.I(200)))
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getVoices_A(OpenHABClient C, CancellationToken ct, V v_language)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.S("/voice/voices"), R.Dict(("Accept", R.S("application/json")), ("Accept-Language", v_language)), V.None, V.None, ct).ConfigureAwait(false));
                if (R.IsStatus(v_response))
                {
                    v_status_code = R.Get(v_response, R.S("status"));
                }
                else
                {
                    return v_response;
                }
            }
            catch (HttpError e_err)
            {
                v_status_code = R.ExcStatus(e_err);
                if (!R.Eq(v_status_code, R.I(200)))
                {
                    return R.Dict(("error", R.Cat(R.S("HTTP error "), v_status_code, R.S(": "), R.ExcStr(e_err))));
                }
            }
            catch (RequestException e_err)
            {
                return R.Dict(("error", R.Cat(R.S("Request error: "), R.ExcStr(e_err))));
            }
            if (R.Eq(v_status_code, R.I(200)))
            {
                return R.Dict(("message", R.S("OK")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }
    }
}
