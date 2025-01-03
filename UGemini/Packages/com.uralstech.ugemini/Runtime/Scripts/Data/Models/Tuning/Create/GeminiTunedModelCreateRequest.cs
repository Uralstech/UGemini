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
    /// Creates a tuned model. Response type is <see cref="GeminiTunedModelCreateResponse"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiTunedModelCreateRequest : IGeminiPostRequest
    {
        /// <summary>
        /// The tuned model to be created.
        /// </summary>
        public GeminiTunedModelCreationData Model;

        /// <summary>
        /// The unique id for the tuned model if specified.
        /// </summary>
        /// <remarks>
        /// This value should be up to 40 characters, the first character must be a letter, the last could<br/>
        /// be a letter or a number.
        /// </remarks>
        public GeminiModelId ModelId = string.Empty;

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
            return !string.IsNullOrEmpty(ModelId)
                ? $"{GeminiManager.BaseServiceUri}/{ApiVersion}/tunedModels?tunedModelId={ModelId.BaseModelId}"
                : $"{GeminiManager.BaseServiceUri}/{ApiVersion}/tunedModels";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiTunedModelCreateRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="model">The tuned model to be created.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiTunedModelCreateRequest(GeminiTunedModelCreationData model, bool useBetaApi = true)
        {
            Model = model;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(Model);
        }
    }
}