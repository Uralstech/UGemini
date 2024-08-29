using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UGemini.Models.Generation.Tools.CodeExecution
{
    /// <summary>
    /// Enumeration of possible outcomes of the code execution.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiCodeExecutionOutcome
    {
        /// <summary>
        /// Unspecified status. This value should not be used.
        /// </summary>
        [EnumMember(Value = "OUTCOME_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// Code execution completed successfully.
        /// </summary>
        [EnumMember(Value = "OUTCOME_OK")]
        Ok,

        /// <summary>
        /// Code execution finished but with a failure. stderr should contain the reason.
        /// </summary>
        [EnumMember(Value = "OUTCOME_FAILED")]
        Failed,

        /// <summary>
        /// Code execution ran for too long, and was cancelled. There may or may not be a partial output present.
        /// </summary>
        [EnumMember(Value = "OUTCOME_DEADLINE_EXCEEDED")]
        DeadlineExceeded,
    }
}