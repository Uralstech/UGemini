using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Generation.Candidate
{
    /// <summary>
    /// Logprobs result.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiLogprobsResult
    {
        /// <summary>
        /// Length = total number of decoding steps.
        /// </summary>
        public GeminiTopLogprobsCandidates[] TopCandidates;

        /// <summary>
        /// Length = total number of decoding steps. The chosen candidates may or may not be in <see cref="TopCandidates"/>.
        /// </summary>
        public GeminiLogprobsCandidate[] ChosenCandidates;
    }
}