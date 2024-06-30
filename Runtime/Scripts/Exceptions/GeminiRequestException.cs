using System;
using UnityEngine.Networking;

namespace Uralstech.UGemini.Exceptions
{
    /// <summary>
    /// Thrown when a Gemini API request fails.
    /// </summary>
    public class GeminiRequestException : Exception
    {
        /// <summary>
        /// The endpoint of the failed request.
        /// </summary>
        public GeminiManager.RequestEndPoint RequestEndPoint;

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
        /// The request's API version as a string.
        /// </summary>
        public string ApiVersionString;

        /// <summary>
        /// Was the request on a beta API?
        /// </summary>
        public bool IsBetaApi;

        internal GeminiRequestException(GeminiManager.RequestEndPoint requestEndPoint, UnityWebRequest request, string apiVersion)
            : base($"Failed Gemini request: " +
                  $"Request API version: {apiVersion} | " +
                  $"Request Endpoint: {requestEndPoint} | " +
                  $"Request Error Code: {request.responseCode} | " +
                  $"Request Error: {request.error} | " +
                  $"Details:\n{request.downloadHandler.text}")
        {
            RequestEndPoint = requestEndPoint;

            RequestError = request.error;
            RequestErrorCode = request.responseCode;
            RequestErrorMessage = request.downloadHandler.text;
            
            ApiVersionString = apiVersion;
            IsBetaApi = apiVersion.Contains("beta");
        }
    }
}
