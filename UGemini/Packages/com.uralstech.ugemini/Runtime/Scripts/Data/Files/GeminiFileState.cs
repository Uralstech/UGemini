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

namespace Uralstech.UGemini.FileAPI
{
    /// <summary>
    /// States for the lifecycle of a File.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiFileState
    {
        /// <summary>
        /// The default value. This value is used if the state is omitted.
        /// </summary>
        [EnumMember(Value = "STATE_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// File is being processed and cannot be used for inference yet.
        /// </summary>
        [EnumMember(Value = "PROCESSING")]
        Processing,

        /// <summary>
        /// File is processed and available for inference.
        /// </summary>
        [EnumMember(Value = "ACTIVE")]
        Active,

        /// <summary>
        /// File failed processing.
        /// </summary>
        [EnumMember(Value = "FAILED")]
        Failed,
    }
}
