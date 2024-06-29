using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;

namespace Uralstech.GeminiAPI.Data
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiContentBlob
    {
        public GeminiContentType MimeType;
        public string Data;
    }
}