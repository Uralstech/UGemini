using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.ComponentModel;
using System;

namespace Uralstech.GeminiAPI.Data.ChatRequest
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiGenerationConfiguration
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] StopSequences;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(1)]
        public int CandidateCount = 1;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int MaxOutputTokens;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public float Temperature;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public float TopP;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int TopK;
    }
}