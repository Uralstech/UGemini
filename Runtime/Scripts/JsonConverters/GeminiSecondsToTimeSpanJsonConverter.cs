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
    /// Custom JSON converter to convert a time <see cref="string"/> of a format like "10.334s" to a <see cref="TimeSpan"/>.
    /// </summary>
    public class GeminiSecondsToTimeSpanJsonConverter : JsonConverter<TimeSpan>
    {
        /// <inheritdoc/>/>
        public override TimeSpan ReadJson(JsonReader reader, Type objectType, TimeSpan existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return TimeSpan.FromSeconds(double.Parse(((string)reader.Value).TrimEnd('s')));
        }

        /// <inheritdoc/>/>
        public override void WriteJson(JsonWriter writer, TimeSpan value, JsonSerializer serializer)
        {
            writer.WriteValue($"{value.TotalSeconds:F9}s");
        }
    }
}