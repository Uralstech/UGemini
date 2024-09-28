using System;
using UnityEngine.Networking;

namespace Uralstech.UGemini.Exceptions
{
    /// <summary>
    /// Thrown if the response of a Gemini API request could not be parsed.
    /// </summary>
    public class GeminiResponseParsingException : Exception
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
        /// The content downloaded from the request.
        /// </summary>
        public string DownloadedText;

        /// <summary>
        /// Creates a new <see cref="GeminiResponseParsingException"/>.
        /// </summary>
        /// <param name="webRequest">The request that caused the exception.</param>
        internal GeminiResponseParsingException(UnityWebRequest webRequest)
            : base($"Failed to parse Gemini API response: " +
                  $"Request Endpoint: {webRequest.uri.AbsoluteUri} | " +
                  $"Downloaded Text:\n{webRequest.downloadHandler?.text}")
        {
            RequestEndpoint = webRequest.uri;
            IsBetaApi = RequestEndpoint.AbsolutePath.Contains("beta");

            DownloadedText = webRequest.downloadHandler?.text;
        }

        /// <summary>
        /// Creates a new <see cref="GeminiResponseParsingException"/>.
        /// </summary>
        /// <param name="webRequest">The request that caused the exception.</param>
        /// <param name="innerException">The inner exception that caused this one.</param>
        internal GeminiResponseParsingException(UnityWebRequest webRequest, Exception innerException)
            : base($"Failed to parse Gemini API response: " +
                  $"Request Endpoint: {webRequest.uri.AbsoluteUri} | " +
                  $"Downloaded Text:\n{webRequest.downloadHandler?.text}", innerException)
        {
            RequestEndpoint = webRequest.uri;
            IsBetaApi = RequestEndpoint.AbsolutePath.Contains("beta");

            DownloadedText = webRequest.downloadHandler?.text;
        }
    }
}
