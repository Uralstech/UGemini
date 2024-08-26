using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Generation.Safety
{
    /// <summary>
    /// Safety rating for a piece of content.
    /// </summary>

    /// <remarks>
    /// The safety rating contains the category of harm and the harm probability level in that category for a piece of<br/>
    /// content is classified for safety across a number of harm categories and the probability of the harm classification is included here.
    /// </remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiSafetyRating
    {
        /// <summary>
        /// The category for this rating.
        /// </summary>
        public GeminiSafetyHarmCategory Category;

        /// <summary>
        /// The probability of harm for this content.
        /// </summary>
        public GeminiHarmProbability Probability;

        /// <summary>
        /// Was this content blocked because of this rating?
        /// </summary>
        public bool Blocked;
    }
}