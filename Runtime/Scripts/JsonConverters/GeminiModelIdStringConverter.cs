using Newtonsoft.Json;
using System;
using Uralstech.UGemini.Models;

namespace Uralstech.UGemini.JsonConverters
{
    /// <summary>
    /// Custom JSON converter to handle conversion of <see cref="GeminiModelId"/> to a single <see cref="string"/> value and vice-versa.
    /// </summary>
    public class GeminiModelIdStringConverter : JsonConverter<GeminiModelId>
    {
        /// <inheritdoc/>/>
        public override GeminiModelId ReadJson(JsonReader reader, Type objectType, GeminiModelId existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new GeminiModelId((string)reader.Value);
        }

        /// <inheritdoc/>/>
        public override void WriteJson(JsonWriter writer, GeminiModelId value, JsonSerializer serializer)
        {
            writer.WriteValue(value.Name);
        }
    }
}
