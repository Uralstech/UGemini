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
using System.Collections.Generic;
using System.ComponentModel;
using Uralstech.UGemini.JsonConverters;

namespace Uralstech.UGemini.Models.Generation.Schema
{
    /// <summary>
    /// The Schema object allows the definition of input and output data types. These types can be objects, but also primitives and arrays. Represents a select subset of an OpenAPI 3.0 schema object.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiSchema
    {
        /// <summary>
        /// Data type.
        /// </summary>
        public GeminiSchemaDataType Type;

        /// <summary>
        /// The format of the data. This is used only for primitive datatypes.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(GeminiSchemaDataFormat.Unspecified)]
        public GeminiSchemaDataFormat Format = GeminiSchemaDataFormat.Unspecified;

        /// <summary>
        /// A brief description of the parameter. This could contain examples of use. Parameter description may be formatted as Markdown.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string Description = null;

        /// <summary>
        /// Indicates if the value may be <see langword="null"/>.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public bool? Nullable = null;

        /// <summary>
        /// Possible values of the element of <see cref="GeminiSchemaDataType.String"/> with enum format.
        /// </summary>
        /// <remarks>
        /// For example we can define an Enum Direction as:
        /// 
        /// <code>
        /// GeminiSchema enumSchema = new()
        /// {
        ///     Type = GeminiSchemaDataType.String,
        ///     Format = GeminiSchemaDataFormat.Enum,
        ///     Enum = new string[]
        ///     {
        ///         "EAST",
        ///         "NORTH",
        ///         "SOUTH",
        ///         "WEST",
        ///     },
        /// };
        /// </code>
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string[] Enum = null;

        /// <summary>
        /// Optional. Maximum number of the elements for <see cref="GeminiSchemaDataType.Array"/>.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), JsonConverter(typeof(GeminiLongToStringJsonConverter)), DefaultValue(null)]
        public long? MaxItems = null;

        /// <summary>
        /// Optional. Minimum number of the elements for <see cref="GeminiSchemaDataType.Array"/>.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), JsonConverter(typeof(GeminiLongToStringJsonConverter)), DefaultValue(null)]
        public long? MinItems = null;

        /// <summary>
        /// The properties of <see cref="GeminiSchemaDataType.Object"/>.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public Dictionary<string, GeminiSchema> Properties = null;

        /// <summary>
        /// Required properties of <see cref="GeminiSchemaDataType.Object"/>.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string[] Required = null;

        /// <summary>
        /// Schema of the elements of <see cref="GeminiSchemaDataType.Array"/>.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiSchema Items = null;
    }
}