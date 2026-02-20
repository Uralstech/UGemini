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
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UGemini.Models.Generation.Tools.CodeExecution
{
    /// <summary>
    /// Enumeration of possible outcomes of the code execution.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiCodeExecutionOutcome
    {
        /// <summary>
        /// Unspecified status. This value should not be used.
        /// </summary>
        [EnumMember(Value = "OUTCOME_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// Code execution completed successfully.
        /// </summary>
        [EnumMember(Value = "OUTCOME_OK")]
        Ok,

        /// <summary>
        /// Code execution finished but with a failure. stderr should contain the reason.
        /// </summary>
        [EnumMember(Value = "OUTCOME_FAILED")]
        Failed,

        /// <summary>
        /// Code execution ran for too long, and was cancelled. There may or may not be a partial output present.
        /// </summary>
        [EnumMember(Value = "OUTCOME_DEADLINE_EXCEEDED")]
        DeadlineExceeded,
    }
}