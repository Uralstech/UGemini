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


using Newtonsoft.Json;

namespace Uralstech.UGemini.Models.Caching
{
    /// <summary>
    /// Creates a <see cref="GeminiCachedContent"/> resource. Response type is <see cref="GeminiCachedContent"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiCachedContentCreateRequest : IGeminiPostRequest
    {
        /// <summary>
        /// The content to be cached.
        /// </summary>
        public GeminiCachedContentCreationData Content;

        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <inheritdoc/>
        public string ContentType => GeminiContentType.ApplicationJSON.MimeType();

        /// <inheritdoc/>
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.APIKey;

        /// <inheritdoc/>
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/cachedContents";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCachedContentCreateRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="content">The content to cache.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCachedContentCreateRequest(GeminiCachedContentCreationData content, bool useBetaApi = true)
        {
            Content = content;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(Content);
        }
    }
}