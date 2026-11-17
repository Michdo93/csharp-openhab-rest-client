// Generated from python-openhab-rest-client by tools/py2cs.py – do not edit.
#pragma warning disable CS1998, CS0168, CS0219, IDE0059
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenHABRestClient.Internal;

namespace OpenHABRestClient
{
    /// <summary>
    /// openHAB REST API: Transformations.
    /// </summary>
    public sealed class Transformations
    {
        readonly OpenHABClient _client;

        /// <summary>Creates the Transformations class for a connected client.</summary>
        public Transformations(OpenHABClient client) => _client = client;

        /// <summary>
        /// Get a list of all transformations.
        /// </summary>
        /// <returns>A list of transformations (JSON).</returns>
        public JsonNode? GetTransformations()
            => R.Finish(() => getTransformations_S(_client));

        /// <summary>Asynchronous <see cref="GetTransformations"/>.</summary>
        public Task<JsonNode?> GetTransformationsAsync(CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getTransformations_A(_client, cancellationToken));

        /// <summary>
        /// Get a single transformation.
        /// </summary>
        /// <param name="transformationUID">The transformationUID of the transformation to retrieve.</param>
        /// <returns>The transformation (JSON).</returns>
        public JsonNode? GetTransformation(string transformationUID)
            => R.Finish(() => getTransformation_S(_client, R.Arg(transformationUID)));

        /// <summary>Asynchronous <see cref="GetTransformation"/>.</summary>
        public Task<JsonNode?> GetTransformationAsync(string transformationUID,
                                                      CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getTransformation_A(_client, cancellationToken, R.Arg(transformationUID)));

        /// <summary>
        /// Update a single transformation.
        /// </summary>
        /// <param name="transformationUID">The transformationUID of the transformation to update.</param>
        /// <param name="transformationData">The new data for the transformation.</param>
        /// <returns>The response to the transformation update request (JSON).</returns>
        public JsonNode? UpdateTransformation(string transformationUID, object transformationData)
            => R.Finish(() => updateTransformation_S(_client, R.Arg(transformationUID), R.Arg(transformationData)));

        /// <summary>Asynchronous <see cref="UpdateTransformation"/>.</summary>
        public Task<JsonNode?> UpdateTransformationAsync(string transformationUID, object transformationData,
                                                         CancellationToken cancellationToken = default)
            => R.FinishAsync(() => updateTransformation_A(_client, cancellationToken, R.Arg(transformationUID), R.Arg(transformationData)));

        /// <summary>
        /// Delete a single transformation.
        /// </summary>
        /// <param name="transformationUID">The transformationUID of the transformation to delete.</param>
        /// <returns>The response to the transformation update request (JSON) or status/error message.</returns>
        public JsonNode? DeleteTransformation(string transformationUID)
            => R.Finish(() => deleteTransformation_S(_client, R.Arg(transformationUID)));

        /// <summary>Asynchronous <see cref="DeleteTransformation"/>.</summary>
        public Task<JsonNode?> DeleteTransformationAsync(string transformationUID,
                                                         CancellationToken cancellationToken = default)
            => R.FinishAsync(() => deleteTransformation_A(_client, cancellationToken, R.Arg(transformationUID)));

        /// <summary>
        /// Get all transformation services.
        /// </summary>
        /// <returns>A list of transformation services (JSON).</returns>
        public JsonNode? GetTransformationServices()
            => R.Finish(() => getTransformationServices_S(_client));

        /// <summary>Asynchronous <see cref="GetTransformationServices"/>.</summary>
        public Task<JsonNode?> GetTransformationServicesAsync(CancellationToken cancellationToken = default)
            => R.FinishAsync(() => getTransformationServices_A(_client, cancellationToken));

        static V getTransformations_S(OpenHABClient C)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.S("/transformations"), R.Dict(("Accept", R.S("application/json"))), V.None, V.None);
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

        static async Task<V> getTransformations_A(OpenHABClient C, CancellationToken ct)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.S("/transformations"), R.Dict(("Accept", R.S("application/json"))), V.None, V.None, ct).ConfigureAwait(false));
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

        static V getTransformation_S(OpenHABClient C, V v_transformationUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.Cat(R.S("/transformations/"), v_transformationUID), R.Dict(("Accept", R.S("application/json"))), V.None, V.None);
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
                    return R.Dict(("error", R.S("Not found.")));
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
                return R.Dict(("error", R.S("Not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> getTransformation_A(OpenHABClient C, CancellationToken ct, V v_transformationUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.Cat(R.S("/transformations/"), v_transformationUID), R.Dict(("Accept", R.S("application/json"))), V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Not found.")));
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
                return R.Dict(("error", R.S("Not found.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V updateTransformation_S(OpenHABClient C, V v_transformationUID, V v_transformationData)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "put", R.Cat(R.S("/transformations/"), v_transformationUID), R.Dict(("Content-Type", R.S("application/json"))), R.Dumps(v_transformationData), V.None);
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
                    return R.Dict(("error", R.S("Bad Request (content missing or invalid)")));
                }
                else if (R.Eq(v_status_code, R.I(405)))
                {
                    return R.Dict(("error", R.S("Transformation not editable.")));
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
                return R.Dict(("error", R.S("Bad Request (content missing or invalid)")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Transformation not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> updateTransformation_A(OpenHABClient C, CancellationToken ct,
                                                    V v_transformationUID, V v_transformationData)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "put", R.Cat(R.S("/transformations/"), v_transformationUID), R.Dict(("Content-Type", R.S("application/json"))), R.Dumps(v_transformationData), V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Bad Request (content missing or invalid)")));
                }
                else if (R.Eq(v_status_code, R.I(405)))
                {
                    return R.Dict(("error", R.S("Transformation not editable.")));
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
                return R.Dict(("error", R.S("Bad Request (content missing or invalid)")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Transformation not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V deleteTransformation_S(OpenHABClient C, V v_transformationUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "delete", R.Cat(R.S("/transformations/"), v_transformationUID), V.None, V.None, V.None);
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
                    return R.Dict(("error", R.S("Transformation not editable.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("UID not found.")));
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
                return R.Dict(("error", R.S("UID not found.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Transformation not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static async Task<V> deleteTransformation_A(OpenHABClient C, CancellationToken ct,
                                                    V v_transformationUID)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "delete", R.Cat(R.S("/transformations/"), v_transformationUID), V.None, V.None, V.None, ct).ConfigureAwait(false));
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
                    return R.Dict(("error", R.S("Transformation not editable.")));
                }
                else if (R.Eq(v_status_code, R.I(404)))
                {
                    return R.Dict(("error", R.S("UID not found.")));
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
                return R.Dict(("error", R.S("UID not found.")));
            }
            else if (R.Eq(v_status_code, R.I(405)))
            {
                return R.Dict(("error", R.S("Transformation not editable.")));
            }
            return R.Dict(("error", R.Cat(R.S("Unexpected response: "), v_status_code)));
        }

        static V getTransformationServices_S(OpenHABClient C)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = R.Http(C, "get", R.S("/transformations/services"), R.Dict(("Accept", R.S("application/json"))), V.None, V.None);
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

        static async Task<V> getTransformationServices_A(OpenHABClient C, CancellationToken ct)
        {
            V v_response = V.None;
            V v_status_code = V.None;
            try
            {
                v_response = (await R.HttpAsync(C, "get", R.S("/transformations/services"), R.Dict(("Accept", R.S("application/json"))), V.None, V.None, ct).ConfigureAwait(false));
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
