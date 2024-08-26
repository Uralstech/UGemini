using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

namespace Uralstech.UGemini.Models.Generation.Tools.Declaration
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

        /// <summary>
        /// Creates a new <see cref="GeminiToolConfiguration"/>.
        /// </summary>
        /// <param name="callingMode">Specifies the mode in which function calling should execute.</param>
        /// <param name="allowedFunctions">A set of function names that, when provided, limits the functions the model will call.</param>
        /// <returns></returns>
        public static GeminiToolConfiguration GetConfiguration(GeminiFunctionCallingMode callingMode, string[] allowedFunctions = null)
        {
            return new GeminiToolConfiguration()
            {
                FunctionCallingConfig = new GeminiFunctionCallingConfiguration()
                {
                    Mode = callingMode,
                    AllowedFunctionNames = allowedFunctions,
                },
            };
        }
    }
}