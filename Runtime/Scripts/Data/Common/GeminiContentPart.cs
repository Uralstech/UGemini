using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.ComponentModel;
using Uralstech.UGemini.Tools;

namespace Uralstech.UGemini
{
    /// <summary>
    /// A datatype containing media that is part of a multi-part Content message. Must only contain one field at a time.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiContentPart
    {
        /// <summary>
        /// Inline text.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string Text = null;

        /// <summary>
        /// Inline media bytes.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiContentBlob InlineData = null;

        /// <summary>
        /// A predicted FunctionCall returned from the model that contains a string representing the FunctionDeclaratio.name with the arguments and their values.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiFunctionCall FunctionCall = null;

        /// <summary>
        /// The result output of a FunctionCall that contains a string representing the FunctionDeclaration.name and a structured JSON object containing any output from the function is used as context to the model.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiFunctionResponse FunctionResponse = null;
    }
}