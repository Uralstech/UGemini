using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Uralstech.UGemini.Models.Generation.Safety;

namespace Uralstech.UGemini.Models.Generation.Candidate
{
    /// <summary>
    /// A set of the feedback metadata for the prompt specified in a generation request.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiPromptFeedback : IAppendableData<GeminiPromptFeedback>
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

        /// <inheritdoc/>
        public void Append(GeminiPromptFeedback data)
        {
            if (data.BlockReason != default)
                BlockReason = data.BlockReason;

            SafetyRatings = data.SafetyRatings;
        }
    }
}