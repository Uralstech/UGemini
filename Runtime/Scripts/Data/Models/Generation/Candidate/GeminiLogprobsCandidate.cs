using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Generation.Candidate
{
    /// <summary>
    /// Candidate for the logprobs token and score.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiLogprobsCandidate
    {
        /// <summary>
        /// The candidate’s token string value.
        /// </summary>
        public string Token;

        /// <summary>
        /// The candidate’s token id value.
        /// </summary>
        public int TokenId;

        /// <summary>
        /// The candidate's log probability.
        /// </summary>
        public float LogProbability;
    }
}