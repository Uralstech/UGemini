using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.GeminiAPI.Data.ChatResponse
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCandidate
    {
        public GeminiContent Content;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public GeminiFinishReason FinishReason;

        public GeminiSafetyRating[] SafetyRatings;
        public GeminiCitationMetadata CitationMetadata;
        public int TokenCount;
        public int Index;
    }
}