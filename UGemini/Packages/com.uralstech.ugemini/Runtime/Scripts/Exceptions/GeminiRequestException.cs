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
        /// \deprecated Use <see cref="RequestEndPoint"/> as this property is only for the deprecated <see cref="GeminiManager.Compute{TRequest, TResponse}(TRequest, GeminiManager.RequestEndPoint, string, bool)"/> method.
        [Obsolete("Use GeminiRequestException.RequestEndpoint as this property is only for the deprecated GeminiManager.Compute method.")]
        public GeminiManager.RequestEndPoint RequestEndPoint;

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
        /// The request's API version as a string.
        /// </summary>
        /// \deprecated Use <see cref="IsBetaApi"/> as this property is only for the deprecated <see cref="GeminiManager.Compute{TRequest, TResponse}(TRequest, GeminiManager.RequestEndPoint, string, bool)"/> method.
        [Obsolete("Use GeminiRequestException.IsBetaApi as this property is only for the deprecated GeminiManager.Compute method.")]
        public string ApiVersionString;

        /// <summary>
        /// Was the request on a beta API?
        /// </summary>
        public bool IsBetaApi;

        [Obsolete]
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

        internal GeminiRequestException(UnityWebRequest webRequest)
            : base($"Failed Gemini request: " +
                  $"Request Endpoint: {webRequest.uri.AbsolutePath} | " +
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
