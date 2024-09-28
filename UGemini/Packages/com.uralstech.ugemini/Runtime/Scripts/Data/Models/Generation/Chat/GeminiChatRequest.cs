using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using UnityEngine;
using Uralstech.UGemini.Models.Content;
using Uralstech.UGemini.Models.Generation.Safety;
using Uralstech.UGemini.Models.Generation.Tools.Declaration;

namespace Uralstech.UGemini.Models.Generation.Chat
{
    /// <summary>
    /// Request to generate a response from the model.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiChatRequest : IGeminiStreamablePostRequest<GeminiChatResponse>
    {
        /// <summary>
        /// Serialization settings for deserializing partial streamed responses.
        /// </summary>
        private static readonly JsonSerializerSettings s_partialDataSerializerSettings = new()
        {
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
        };

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
        /// This will be enforced on <see cref="Contents"/> and <see cref="GeminiChatResponse.Candidates"/>.<br/>
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

        /// <summary>
        /// The name of the cached content used as context to serve the prediction. Format: cachedContents/{cachedContent}
        /// </summary>
        /// <remarks>
        /// Note: only used in explicit caching, where users can have control over caching (e.g. what content to cache) and enjoy guaranteed cost savings.
        /// <br/><br/>
        /// Only available in the beta API.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string CachedContent = null;

        /// <summary>
        /// The model to use.
        /// </summary>
        [JsonIgnore]
        public GeminiModelId Model;

        /// <summary>
        /// The API version to use.
        /// </summary>
        [JsonIgnore]
        public string ApiVersion;

        /// <inheritdoc/>
        [JsonIgnore]
        public string ContentType => GeminiContentType.ApplicationJSON.MimeType();

        /// <inheritdoc/>
        [JsonIgnore]
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.APIKey;

        /// <inheritdoc/>
        [JsonIgnore]
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return metadata?.IsStreaming == true
                ? $"{GeminiManager.BaseServiceUri}/{ApiVersion}/{Model.Name}:streamGenerateContent"
                : $"{GeminiManager.BaseServiceUri}/{ApiVersion}/{Model.Name}:generateContent";
        }

        /// <summary>
        /// Callback for receiving streamed responses.
        /// </summary>
        [JsonIgnore]
        public Func<GeminiChatResponse, Task> OnPartialResponseReceived;

        /// <summary>
        /// The streamed response.
        /// </summary>
        [JsonIgnore]
        public GeminiChatResponse StreamedResponse { get; private set; }

        /// <summary>
        /// Creates a new <see cref="GeminiChatRequest"/>.
        /// </summary>
        /// <param name="model">The model to use.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiChatRequest(GeminiModelId model, bool useBetaApi = false)
        {
            Model = model;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <inheritdoc/>
        public async Task ProcessStreamedData(List<JToken> allEvents, JToken lastEvent)
        {
            try
            {
                GeminiChatResponse partialResponse = lastEvent.ToObject<GeminiChatResponse>(JsonSerializer.Create(s_partialDataSerializerSettings));

                if (StreamedResponse == null)
                    StreamedResponse = partialResponse;
                else
                    StreamedResponse.Append(partialResponse);

                if (OnPartialResponseReceived != null)
                    await OnPartialResponseReceived.Invoke(StreamedResponse);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to process streamed data:\n{e}");
            }
        }
    }
}