using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UGemini.Models.Generation.Tools.Declaration
{
    /// <summary>
    /// Defines the execution behavior for function calling by defining the execution mode.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiFunctionCallingMode
    {
        /// <summary>
        /// Unspecified function calling mode. This value should not be used.
        /// </summary>
        [EnumMember(Value = "MODE_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// Default model behavior, model decides to predict either a function call or a natural language response.
        /// </summary>
        [EnumMember(Value = "AUTO")]
        Auto,

        /// <summary>
        /// Model is constrained to always predicting a function call only. If <see cref="GeminiFunctionCallingConfiguration.AllowedFunctionNames"/> is set, the predicted function call will be limited to any one of <see cref="GeminiFunctionCallingConfiguration.AllowedFunctionNames"/>, else the predicted function call will be any one of the provided <see cref="GeminiTool.FunctionDeclarations"/>.
        /// </summary>
        [EnumMember(Value = "ANY")]
        Any,

        /// <summary>
        /// Model will not predict any function call. Model behavior is same as when not passing any function declarations.
        /// </summary>
        [EnumMember(Value = "NONE")]
        None,
    }
}