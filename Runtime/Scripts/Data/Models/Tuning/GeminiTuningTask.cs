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
using System;

namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// Tuning tasks that create tuned models.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiTuningTask
    {
        /// <summary>
        /// The timestamp when tuning this model started.
        /// </summary>
        public DateTime StartTime;

        /// <summary>
        /// The timestamp when tuning this model completed.
        /// </summary>
        public DateTime CompleteTime;

        /// <summary>
        /// Metrics collected during tuning.
        /// </summary>
        public GeminiTuningSnapshot[] Snapshots;

        /// <summary>
        ///  Hyperparameters controlling the tuning process.
        /// </summary>
        public GeminiTuningHyperparameters Hyperparameters;
    }
}
