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

namespace Uralstech.UGemini.Models.Generation.Candidate
{
    /// <summary>
    /// Content Part modality.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiModality
    {
        /// <summary>
        /// Unspecified modality.
        /// </summary>
        [EnumMember(Value = "MODALITY_UNSPECIFIED")]
        Unspecified = 0,

        /// <summary>
        /// Plain text.
        /// </summary>
        [EnumMember(Value = "TEXT")]
        Text,

        /// <summary>
        /// Image.
        /// </summary>
        [EnumMember(Value = "IMAGE")]
        Image,

        /// <summary>
        /// Video.
        /// </summary>
        [EnumMember(Value = "VIDEO")]
        Video,

        /// <summary>
        /// Audio.
        /// </summary>
        [EnumMember(Value = "AUDIO")]
        Audio,

        /// <summary>
        /// Document, e.g. PDF.
        /// </summary>
        [EnumMember(Value = "DOCUMENT")]
        Document,
    }
}
