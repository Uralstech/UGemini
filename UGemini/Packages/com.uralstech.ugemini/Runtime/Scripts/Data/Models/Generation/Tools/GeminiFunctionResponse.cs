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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

namespace Uralstech.UGemini.Models.Generation.Tools
{
    /// <summary>
    /// The result output from a <see cref="GeminiFunctionCall"/> that contains a string representing the <see cref="Declaration.GeminiFunctionDeclaration.Name"/> and a structured JSON object containing any output from the function is used as context to the model.
    /// This should contain the result of a <see cref="GeminiFunctionCall"/> made based on model prediction.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiFunctionResponse
    {
        /// <summary>
        /// The id of the function call this response is for. Populated by the client to match the corresponding function call id.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string Id = null;

        /// <summary>
        /// The name of the function.
        /// </summary>
        public string Name;

        /// <summary>
        /// The actual JSON response data of the function.
        /// </summary>
        [JsonProperty("response")]
        public JObject ResponseData;
    }
}