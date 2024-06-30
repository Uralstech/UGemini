using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;

namespace Uralstech.UGemini
{
    /// <summary>
    /// Raw media bytes.
    /// 
    /// Text should not be sent as raw bytes, use the <see cref="GeminiContentPart.Text"/>> field.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiContentBlob
    {
        /// <summary>
        /// The type of the data.
        /// </summary>
        public GeminiContentType MimeType;

        /// <summary>
        /// The base64 encoded bytes of data.
        /// </summary>
        public string Data;
    }
}