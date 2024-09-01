using Newtonsoft.Json;

namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// Updates a tuned model. Response type is <see cref="GeminiTunedModel"/>.
    /// </summary>
    public class GeminiTunedModelPatchRequest : IGeminiPatchRequest
    {
        /// <summary>
        /// The patch data.
        /// </summary>
        public GeminiTunedModelPatchData Patch;

        /// <summary>
        /// The ID of the tuned model.
        /// </summary>
        public GeminiModelId TunedModel;

        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <inheritdoc/>
        public string ContentType => GeminiContentType.ApplicationJSON.MimeType();

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"https://generativelanguage.googleapis.com/{ApiVersion}/{TunedModel.Name}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiTunedModelPatchRequest"/>.
        /// </summary>
        /// <param name="patch">The patch data.</param>
        /// <param name="tunedModel">The ID of the tuned model to patch.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiTunedModelPatchRequest(GeminiTunedModelPatchData patch, GeminiModelId tunedModel, bool useBetaApi = false)
        {
            Patch = patch;
            TunedModel = tunedModel;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(Patch);
        }
    }
}