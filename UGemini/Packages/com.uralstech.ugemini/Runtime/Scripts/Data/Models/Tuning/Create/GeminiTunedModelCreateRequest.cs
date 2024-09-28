using Newtonsoft.Json;

namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// Creates a tuned model. Response type is <see cref="GeminiTunedModelCreateResponse"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiTunedModelCreateRequest : IGeminiPostRequest
    {
        /// <summary>
        /// The tuned model to be created.
        /// </summary>
        public GeminiTunedModelCreationData Model;

        /// <summary>
        /// The unique id for the tuned model if specified.
        /// </summary>
        /// <remarks>
        /// This value should be up to 40 characters, the first character must be a letter, the last could<br/>
        /// be a letter or a number.
        /// </remarks>
        public GeminiModelId ModelId = string.Empty;

        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <inheritdoc/>
        public string ContentType => GeminiContentType.ApplicationJSON.MimeType();

        /// <inheritdoc/>
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.OAuthAccessToken;

        /// <inheritdoc/>
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return !string.IsNullOrEmpty(ModelId)
                ? $"{GeminiManager.BaseServiceUri}/{ApiVersion}/tunedModels?tunedModelId={ModelId.BaseModelId}"
                : $"{GeminiManager.BaseServiceUri}/{ApiVersion}/tunedModels";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiTunedModelCreateRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="model">The tuned model to be created.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiTunedModelCreateRequest(GeminiTunedModelCreationData model, bool useBetaApi = true)
        {
            Model = model;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(Model);
        }
    }
}