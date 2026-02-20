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

namespace Uralstech.UGemini.Models.Generation.Safety
{
    /// <summary>
    /// Safety setting, affecting the safety-blocking behavior.
    /// </summary>
    /// <remarks>
    /// Passing a safety setting for a category changes the allowed probability that content is blocked.
    /// </remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiSafetySettings
    {
        /// <summary>
        /// The category for this setting.
        /// </summary>
        public GeminiSafetyHarmCategory Category;

        /// <summary>
        /// Controls the probability threshold at which harm is blocked.
        /// </summary>
        public GeminiSafetyHarmBlockThreshold Threshold;
    }
}