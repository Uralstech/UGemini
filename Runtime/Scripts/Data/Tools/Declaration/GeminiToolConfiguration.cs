using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Uralstech.UGemini.Tools.Declaration
{
    /// <summary>
    /// The Tool configuration containing parameters for specifying Tool use in the request.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiToolConfiguration
    {
        /// <summary>
        /// Function calling config.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiFunctionCallingConfiguration FunctionCallingConfig = null;
    }
}