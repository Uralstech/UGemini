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

namespace Uralstech.UGemini.Models.Content.Citation
{
    /// <summary>
    /// A citation to a source for a portion of a specific response.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class GeminiCitationSource
    {
        /// <summary>
        /// Start of segment of the response that is attributed to this source.
        /// </summary>
        /// <remarks>
        /// Index indicates the start of the segment, measured in bytes.
        /// </remarks>
        public int StartIndex;

        /// <summary>
        /// End of the attributed segment, exclusive.
        /// </summary>
        public int EndIndex;

        /// <summary>
        /// URI that is attributed as a source for a portion of the text.
        /// </summary>
        public string Uri;

        /// <summary>
        /// License for the GitHub project that is attributed as a source for segment.
        /// </summary>
        public string License;
    }
}