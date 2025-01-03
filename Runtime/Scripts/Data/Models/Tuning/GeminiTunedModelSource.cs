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
    /// Tuned model as a source for training a new model.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiTunedModelSource
    {
        /// <summary>
        /// The name of the <see cref="GeminiTunedModel"/> to use as the starting point for training the new model. Example: tunedModels/my-tuned-model
        /// </summary>
        [JsonConverter(typeof(GeminiModelIdToStringConverter))]
        public GeminiModelId TunedModel;

        /// <summary>
        /// The name of the base <see cref="GeminiModel"/> this <see cref="GeminiTunedModel"/> was tuned from. Example: models/gemini-1.5-flash-001
        /// </summary>
        [JsonConverter(typeof(GeminiModelIdToStringConverter))]
        public GeminiModelId BaseModel;
    }
}
