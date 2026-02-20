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
using System;

namespace Uralstech.UGemini.JsonConverters
{
    /// <summary>
    /// Converts a <see cref="long"/> array value to a <see cref="string"/> array and vice-versa.
    /// </summary>
    public class GeminiLongArrayToStringArrayJsonConverter : JsonConverter<long[]>
    {
        /// <inheritdoc/>
        public override long[] ReadJson(JsonReader reader, Type objectType, long[] existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<string[]>(reader) is not string[] stringArray
                ? null
                : Array.ConvertAll(stringArray, value => long.TryParse(value, out long longValue) ? longValue : long.MinValue);
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, long[] value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value == null ? null : Array.ConvertAll(value, longValue => longValue.ToString()));
        }
    }
}