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

namespace Uralstech.UGemini.Models.Generation.Tools.CodeExecution
{
    /// <summary>
    /// Result of executing the <see cref="GeminiExecutableCode"/>.
    /// </summary>
    /// <remarks>
    /// Only generated when using the <see cref="Declaration.GeminiCodeExecution"/> tool, and always follows a part containing the <see cref="GeminiExecutableCode"/>.
    /// </remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCodeExecutionResult
    {
        /// <summary>
        /// Outcome of the code execution.
        /// </summary>
        public GeminiCodeExecutionOutcome Outcome;

        /// <summary>
        /// Contains stdout when code execution is successful, stderr or other description otherwise.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Output = null;
    }
}