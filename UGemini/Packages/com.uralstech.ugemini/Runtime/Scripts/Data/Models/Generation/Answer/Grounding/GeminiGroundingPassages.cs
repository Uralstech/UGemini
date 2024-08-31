using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Generation.QuestionAnswering.Grounding
{
    /// <summary>
    /// A repeated list of passages.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiGroundingPassages
    {
        /// <summary>
        /// List of passages.
        /// </summary>
        public GeminiGroundingPassage[] Passages;
    }
}
