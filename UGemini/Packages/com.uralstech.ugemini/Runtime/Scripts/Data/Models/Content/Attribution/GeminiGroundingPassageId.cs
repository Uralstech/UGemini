using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Content.Attribution
{
    /// <summary>
    /// Identifier for a part within a GroundingPassage.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiGroundingPassageId
    {
        /// <summary>
        /// ID of the passage matching the GenerateAnswerRequest's <see cref="GeminiAttributionSourceId.GroundingPassage"/>.
        /// </summary>
        public string PassageId;

        /// <summary>
        /// Index of the part within the GenerateAnswerRequest's <see cref="GeminiAttributionSourceId.GroundingPassage"/>.
        /// </summary>
        public int PartIndex;
    }
}