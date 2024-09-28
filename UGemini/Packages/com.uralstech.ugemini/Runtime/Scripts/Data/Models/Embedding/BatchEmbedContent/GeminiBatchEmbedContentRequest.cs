using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Embedding
{
    /// <summary>
    /// Generates multiple embeddings from the model given input text in a synchronous call.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiBatchEmbedContentRequest : IGeminiPostRequest
    {
        /// <summary>
        /// Embed requests for the batch. The model in each of these requests must match the model specified in <see cref="Model"/>.
        /// </summary>
        public GeminiEmbedContentRequest[] Requests;

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
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/{Model.Name}:batchEmbedContents";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiBatchEmbedContentRequest"/>.
        /// </summary>
        /// <param name="model">The model to use.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiBatchEmbedContentRequest(GeminiModelId model, bool useBetaApi = false)
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
