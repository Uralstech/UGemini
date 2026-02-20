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
    /// A predicted FunctionCall returned from the model that contains a string representing the FunctionDeclaration.name with the arguments and their values.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiFunctionCall
    {
        /// <summary>
        /// The unique id of the function call. If populated, the client to execute the functionCall and return the response with the matching id.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string Id = null;

        /// <summary>
        /// The name of the function to call. Must be a-z, A-Z, 0-9, or contain underscores and dashes, with a maximum length of 63.
        /// </summary>
        public string Name;

        /// <summary>
        /// Optional. The function parameters and values in JSON object format.
        /// </summary>
        /// <remarks>
        /// See Protocol Buffer <a href="https://protobuf.dev/reference/protobuf/google.protobuf/#google.protobuf.Struct">Struct</a>.
        /// </remarks>
        [JsonProperty("args", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public JObject Arguments = null;

        /// <summary>
        /// Creates a <see cref="GeminiFunctionResponse"/> for this function call.
        /// </summary>
        /// <param name="responseJson">The JSON response data.</param>
        /// <returns>A new <see cref="GeminiFunctionResponse"/> object.</returns>
        public GeminiFunctionResponse GetResponse(JObject responseJson = null)
        {
            return new GeminiFunctionResponse()
            {
                Id = !string.IsNullOrEmpty(Id) ? Id : null,
                Name = Name,
                ResponseData = responseJson
            };
        }
    }
}