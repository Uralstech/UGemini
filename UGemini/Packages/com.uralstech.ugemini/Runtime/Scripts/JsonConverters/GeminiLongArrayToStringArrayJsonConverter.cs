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