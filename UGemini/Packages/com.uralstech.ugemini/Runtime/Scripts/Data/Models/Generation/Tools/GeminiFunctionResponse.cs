using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Generation.Tools
{
    /// <summary>
    /// The result output from a <see cref="GeminiFunctionCall"/> that contains a string representing the <see cref="Declaration.GeminiFunctionDeclaration.Name"/> and a structured JSON object containing any output from the function is used as context to the model.
    /// This should contain the result of a <see cref="GeminiFunctionCall"/> made based on model prediction.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiFunctionResponse
    {
        /// <summary>
        /// The name of the function.
        /// </summary>
        public string Name;

        /// <summary>
        /// The actual JSON response data of the function.
        /// </summary>
        [JsonProperty("response")]
        public JObject ResponseData;
    }
}