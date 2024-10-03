using Newtonsoft.Json;

namespace Uralstech.UGemini.CorporaAPI
{
    /// <summary>
    /// Updates a Corpora API resource. Response type can be <see cref="GeminiCorpus"/>,
    /// <see cref="Documents.GeminiCorpusDocument"/> or <see cref="Chunks.GeminiCorpusChunk"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiCorporaPatchRequest : IGeminiPatchRequest
    {
        /// <summary>
        /// The patch data.
        /// </summary>
        /// <remarks>
        /// See <see cref="GeminiCorpusObjectPatchData"/> for Document and Chunk-specific patch data.
        /// </remarks>
        public GeminiCorpusPatchData Patch;

        /// <summary>
        /// The ID of the Corpora API resource to patch.
        /// </summary>
        public IGeminiCorpusResourceId ResourceId;

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
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/{ResourceId.ResourceName}?updateMask={Patch.GetFieldMask()}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaPatchRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="patch">The patch data.</param>
        /// <param name="resourceId">The resource ID of the Corpora API resource to patch.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaPatchRequest(GeminiCorpusPatchData patch, IGeminiCorpusResourceId resourceId, bool useBetaApi = true)
        {
            Patch = patch;
            ResourceId = resourceId;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(Patch);
        }
    }
}