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

namespace Uralstech.UGemini.FileAPI
{
    /// <summary>
    /// Requests metadata for an existing file. Return type is <see cref="GeminiFile"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiFileGetRequest : IGeminiGetRequest
    {
        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <summary>
        /// The ID of the file to get.
        /// </summary>
        public string FileId;

        /// <inheritdoc/>
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.APIKey;

        /// <inheritdoc/>
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/files/{FileId}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiFileGetRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="fileNameOrId">The name (format 'files/{fileId}') or ID of the file to get.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiFileGetRequest(string fileNameOrId, bool useBetaApi = true)
        {
            FileId = fileNameOrId.Split('/')[^1];
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
