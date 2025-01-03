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
using Uralstech.UGemini.Models.Content;

namespace Uralstech.UGemini.Models.Generation.QuestionAnswering.Grounding
{
    /// <summary>
    /// Passage included inline with a grounding configuration.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiGroundingPassage
    {
        /// <summary>
        /// Identifier for the passage for attributing this passage in grounded answers.
        /// </summary>
        public string Id;

        /// <summary>
        /// Content of the passage.
        /// </summary>
        public GeminiContent Content;
    }
}
