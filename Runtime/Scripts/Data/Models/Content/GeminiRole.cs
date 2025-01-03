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

namespace Uralstech.UGemini.Models.Content
{
    /// <summary>
    /// The role of a Gemini content creator.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiRole
    {
        /// <summary>
        /// Don't use this.
        /// </summary>
        Unspecified,

        /// <summary>
        /// The content was made by the user.
        /// </summary>
        [EnumMember(Value = "user")]
        User,

        /// <summary>
        /// The content was made by the model.
        /// </summary>
        [EnumMember(Value = "model")]
        Assistant,

        /// <summary>
        /// The content was made by a function.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        [EnumMember(Value = "function")]
        ToolResponse,
    }
}