using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using Uralstech.UGemini.Models.Content;
using Uralstech.UGemini.Models.Generation.Candidate;

namespace Uralstech.UGemini.Models.Generation.Chat
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
    public class GeminiChatResponse : IAppendableData<GeminiChatResponse>
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
        public GeminiContentPart[] Parts => Candidates?.Length > 0 ? Candidates[0]?.Content?.Parts : null;

        /// <inheritdoc/>
        public void Append(GeminiChatResponse data)
        {
            if (data.PromptFeedback != null)
                PromptFeedback.Append(data.PromptFeedback);

            if (data.UsageMetadata != null)
                UsageMetadata.Append(data.UsageMetadata);

            if (data.Candidates != null)
            {
                for (int i = 0; i < Candidates.Length; i++)
                    Candidates[i].Append(data.Candidates[i]);

                if (data.Candidates.Length > Candidates.Length)
                {
                    GeminiCandidate[] allCandidates = new GeminiCandidate[data.Candidates.Length];
                    Candidates.CopyTo(allCandidates, 0);

                    Array.Copy(data.Candidates, Candidates.Length, allCandidates, Candidates.Length, data.Candidates.Length - Candidates.Length);

                    Candidates = allCandidates;
                }
            }
        }
    }
}