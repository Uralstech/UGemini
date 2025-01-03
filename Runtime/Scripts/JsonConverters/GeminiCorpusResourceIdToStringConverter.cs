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
using System.Reflection;
using Uralstech.UGemini.CorporaAPI;

namespace Uralstech.UGemini.JsonConverters
{
    /// <summary>
    /// Custom JSON converter to handle conversion of <see cref="IGeminiCorpusResourceId"/> to a single <see cref="string"/> value and vice-versa.
    /// </summary>
    /// <typeparam name="T">The base class to convert to/from.</typeparam>
    public class GeminiCorpusResourceIdToStringConverter<T> : JsonConverter<T>
        where T : IGeminiCorpusResourceId
    {
        private static readonly ConstructorInfo s_typeConstructor = typeof(T).GetConstructor(new Type[1] { typeof(string) });

        /// <inheritdoc/>
        public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return (T)s_typeConstructor.Invoke(new object[1] { (string)reader.Value });
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ResourceName);
        }
    }

    /// <summary>
    /// Custom JSON converter to handle conversion of <see cref="IGeminiCorpusResourceId"/> to a single <see cref="string"/> value.
    /// </summary>
    public class GeminiCorpusResourceIdToStringConverter : JsonConverter<IGeminiCorpusResourceId>
    {
        /// <inheritdoc/>
        public override IGeminiCorpusResourceId ReadJson(JsonReader reader, Type objectType, IGeminiCorpusResourceId existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, IGeminiCorpusResourceId value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ResourceName);
        }
    }
}
