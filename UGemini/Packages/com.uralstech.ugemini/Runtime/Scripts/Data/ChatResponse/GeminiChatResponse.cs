using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Chat
{
    /// <summary>
    /// Response from the model supporting multiple candidates.
    /// </summary>
    /// <remarks>
    /// Note on safety ratings and content filtering. They are reported for both prompt in<br/>
    /// <see cref="PromptFeedback"/> and for each candidate in <see cref="GeminiCandidate.FinishReason"/><br/>
    /// and in <see cref="GeminiCandidate.SafetyRatings"/>. The API contract is that:<br/>
    /// - either all requested candidates are returned or no candidates at all<br/>
    /// - no candidates are returned only if there was something wrong with the prompt (see <see cref="PromptFeedback"/>)<br/>
    /// - feedback on each candidate is reported on <see cref="GeminiCandidate.FinishReason"/> and <see cref="GeminiCandidate.SafetyRatings"/>.
    /// </remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiChatResponse
    {
        /// <summary>
        /// Candidate responses from the model.
        /// </summary>
        public GeminiCandidate[] Candidates;

        /// <summary>
        /// Returns the prompt's feedback related to the content filters.
        /// </summary>
        public GeminiPromptFeedback PromptFeedback;

        /// <summary>
        /// Metadata on the generation requests' token usage.
        /// </summary>
        public GeminiUsageMetadata UsageMetadata;

        /// <summary>
        /// The parts of the <see cref="GeminiChatResponse"/> message.
        /// </summary>
        [JsonIgnore]
        public GeminiContentPart[] Parts => Candidates[0].Content.Parts;
    }
}