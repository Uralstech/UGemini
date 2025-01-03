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

namespace Uralstech.UGemini.Models
{
    /// <summary>
    /// Gets information about a specific model. Return type is <see cref="GeminiModel"/>.
    /// </summary>
    public class GeminiModelGetRequest : IGeminiGetRequest
    {
        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <summary>
        /// The ID of the <see cref="GeminiModel"/> to get.
        /// </summary>
        public GeminiModelId Model;

        /// <summary>
        /// The resource name of the model to get, in the format models/{model}.
        /// </summary>
        [Obsolete("This has been deprecated, please use GeminiModelGetRequest.Model instead.")]
        public string ModelName
        {
            get => Model.Name;
            set => Model = new GeminiModelId(value);
        }

        /// <inheritdoc/>
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.APIKey;

        /// <inheritdoc/>
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/{Model.Name}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiModelGetRequest"/>.
        /// </summary>
        /// <remarks>
        /// Some newer models do not work with this request unless through the Beta API.
        /// </remarks>
        /// <param name="modelId">The ID of the model to get.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiModelGetRequest(GeminiModelId modelId, bool useBetaApi = false)
        {
            Model = modelId;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
