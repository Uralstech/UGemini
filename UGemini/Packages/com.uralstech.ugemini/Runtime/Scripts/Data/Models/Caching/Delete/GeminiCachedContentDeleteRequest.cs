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

namespace Uralstech.UGemini.Models.Caching
{
    /// <summary>
    /// Requests for deletion of a cached content resource.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiCachedContentDeleteRequest : IGeminiDeleteRequest
    {
        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <summary>
        /// The ID of the cached content.
        /// </summary>
        public string ContentId;

        /// <inheritdoc/>
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.APIKey;

        /// <inheritdoc/>
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/cachedContents/{ContentId}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCachedContentDeleteRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="cachedContentIdOrName">The ID or name (format cachedContents/{contentId}) of the cached content to delete.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCachedContentDeleteRequest(string cachedContentIdOrName, bool useBetaApi = true)
        {
            ContentId = cachedContentIdOrName.Split('/')[^1];
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
