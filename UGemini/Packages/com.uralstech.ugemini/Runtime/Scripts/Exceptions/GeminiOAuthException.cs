using System;
using UnityEngine.Networking;

namespace Uralstech.UGemini.Exceptions
{
    /// <summary>
    /// Thrown when an exception related to OAuth authentication is raised.
    /// </summary>
    public class GeminiOAuthException : Exception
    {
        /// <summary>
        /// The endpoint of the request.
        /// </summary>
        public Uri RequestEndpoint;

        /// <summary>
        /// Was the request on a beta API?
        /// </summary>
        public bool IsBetaApi;

        /// <summary>
        /// The reason for the exception.
        /// </summary>
        public string Reason;

        /// <summary>
        /// Creates a new <see cref="GeminiOAuthException"/>.
        /// </summary>
        /// <param name="webRequest">The request that caused the exception.</param>
        internal GeminiOAuthException(UnityWebRequest webRequest, string reason)
            : base($"Failed to authenticate Gemini API request: " +
                  $"Request Endpoint: {webRequest.uri.AbsoluteUri} | " +
                  $"Reason:\n{reason}")
        {
            RequestEndpoint = webRequest.uri;
            IsBetaApi = RequestEndpoint.AbsolutePath.Contains("beta");

            Reason = reason;
        }
    }
}
