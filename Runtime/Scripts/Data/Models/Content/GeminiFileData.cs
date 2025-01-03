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

namespace Uralstech.UGemini.Models.Content
{
    /// <summary>
    /// URI based data.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiFileData
    {
        /// <summary>
        /// The IANA standard MIME type of the source data.
        /// </summary>
        /// <remarks>
        /// You can use <see cref="GeminiContentTypeExtensions.MimeType(GeminiContentType)"/> to convert <see cref="GeminiContentType"/>
        /// values to their <see cref="string"/> equivalents, like:
        /// <c>GeminiContentType.ImagePNG.MimeType()</c>
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string MimeType = null;

        /// <summary>
        /// URI.
        /// </summary>
        public string FileUri;

        /// <summary>
        /// Creates a new <see cref="GeminiFileData"/> object.
        /// </summary>
        public GeminiFileData() { }

        /// <summary>
        /// Creates a new <see cref="GeminiFileData"/> object.
        /// </summary>
        /// <param name="contentType">The type of the file's contents.</param>
        /// <param name="fileUri">The URI to the file.</param>
        public GeminiFileData(GeminiContentType contentType, string fileUri)
        {
            MimeType = contentType.MimeType();
            FileUri = fileUri;
        }
    }
}