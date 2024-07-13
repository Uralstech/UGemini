namespace Uralstech.UGemini.Models
{
    /// <summary>
    /// Gets information about a specific model. Return type is <see cref="GeminiModel"/>.
    /// </summary>
    public class GeminiModelGetRequest : IGeminiGetRequest
    {
        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <summary>
        /// The resource name of the model to get, in the format models/{model}.
        /// </summary>
        public string ModelName;

        /// <inheritdoc>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"https://generativelanguage.googleapis.com/{ApiVersion}/{ModelName}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiModelGetRequest"/>.
        /// </summary>
        /// <remarks>
        /// Some newer models do not work with this request unless through the Beta API.
        /// </remarks>
        /// <param name="modelId">The ID of the model to get.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiModelGetRequest(GeminiModelId modelId, bool useBetaApi = false)
        {
            ModelName = modelId.Name;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
