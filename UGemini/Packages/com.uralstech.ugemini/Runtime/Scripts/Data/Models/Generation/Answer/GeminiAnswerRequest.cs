using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using Uralstech.UGemini.Models.Content;
using Uralstech.UGemini.Models.Generation.QuestionAnswering.Grounding;
using Uralstech.UGemini.Models.Generation.QuestionAnswering.SemanticRetriever;
using Uralstech.UGemini.Models.Generation.Safety;

namespace Uralstech.UGemini.Models.Generation.QuestionAnswering
{
    /// <summary>
    /// Generates a grounded answer from the model.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiAnswerRequest : IGeminiPostRequest
    {
        /// <summary>
        /// The content of the current conversation with the model.
        /// </summary>
        /// <remarks>
        /// For single-turn queries, this is a single instance. For multi-turn queries, this is a repeated field that contains conversation history + latest request.
        /// <br/><br/>
        /// generateAnswer currently only supports queries in English.
        /// </remarks>
        public GeminiContent[] Contents;

        /// <summary>
        /// Style in which answers should be returned.
        /// </summary>
        public GeminiAnswerStyle AnswerStyle;

        /// <summary>
        /// A list of unique <see cref="GeminiSafetySettings"/> instances for blocking unsafe content.
        /// </summary>
        /// <remarks>
        /// This will be enforced on <see cref="Contents"/> and <see cref="GeminiAnswerResponse.Answer"/>.<br/>
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
        /// Passages provided inline with the request.
        /// </summary>
        /// <remarks>
        /// This or <see cref="SemanticRetriever"/> are must be provided at a time.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiGroundingPassages InlinePassages = null;

        /// <summary>
        /// Content retrieved from resources created via the Semantic Retriever API.
        /// </summary>
        /// <remarks>
        /// This or <see cref="InlinePassages"/> are must be provided at a time.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiSemanticRetrieverConfig SemanticRetriever = null;

        /// <summary>
        /// Controls the randomness of the output.
        /// </summary>
        /// <remarks>
        /// Values can range from [0.0,1.0], inclusive. A value closer to 1.0 will produce responses that are more varied and<br/>
        /// creative, while a value closer to 0.0 will typically result in more straightforward responses from the model. A low<br/>
        /// temperature (~0.2) is usually recommended for Attributed-Question-Answering use cases.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(-1f)]
        public float Temperature = -1f;

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
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/{Model.Name}:generateAnswer";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiAnswerRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="model">The model to use.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiAnswerRequest(GeminiModelId model, bool useBetaApi = true)
        {
            Model = model;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
