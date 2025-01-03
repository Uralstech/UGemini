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
    /// The Tool configuration containing parameters for specifying Tool use in the request.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiToolConfiguration
    {
        /// <summary>
        /// Function calling config.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiFunctionCallingConfiguration FunctionCallingConfig = null;

        /// <summary>
        /// Creates a new <see cref="GeminiToolConfiguration"/>.
        /// </summary>
        /// <param name="callingMode">Specifies the mode in which function calling should execute.</param>
        /// <param name="allowedFunctions">A set of function names that, when provided, limits the functions the model will call.</param>
        /// <returns></returns>
        public static GeminiToolConfiguration GetConfiguration(GeminiFunctionCallingMode callingMode, string[] allowedFunctions = null)
        {
            return new GeminiToolConfiguration()
            {
                FunctionCallingConfig = new GeminiFunctionCallingConfiguration()
                {
                    Mode = callingMode,
                    AllowedFunctionNames = allowedFunctions,
                },
            };
        }
    }
}