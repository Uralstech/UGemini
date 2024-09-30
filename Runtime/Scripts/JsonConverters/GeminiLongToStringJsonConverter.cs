using Newtonsoft.Json;
using System;

namespace Uralstech.UGemini.JsonConverters
{
    /// <summary>
    /// Converts a <see cref="long"/> value to a <see cref="string"/> and vice-versa.
    /// </summary>
    public class GeminiLongToStringJsonConverter : JsonConverter<long?>
    {
        /// <inheritdoc/>
        public override long? ReadJson(JsonReader reader, Type objectType, long? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return long.TryParse((string)reader.Value, out long value) ? value : null;
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, long? value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }
}