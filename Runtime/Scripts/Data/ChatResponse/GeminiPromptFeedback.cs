using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Chat
{
    /// <summary>
    /// A set of the feedback metadata the prompt specified in <see cref="GeminiChatResponse.Candidates"/>.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiPromptFeedback
    {
        /// <summary>
        /// If set, the prompt was blocked and no candidates are returned. Rephrase your prompt.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GeminiBlockReason BlockReason;

        /// <summary>
        /// Ratings for safety of the prompt. There is at most one rating per category.
        /// </summary>
        public GeminiSafetyRating[] SafetyRatings;
    }
}