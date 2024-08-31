using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UGemini.Models.Generation.Tools.CodeExecution
{
    /// <summary>
    /// Supported programming languages for the generated code.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiCodeExecutionLanguage
    {
        /// <summary>
        /// Unspecified language. This value should not be used.
        /// </summary>
        [EnumMember(Value = "LANGUAGE_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// Python >= 3.10, with numpy and simpy available.
        /// </summary>
        [EnumMember(Value = "PYTHON")]
        Python,
    }
}