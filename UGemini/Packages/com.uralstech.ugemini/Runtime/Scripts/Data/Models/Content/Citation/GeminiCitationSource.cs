using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Content.Citation
{
    /// <summary>
    /// A citation to a source for a portion of a specific response.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class GeminiCitationSource
    {
        /// <summary>
        /// Start of segment of the response that is attributed to this source.
        /// </summary>
        /// <remarks>
        /// Index indicates the start of the segment, measured in bytes.
        /// </remarks>
        public int StartIndex;

        /// <summary>
        /// End of the attributed segment, exclusive.
        /// </summary>
        public int EndIndex;

        /// <summary>
        /// URI that is attributed as a source for a portion of the text.
        /// </summary>
        public string Uri;

        /// <summary>
        /// License for the GitHub project that is attributed as a source for segment.
        /// </summary>
        public string License;
    }
}