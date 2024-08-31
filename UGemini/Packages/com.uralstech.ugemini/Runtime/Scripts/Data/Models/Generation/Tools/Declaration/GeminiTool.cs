using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using Uralstech.UGemini.Models.Content;

namespace Uralstech.UGemini.Models.Generation.Tools.Declaration
{
    /// <summary>
    /// Tool details that the model may use to generate response.
    /// </summary>
    /// <remarks>
    /// A Tool is a piece of code that enables the system to interact with external systems<br/>
    /// to perform an action, or set of actions, outside of knowledge and scope of the model.
    /// </remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiTool
    {
        /// <summary>
        /// A list of FunctionDeclarations available to the model that can be used for function calling.
        /// </summary>
        /// <remarks>
        /// The model or system does not execute the function. Instead the defined function may be returned as<br/>
        /// a [<see cref="GeminiFunctionCall"/>][<see cref="GeminiContent"/>.<see cref="GeminiContentPart.FunctionCall"/>] with arguments to the client<br/>
        /// side for execution. The model may decide to call a subset of these functions by populating<br/>
        /// [<see cref="GeminiFunctionCall"/>][<see cref="GeminiContent"/>.<see cref="GeminiContentPart.FunctionCall"/>] in the response.<br/>
        /// The next conversation turn may contain a [<see cref="GeminiFunctionResponse"/>][<see cref="GeminiContent"/>.<see cref="GeminiContentPart.FunctionResponse"/>]<br/>
        /// with the [<see cref="GeminiContent.Role"/>] <see cref="GeminiRole.ToolResponse"/> generation context for the next model turn.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiFunctionDeclaration[] FunctionDeclarations = null;

        /// <summary>
        /// Enables the model to execute code as part of generation.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiCodeExecution CodeExecution = null;
    }
}