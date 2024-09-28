using Newtonsoft.Json;

namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// Updates a tuned model. Response type is <see cref="GeminiTunedModelPatchData"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
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
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.OAuthAccessToken;

        /// <inheritdoc/>
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/{TunedModel.Name}?updateMask={Patch.GetFieldMask()}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiTunedModelPatchRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="patch">The patch data.</param>
        /// <param name="tunedModel">The ID of the tuned model to patch.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiTunedModelPatchRequest(GeminiTunedModelPatchData patch, GeminiModelId tunedModel, bool useBetaApi = true)
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