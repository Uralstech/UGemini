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
using System.ComponentModel;

namespace Uralstech.UGemini.Models.Generation.Tools.Declaration
{
    /// <summary>
    /// Configuration for specifying function calling behavior.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiFunctionCallingConfiguration
    {
        /// <summary>
        /// Specifies the mode in which function calling should execute. If unspecified, the default value will be set to AUTO.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(GeminiFunctionCallingMode.Auto)]
        public GeminiFunctionCallingMode Mode = GeminiFunctionCallingMode.Auto;

        /// <summary>
        /// A set of function names that, when provided, limits the functions the model will call.
        /// </summary>
        /// <remarks>
        /// This should only be set when <see cref="Mode"/> is <see cref="GeminiFunctionCallingMode.Any"/>.<br/>
        /// Function names should match [<see cref="GeminiFunctionDeclaration.Name"/>]. With mode set to <see cref="GeminiFunctionCallingMode.Any"/>,<br/>
        /// model will predict a function call from the set of function names provided.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string[] AllowedFunctionNames = null;
    }
}