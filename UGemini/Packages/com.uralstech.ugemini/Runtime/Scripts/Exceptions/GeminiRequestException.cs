// Copyright 2024 URAV ADVANCED LEARNING SYSTEMS PRIVATE LIMITED
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

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
