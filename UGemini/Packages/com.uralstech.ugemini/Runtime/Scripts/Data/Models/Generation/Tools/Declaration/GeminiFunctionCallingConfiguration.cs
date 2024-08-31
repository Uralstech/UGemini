using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

namespace Uralstech.UGemini.Models.Generation.Tools.Declaration
{
    /// <summary>
    /// Configuration for specifying function calling behavior.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiFunctionCallingConfiguration
    {
        /// <summary>
        /// Specifies the mode in which function calling should execute. If unspecified, the default value will be set to AUTO.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(GeminiFunctionCallingMode.Auto)]
        public GeminiFunctionCallingMode Mode = GeminiFunctionCallingMode.Auto;

        /// <summary>
        /// A set of function names that, when provided, limits the functions the model will call.
        /// </summary>
        /// <remarks>
        /// This should only be set when <see cref="Mode"/> is <see cref="GeminiFunctionCallingMode.Any"/>.<br/>
        /// Function names should match [<see cref="GeminiFunctionDeclaration.Name"/>]. With mode set to <see cref="GeminiFunctionCallingMode.Any"/>,<br/>
        /// model will predict a function call from the set of function names provided.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string[] AllowedFunctionNames = null;
    }
}