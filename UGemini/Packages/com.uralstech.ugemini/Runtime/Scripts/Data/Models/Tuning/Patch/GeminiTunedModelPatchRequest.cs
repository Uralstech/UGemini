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

namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// Updates a tuned model. Response type is <see cref="GeminiTunedModelPatchData"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiTunedModelPatchRequest : IGeminiPatchRequest
    {
        /// <summary>
        /// The patch data.
        /// </summary>
        public GeminiTunedModelPatchData Patch;

        /// <summary>
        /// The ID of the tuned model.
        /// </summary>
        public GeminiModelId TunedModel;

        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <inheritdoc/>
        public string ContentType => GeminiContentType.ApplicationJSON.MimeType();

        /// <inheritdoc/>
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.OAuthAccessToken;

        /// <inheritdoc/>
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/{TunedModel.Name}?updateMask={Patch.GetFieldMask()}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiTunedModelPatchRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="patch">The patch data.</param>
        /// <param name="tunedModel">The ID of the tuned model to patch.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiTunedModelPatchRequest(GeminiTunedModelPatchData patch, GeminiModelId tunedModel, bool useBetaApi = true)
        {
            Patch = patch;
            TunedModel = tunedModel;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(Patch);
        }
    }
}