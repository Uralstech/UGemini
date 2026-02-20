// Copyright 2025 URAV ADVANCED LEARNING SYSTEMS PRIVATE LIMITED
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

namespace Uralstech.UGemini.Models.Generation
{
    /// <summary>
    /// Media resolution for the input media.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiMediaResolution
    {
        /// <summary>
        /// Media resolution has not been set.
        /// </summary>
        [EnumMember(Value = "MEDIA_RESOLUTION_UNSPECIFIED")]
        Unspecified = 0,

        /// <summary>
        /// Media resolution set to low (64 tokens).
        /// </summary>
        [EnumMember(Value = "MEDIA_RESOLUTION_LOW")]
        Low,

        /// <summary>
        /// Media resolution set to medium (256 tokens).
        /// </summary>
        [EnumMember(Value = "MEDIA_RESOLUTION_MEDIUM")]
        Medium,

        /// <summary>
        /// Media resolution set to high (zoomed reframing with 256 tokens).
        /// </summary>
        [EnumMember(Value = "MEDIA_RESOLUTION_HIGH")]
        High,
    }
}