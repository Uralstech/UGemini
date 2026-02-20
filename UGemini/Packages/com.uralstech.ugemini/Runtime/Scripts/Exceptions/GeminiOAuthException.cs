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
