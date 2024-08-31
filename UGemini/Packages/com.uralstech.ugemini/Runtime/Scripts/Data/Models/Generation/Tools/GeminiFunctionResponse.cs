using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

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
        /// The name of the function to call. Must be a-z, A-Z, 0-9, or contain underscores and dashes, with a maximum length of 63.
        /// </summary>
        public string Name;

        /// <summary>
        /// The function response data.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiFunctionResponseContent Response = null;
    }
}