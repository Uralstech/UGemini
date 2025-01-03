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
using System.Text;

namespace Uralstech.UGemini.FileAPI
{
    /// <summary>
    /// Uploads a file to the Gemini File API. Response type is <see cref="GeminiFileUploadResponse"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiFileUploadRequest : IGeminiMultiPartPostRequest
    {
        /// <summary>
        /// Optional metadata for the <see cref="GeminiFile"/> to be uploaded.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiFileUploadMetaData File = null;

        /// <summary>
        /// The IANA standard MIME type of the <see cref="GeminiFileUploadRequest"/>.
        /// </summary>
        [JsonIgnore]
        public string MimeType;

        /// <summary>
        /// The raw file data to upload.
        /// </summary>
        [JsonIgnore]
        public byte[] RawData;

        /// <summary>
        /// The API version to use.
        /// </summary>
        [JsonIgnore]
        public string ApiVersion;

        /// <inheritdoc/>
        [JsonIgnore]
        public string ContentType { get; }

        /// <inheritdoc/>
        [JsonIgnore]
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.APIKey;

        /// <inheritdoc/>
        [JsonIgnore]
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"{GeminiManager.BaseServiceUri}/upload/{ApiVersion}/files";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiFileUploadRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="contentType">The content type of the data.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiFileUploadRequest(string contentType, bool useBetaApi = true)
        {
            ContentType = contentType;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiFileUploadRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="contentType">The content type of the data.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiFileUploadRequest(GeminiContentType contentType, bool useBetaApi = true)
        {
            ContentType = contentType.MimeType();
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData(string dataSeperator)
        {
            StringBuilder data = new($"--{dataSeperator}\r\n");

            data.Append("Content-Disposition: form-data; name=\"metadata\"\r\n");
            data.Append("Content-Type: application/json; charset=UTF-8\r\n\r\n");
            data.Append($"{JsonConvert.SerializeObject(this)}\r\n");

            data.Append($"--{dataSeperator}\r\n");
            data.Append("Content-Disposition: form-data; name=\"file\"\r\n");
            data.Append($"Content-Type: {ContentType}\r\n\r\n");
            data.Append($"{Encoding.UTF8.GetString(RawData)}\r\n");
            data.Append($"--{dataSeperator}--\r\n");

            return data.ToString();
        }
    }
}
