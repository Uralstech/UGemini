using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using Uralstech.UGemini.Tools.Declaration;

namespace Uralstech.UGemini.Chat
{
    /// <summary>
    /// Request to generate a response from the model.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiChatRequest
    {
        /// <summary>
        /// The content of the current conversation with the model.
        /// </summary>
        /// <remarks>
        /// For single-turn queries, this is a single instance. For multi-turn queries, this is a repeated field that contains conversation history + latest request.
        /// </remarks>
        public GeminiContent[] Contents;

        /// <summary>
        /// A list of Tools the model may use to generate the next response.
        /// </summary>
        /// <remarks>
        /// A Tool is a piece of code that enables the system to interact with external systems to perform an action, or set of actions,<br/>
        /// outside of knowledge and scope of the model.The only supported tool is currently Function.
        /// <br/><br/>
        /// Only available in the beta API.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiTool[] Tools = null;

        /// <summary>
        /// Tool configuration for any Tool specified in the request.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiToolConfiguration ToolConfig = null;

        /// <summary>
        /// A list of unique <see cref="GeminiSafetySettings"/> instances for blocking unsafe content.
        /// </summary>
        /// <remarks>
        /// This will be enforced on <see cref="GeminiChatRequest.Contents"/> and <see cref="ChatResponse.GeminiChatResponse.Candidates"/>.<br/>
        /// There should not be more than one setting for each <see cref="GeminiSafetyHarmCategory"/> type. The API will block any<br/>
        /// contents and responses that fail to meet the thresholds set by these settings. This list overrides the default<br/>
        /// settings for each <see cref="GeminiSafetyHarmCategory"/> specified in the <see cref="SafetySettings"/>. If there is<br/>
        /// no <see cref="GeminiSafetySettings"/> for a given <see cref="GeminiSafetyHarmCategory"/> provided in the list, the API will use the<br/>
        /// default safety setting for that category. Harm categories <see cref="GeminiSafetyHarmCategory.HateSpeech"/>,<br/>
        /// <see cref="GeminiSafetyHarmCategory.SexuallyExplicit"/>, <see cref="GeminiSafetyHarmCategory.DangerousContent"/> and<br/>
        /// <see cref="GeminiSafetyHarmCategory.Harassment"/> are supported.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiSafetySettings[] SafetySettings = null;

        /// <summary>
        /// Developer set system instruction. Currently, text only.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiContent SystemInstruction = null;

        /// <summary>
        /// Configuration options for model generation and outputs.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiGenerationConfiguration GenerationConfig = null;
    }
}