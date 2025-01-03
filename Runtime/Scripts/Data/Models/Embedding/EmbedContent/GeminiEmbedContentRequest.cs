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
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using Uralstech.UGemini.JsonConverters;
using Uralstech.UGemini.Models.Content;

namespace Uralstech.UGemini.Models.Embedding
{
    /// <summary>
    /// Generates an embedding from the model.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiEmbedContentRequest : IGeminiPostRequest
    {
        /// <summary>
        /// The content to embed. Only the <see cref="GeminiContentPart.Text"/> fields will be counted.
        /// </summary>
        public GeminiContent Content;

        /// <summary>
        /// Optional task type for which the embeddings will be used.
        /// </summary>
        /// <remarks>
        /// Can only be set for "models/embedding-001" model.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(GeminiEmbedTaskType.Unspecified)]
        public GeminiEmbedTaskType TaskType = GeminiEmbedTaskType.Unspecified;

        /// <summary>
        /// An optional title for the text. Only applicable when <see cref="TaskType"/> is <see cref="GeminiEmbedTaskType.RetrievalDocument"/>.
        /// </summary>
        /// <remarks>
        /// Specifying a this for <see cref="GeminiEmbedTaskType.RetrievalDocument"/> provides better quality embeddings for retrieval.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string Title = null;

        /// <summary>
        /// Optional reduced dimension for the output embedding.
        /// </summary>
        /// <remarks>
        /// If set, excessive values in the output embedding are truncated from the end. Supported by<br/>
        /// newer models since 2024, and the earlier model (models/embedding-001) cannot specify this value.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(-1)]
        public int OutputDimensionality = -1;

        /// <summary>
        /// The model to use.
        /// </summary>
        [JsonConverter(typeof(GeminiModelIdToStringConverter))]
        public GeminiModelId Model;

        /// <summary>
        /// The API version to use.
        /// </summary>
        [JsonIgnore]
        public string ApiVersion;

        /// <inheritdoc/>
        [JsonIgnore]
        public string ContentType => GeminiContentType.ApplicationJSON.MimeType();

        /// <inheritdoc/>
        [JsonIgnore]
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.APIKey;

        /// <inheritdoc/>
        [JsonIgnore]
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/{Model.Name}:embedContent";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiEmbedContentRequest"/>.
        /// </summary>
        /// <param name="model">The model to use.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiEmbedContentRequest(GeminiModelId model, bool useBetaApi = false)
        {
            Model = model;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
