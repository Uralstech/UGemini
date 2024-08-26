using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using Uralstech.UGemini.Models.Generation.Schema;

namespace Uralstech.UGemini.Models.Generation.Tools.Declaration
{
    /// <summary>
    /// Structured representation of a function declaration as defined by the OpenAPI 3.03 specification.<br/>
    /// Included in this declaration are the function name and parameters. This FunctionDeclaration is a<br/>
    /// representation of a block of code that can be used as a Tool by the model and executed by the client.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiFunctionDeclaration
    {
        /// <summary>
        /// The name of the function. Must be a-z, A-Z, 0-9, or contain underscores and dashes, with a maximum length of 63.
        /// </summary>
        public string Name;

        /// <summary>
        /// A brief description of the function.
        /// </summary>
        public string Description;

        /// <summary>
        /// Describes the parameters to this function. Reflects the Open API 3.03 Parameter Object string Key: the name of the parameter.<br/>
        /// Parameter names are case sensitive.<br/>
        /// Schema Value: the Schema defining the type used for the parameter.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiSchema Parameters = null;
    }
}