namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// Requests for deletion of a tuned model.
    /// </summary>
    public class GeminiTunedModelDeleteRequest : IGeminiDeleteRequest
    {
        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <summary>
        /// The ID of the tuned model.
        /// </summary>
        public GeminiModelId TunedModel;

        /// <inheritdoc>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"https://generativelanguage.googleapis.com/{ApiVersion}/{TunedModel.Name}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiTunedModelDeleteRequest"/>.
        /// </summary>
        /// <param name="tunedModel">The ID of the tuned model to delete.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiTunedModelDeleteRequest(GeminiModelId tunedModel, bool useBetaApi = false)
        {
            TunedModel = tunedModel;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
