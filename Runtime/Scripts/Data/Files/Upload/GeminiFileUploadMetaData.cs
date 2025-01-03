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

namespace Uralstech.UGemini.FileAPI
{
    /// <summary>
    /// Metadata for a <see cref="GeminiFile"/> to be uploaded.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiFileUploadMetaData
    {
        /// <summary>
        /// The <see cref="GeminiFileUploadRequest"/> resource name, in format "files/{fileId}".
        /// </summary>
        /// <remarks>
        /// The ID (name excluding the "files/" prefix) can contain up to 40 characters that are lowercase alphanumeric or dashes (-).<br/>
        /// The ID cannot start or end with a dash. If the name is empty on create, a unique name will be generated. Example: files/123-456
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string Name = null;

        /// <summary>
        /// The human-readable display name for the <see cref="GeminiFileUploadRequest"/>. The display name must be no more than 512 characters in length, including spaces. Example: "Welcome Image"
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string DisplayName = null;

        /// <summary>
        /// Creates a new <see cref="GeminiFileUploadMetaData"/> object.
        /// </summary>
        public GeminiFileUploadMetaData() { }

        /// <summary>
        /// Creates a new <see cref="GeminiFileUploadMetaData"/> object.
        /// </summary>
        /// <param name="fileNameOrId">The name (format 'files/{fileId}') or ID of the file to be uploaded.</param>
        public GeminiFileUploadMetaData(string fileNameOrId)
        {
            Name = $"files/{fileNameOrId.Split('/')[^1]}";
        }
    }
}
