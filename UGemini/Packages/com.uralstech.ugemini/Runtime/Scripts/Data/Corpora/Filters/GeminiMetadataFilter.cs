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

namespace Uralstech.UGemini.CorporaAPI.Filters
{
    /// <summary>
    /// User provided filter to limit retrieval based on Chunk or Document level metadata values.
    /// </summary>
    /// <remarks>
    /// Example (genre = drama OR genre = action): key = "document.custom_metadata.genre" conditions = [{stringValue = "drama", operation = EQUAL}, {stringValue = "action", operation = EQUAL}]
    /// </remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiMetadataFilter
    {
        /// <summary>
        /// The key of the metadata to filter on.
        /// </summary>
        public string Key;

        /// <summary>
        /// The Conditions for the given key that will trigger this filter. Multiple Conditions are joined by logical ORs.
        /// </summary>
        public GeminiMetadataCondition[] Conditions;
    }
}
