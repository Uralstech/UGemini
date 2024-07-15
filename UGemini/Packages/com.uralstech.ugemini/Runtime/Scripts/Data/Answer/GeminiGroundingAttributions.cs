using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Uralstech.UGemini.Chat;

namespace Uralstech.UGemini.Answer
{
    /// <summary>
    /// Attributions for sources that contributed to an answer.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiGroundingAttributions
    {
        /// <summary>
        /// The list of attributions.
        /// </summary>
        public GeminiGroundingAttribution[] Passages;
    }
}
