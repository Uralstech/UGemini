using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Generation.Tools.CodeExecution
{
    /// <summary>
    /// Result of executing the <see cref="GeminiExecutableCode"/>.
    /// </summary>
    /// <remarks>
    /// Only generated when using the <see cref="Declaration.GeminiCodeExecution"/> tool, and always follows a part containing the <see cref="GeminiExecutableCode"/>.
    /// </remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCodeExecutionResult
    {
        /// <summary>
        /// Outcome of the code execution.
        /// </summary>
        public GeminiCodeExecutionOutcome Outcome;

        /// <summary>
        /// Contains stdout when code execution is successful, stderr or other description otherwise.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Output = null;
    }
}