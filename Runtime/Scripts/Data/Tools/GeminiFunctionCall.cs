using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace Uralstech.UGemini.Tools
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
        /// See Protocol Buffer format here: <see href="https://protobuf.dev/reference/protobuf/google.protobuf/#google.protobuf.Struct"/>.
        /// </remarks>
        [JsonProperty("args", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public JObject Arguments = null;
    }
}