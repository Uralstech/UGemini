using System;
using UnityEngine.Networking;

namespace Uralstech.UGemini.Exceptions
{
    /// <summary>
    /// Thrown if a Gemini API request fails.
    /// </summary>
    public class GeminiRequestException : Exception
    {
        /// <summary>
        /// The endpoint of the failed request.
        /// </summary>
        public Uri RequestEndpoint;

        /// <summary>
        /// The response code returned by the request.
        /// </summary>
        public long RequestErrorCode;

        /// <summary>
        /// The name of the request's error.
        /// </summary>
        public string RequestError;

        /// <summary>
        /// The request's error message.
        /// </summary>
        public string RequestErrorMessage;

        /// <summary>
        /// Was the request on a beta API?
        /// </summary>
        public bool IsBetaApi;

        /// <summary>
        /// Creates a new <see cref="GeminiRequestException"/>.
        /// </summary>
        /// <param name="webRequest">The request that caused the exception.</param>
        internal GeminiRequestException(UnityWebRequest webRequest)
            : base($"Failed Gemini API request: " +
                  $"Request Endpoint: {webRequest.uri.AbsoluteUri} | " +
                  $"Request Error Code: {webRequest.responseCode} | " +
                  $"Request Error: {webRequest.error} | " +
                  $"Details:\n{webRequest.downloadHandler?.text}")
        {
            RequestEndpoint = webRequest.uri;

            RequestError = webRequest.error;
            RequestErrorCode = webRequest.responseCode;
            RequestErrorMessage = webRequest.downloadHandler?.text;

            IsBetaApi = RequestEndpoint.AbsolutePath.Contains("beta");
        }
    }
}
