using System;

namespace OpenHABRestClient
{
    /// <summary>Exception thrown when an openHAB REST request fails.</summary>
    public class OpenHABException : Exception
    {
        /// <summary>HTTP status code, or -1 if not applicable.</summary>
        public int StatusCode { get; }

        /// <inheritdoc/>
        public OpenHABException(string message, int statusCode = -1)
            : base(message) => StatusCode = statusCode;

        /// <inheritdoc/>
        public OpenHABException(string message, Exception inner)
            : base(message, inner) => StatusCode = -1;
    }
}
