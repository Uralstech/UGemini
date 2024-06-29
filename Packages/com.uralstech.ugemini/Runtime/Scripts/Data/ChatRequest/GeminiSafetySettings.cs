using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;

namespace Uralstech.GeminiAPI.Data.ChatRequest
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiSafetySettings
    {
        public GeminiSafetyHarmCategory Category;
        public GeminiSafetyHarmBlockThreshold Threshold;
    }
}