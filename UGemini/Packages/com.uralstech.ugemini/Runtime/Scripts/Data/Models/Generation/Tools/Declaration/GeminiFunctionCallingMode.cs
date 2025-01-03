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

namespace Uralstech.UGemini.Models.Generation.Tools.Declaration
{
    /// <summary>
    /// Defines the execution behavior for function calling by defining the execution mode.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiFunctionCallingMode
    {
        /// <summary>
        /// Unspecified function calling mode. This value should not be used.
        /// </summary>
        [EnumMember(Value = "MODE_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// Default model behavior, model decides to predict either a function call or a natural language response.
        /// </summary>
        [EnumMember(Value = "AUTO")]
        Auto,

        /// <summary>
        /// Model is constrained to always predicting a function call only. If <see cref="GeminiFunctionCallingConfiguration.AllowedFunctionNames"/> is set, the predicted function call will be limited to any one of <see cref="GeminiFunctionCallingConfiguration.AllowedFunctionNames"/>, else the predicted function call will be any one of the provided <see cref="GeminiTool.FunctionDeclarations"/>.
        /// </summary>
        [EnumMember(Value = "ANY")]
        Any,

        /// <summary>
        /// Model will not predict any function call. Model behavior is same as when not passing any function declarations.
        /// </summary>
        [EnumMember(Value = "NONE")]
        None,
    }
}