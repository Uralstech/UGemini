using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Uralstech.UGemini.FileAPI
{
    /// <summary>
    /// Metadata for a video <see cref="GeminiFile"/>.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiFileVideoMetaData
    {
        /// <summary>
        /// Duration of the video.
        /// </summary>
        [JsonConverter(typeof(GeminiSecondsToTimeSpanJsonConverter))]
        public TimeSpan VideoDuration;
    }
}
