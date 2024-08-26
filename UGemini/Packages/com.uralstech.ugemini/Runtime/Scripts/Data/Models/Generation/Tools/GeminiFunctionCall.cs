using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

namespace Uralstech.UGemini.Models.Generation.Tools
{
    /// <summary>
    /// A predicted FunctionCall returned from the model that contains a string representing the FunctionDeclaration.name with the arguments and their values.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiFunctionCall
    {
        /// <summary>
        /// The name of the function to call. Must be a-z, A-Z, 0-9, or contain underscores and dashes, with a maximum length of 63.
        /// </summary>
        public string Name;

        /// <summary>
        /// Optional. The function parameters and values in JSON object format.
        /// </summary>
        /// <remarks>
        /// See Protocol Buffer <a href="https://protobuf.dev/reference/protobuf/google.protobuf/#google.protobuf.Struct">Struct</a>.
        /// </remarks>
        [JsonProperty("args", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public JObject Arguments = null;

        /// <summary>
        /// Creates a <see cref="GeminiFunctionResponse"/> for this function call.
        /// </summary>
        /// <param name="responseJson">The JSON response data.</param>
        /// <returns>A new <see cref="GeminiFunctionResponse"/> object.</returns>
        public GeminiFunctionResponse GetResponse(JObject responseJson = null)
        {
            return new GeminiFunctionResponse()
            {
                Name = Name,
                Response = responseJson == null ? null : new GeminiFunctionResponseContent()
                {
                    Name = Name,
                    ResponseData = responseJson
                }
            };
        }
    }
}