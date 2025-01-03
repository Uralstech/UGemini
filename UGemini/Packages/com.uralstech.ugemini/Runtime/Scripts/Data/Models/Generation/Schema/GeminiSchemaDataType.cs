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

namespace Uralstech.UGemini.Models.Generation.Schema
{
    /// <summary>
    /// Contains the list of OpenAPI data types as defined by the <a href="https://spec.openapis.org/oas/v3.0.3#data-types">OpenAPI Specification</a>.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiSchemaDataType
    {
        /// <summary>
        /// Not specified, should not be used.
        /// </summary>
        [EnumMember(Value = "TYPE_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// String type.
        /// </summary>
        [EnumMember(Value = "STRING")]
        String,

        /// <summary>
        /// Number/Float type.
        /// </summary>
        [EnumMember(Value = "NUMBER")]
        Float,

        /// <summary>
        /// Integer type.
        /// </summary>
        [EnumMember(Value = "INTEGER")]
        Integer,

        /// <summary>
        /// Boolean type.
        /// </summary>
        [EnumMember(Value = "BOOLEAN")]
        Boolean,

        /// <summary>
        /// Array type.
        /// </summary>
        [EnumMember(Value = "ARRAY")]
        Array,

        /// <summary>
        /// Object type.
        /// </summary>
        [EnumMember(Value = "OBJECT")]
        Object,
    }
}