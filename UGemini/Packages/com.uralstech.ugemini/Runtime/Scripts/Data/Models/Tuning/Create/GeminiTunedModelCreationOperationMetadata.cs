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
using Uralstech.UGemini.JsonConverters;

namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// Metadata about the state and progress of creating a tuned model returned from the long-running operation
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiTunedModelCreationOperationMetadata
    {
        /// <summary>
        /// The ID of the model being tuned.
        /// </summary>
        [JsonConverter(typeof(GeminiModelIdToStringConverter))]
        public GeminiModelId TunedModel;

        /// <summary>
        /// The total number of tuning steps.
        /// </summary>
        public int TotalSteps;

        /// <summary>
        /// The number of steps completed.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? CompletedSteps = null;

        /// <summary>
        /// The completed percentage for the tuning operation.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float? CompletedPercent = null;

        /// <summary>
        /// Metrics collected during tuning.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GeminiTuningSnapshot[] Snapshots = null;
    }
}