using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.ComponentModel;
using Uralstech.UGemini.Chat;
using Uralstech.UGemini.Models;

namespace Uralstech.UGemini.TokenCounting
{
    /// <summary>
    /// Request to count tokens in given content.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiTokenCountRequest : IGeminiPostRequest
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
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"https://generativelanguage.googleapis.com/{ApiVersion}/{Model.Name}:countTokens";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiTokenCountRequest"/>.
        /// </summary>
        /// <param name="model">The model to use.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiTokenCountRequest(GeminiModelId model, bool useBetaApi = false)
        {
            Model = model;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// \deprecated Use <see cref="GeminiTokenCountRequest(GeminiModelId, bool)"/> as this constructor is only for the deprecated <see cref="GeminiManager.Compute{TRequest, TResponse}(TRequest, GeminiManager.RequestEndPoint, string, bool)"/> method.
        [Obsolete("Use GeminiTokenCountRequest(GeminiModelId, bool) as this constructor is only for the deprecated GeminiManager.Compute method.")]
        public GeminiTokenCountRequest() { }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}