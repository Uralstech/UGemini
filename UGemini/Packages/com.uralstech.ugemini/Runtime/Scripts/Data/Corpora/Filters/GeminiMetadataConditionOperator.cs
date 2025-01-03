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

namespace Uralstech.UGemini.CorporaAPI.Filters
{
    /// <summary>
    /// Defines the valid operators that can be applied to a key-value pair.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiMetadataConditionOperator
    {
        /// <summary>
        /// The default value. This value is unused.
        /// </summary>
        [EnumMember(Value = "OPERATOR_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// Supported by numeric.
        /// </summary>
        [EnumMember(Value = "LESS")]
        LessThan,

        /// <summary>
        /// Supported by numeric.
        /// </summary>
        [EnumMember(Value = "LESS_EQUAL")]
        LessThanOrEqual,

        /// <summary>
        /// Supported by numeric and string.
        /// </summary>
        [EnumMember(Value = "EQUAL")]
        Equal,

        /// <summary>
        /// Supported by numeric.
        /// </summary>
        [EnumMember(Value = "GREATER_EQUAL")]
        GreaterThanOrEqual,

        /// <summary>
        /// Supported by numeric.
        /// </summary>
        [EnumMember(Value = "GREATER")]
        GreaterThan,

        /// <summary>
        /// Supported by numeric and string.
        /// </summary>
        [EnumMember(Value = "NOT_EQUAL")]
        NotEqual,

        /// <summary>
        /// Supported by string only when CustomMetadata value type for the given key has a stringListValue.
        /// </summary>
        [EnumMember(Value = "INCLUDES")]
        Includes,

        /// <summary>
        /// Supported by string only when CustomMetadata value type for the given key has a stringListValue.
        /// </summary>
        [EnumMember(Value = "EXCLUDES")]
        Excludes,
    }
}
