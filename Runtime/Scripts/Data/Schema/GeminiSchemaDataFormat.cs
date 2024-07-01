﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UGemini.Schema
{
    /// <summary>
    /// Defines the format of schema data.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiSchemaDataFormat
    {
        /// <summary>
        /// Unspecified, don't use.
        /// </summary>
        Unspecified,

        /// <summary>
        /// Equivalent to <see cref="float"/>.
        /// </summary>
        [EnumMember(Value = "float")]
        Float,

        /// <summary>
        /// Equivalent to <see cref="double"/>.
        /// </summary>
        [EnumMember(Value = "double")]
        Double,

        /// <summary>
        /// Equivalent to <see cref="int"/>.
        /// </summary>
        [EnumMember(Value = "int32")]
        Int,

        /// <summary>
        /// Equivalent to <see cref="long"/>.
        /// </summary>
        [EnumMember(Value = "int64")]
        Long,

        /// <summary>
        /// A string enum value.
        /// </summary>
        [EnumMember(Value = "enum")]
        Enum,

        /// <summary>
        /// A base64 encoded string of bytes.
        /// </summary>
        Base64Bytes,

        /// <summary>
        /// A string of "any sequence of octets".
        /// </summary>
        Binary,

        /// <summary>
        /// Date string as defined by "full-date - <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">[!RFC3339]</see>"
        /// </summary>
        Date,

        /// <summary>
        /// Date and time string as defined by "date-time - <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">[!RFC3339]</see>"
        /// </summary>
        DateTime,
    }
}