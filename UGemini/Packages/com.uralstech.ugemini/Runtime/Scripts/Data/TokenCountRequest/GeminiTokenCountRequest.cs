using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.ComponentModel;
using Uralstech.UGemini.Chat;

namespace Uralstech.UGemini.TokenCounting
{
    /// <summary>
    /// Request to count tokens in given content.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiTokenCountRequest
    {
        /// <summary>
        /// The input given to the model as a prompt. This field is ignored when <see cref="CompleteRequest"/> is set.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiContent[] Contents = null;

        /// <summary>
        /// The overall input given to the model. CountTokens will count prompt, function calling, etc.
        /// </summary>
        [JsonProperty("generateContentRequest", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiChatRequest CompleteRequest = null;
    }
}