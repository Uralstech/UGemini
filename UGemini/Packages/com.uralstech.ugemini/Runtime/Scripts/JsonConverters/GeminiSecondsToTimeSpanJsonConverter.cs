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