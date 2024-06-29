using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.GeminiAPI.Data.ChatResponse
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiSafetyRating
    {
        public GeminiSafetyHarmCategory Category;
        public GeminiHarmProbability Probability;
        public bool Blocked;
    }
}