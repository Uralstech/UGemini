namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// Gets information about a specific tuned model. Return type is <see cref="GeminiModel"/>.
    /// </summary>
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

        /// <inheritdoc>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"https://generativelanguage.googleapis.com/{ApiVersion}/{TunedModel.Name}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiTunedModelGetRequest"/>.
        /// </summary>
        /// <param name="modelId">The ID of the model to get, in the format tunedModels/{model}.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiTunedModelGetRequest(GeminiModelId modelId, bool useBetaApi = false)
        {
            TunedModel = modelId;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
