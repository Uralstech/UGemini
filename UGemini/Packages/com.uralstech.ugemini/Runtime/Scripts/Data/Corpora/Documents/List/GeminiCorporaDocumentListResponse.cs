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

namespace Uralstech.UGemini.CorporaAPI.Documents
{
    /// <summary>
    /// The response for a <see cref="GeminiCorporaListRequest"/> call for listing Documents.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorporaDocumentListResponse
    {
        /// <summary>
        /// The list of Documents.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GeminiCorpusDocument[] Documents;

        /// <summary>
        /// A token that can be sent as a <see cref="GeminiCorporaListRequest.PageToken"/> into a subsequent <see cref="GeminiCorporaListRequest"/> call.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string NextPageToken;
    }
}
