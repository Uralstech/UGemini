using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Generation.Candidate.GroundingMetadata
{
    /// <summary>
    /// Google search entry point.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class GeminiSearchEntryPoint
    {
        /// <summary>
        /// Web content snippet that can be embedded in a web page or an app webview.
        /// </summary>
        public string RenderedContent = null;

        /// <summary>
        /// Base64 encoded JSON representing array of &lt;search term, search url&gt; tuple.
        /// </summary>
        public string SdkBlob = null;
    }
}
