using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Answer
{
    /// <summary>
    /// Passage included inline with a grounding configuration.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiGroundingPassage
    {
        /// <summary>
        /// Identifier for the passage for attributing this passage in grounded answers.
        /// </summary>
        public string Id;

        /// <summary>
        /// Content of the passage.
        /// </summary>
        public GeminiContent Content;
    }
}
