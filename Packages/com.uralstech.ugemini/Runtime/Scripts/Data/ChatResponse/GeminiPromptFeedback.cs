using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.GeminiAPI.Data.ChatResponse
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiPromptFeedback
    {
        public GeminiBlockReason BlockReason;
        public GeminiSafetyRating[] SafetyRatings;
    }
}