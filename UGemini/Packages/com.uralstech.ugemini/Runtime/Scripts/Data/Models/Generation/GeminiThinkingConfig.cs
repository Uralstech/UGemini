// Copyright 2025 URAV ADVANCED LEARNING SYSTEMS PRIVATE LIMITED
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

namespace Uralstech.UGemini.Models.Generation
{
    /// <summary>
    /// Config for thinking features.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiThinkingConfig
    {
        /// <summary>
        /// Indicates whether to include thoughts in the response. If true, thoughts are returned only when available.
        /// </summary>
        public bool IncludeThoughts;

        /// <summary>
        /// The number of thoughts tokens that the model should generate.
        /// </summary>
        public int ThinkingBudget;
    }
}