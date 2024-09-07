namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// Gets information about a specific tuned model. Return type is <see cref="GeminiModel"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiTunedModelGetRequest : IGeminiGetRequest
    {
        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <summary>
        /// The ID of the <see cref="GeminiTunedModel"/> to get, in the format tunedModels/{model}.
        /// </summary>
        public GeminiModelId TunedModel;

        /// <inheritdoc/>
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.OAuthAccessToken;

        /// <inheritdoc/>
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/{TunedModel.Name}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiTunedModelGetRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="modelId">The ID of the model to get, in the format tunedModels/{model}.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiTunedModelGetRequest(GeminiModelId modelId, bool useBetaApi = true)
        {
            TunedModel = modelId;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
