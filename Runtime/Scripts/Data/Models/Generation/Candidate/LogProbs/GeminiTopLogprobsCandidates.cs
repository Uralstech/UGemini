using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Generation.Candidate
{
    /// <summary>
    /// Candidates with top log probabilities at each decoding step.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiTopLogprobsCandidates
    {
        /// <summary>
        /// Sorted by log probability in descending order.
        /// </summary>
        public GeminiLogprobsCandidate[] Candidates;
    }
}