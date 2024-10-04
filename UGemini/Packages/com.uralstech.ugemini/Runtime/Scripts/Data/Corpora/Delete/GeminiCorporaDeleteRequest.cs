namespace Uralstech.UGemini.CorporaAPI
{
    /// <summary>
    /// Deletes a Corpora API resource.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiCorporaDeleteRequest : IGeminiDeleteRequest
    {
        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <summary>
        /// The ID of the Corpora API resource to delete.
        /// </summary>
        public IGeminiCorpusResourceId ResourceId;

        /// <summary>
        /// If set to <see langword="true"/>, any Documents/Chunks and objects related to this Corpus/Document will also be deleted.
        /// If <see langword="false"/>, a FAILED_PRECONDITION error will be returned if the Corpus/Document contains any Documents/Chunks.
        /// </summary>
        /// <remarks>
        /// Unsupported for Chunk deletion requests.
        /// </remarks>
        public bool ForceDelete = false;

        /// <inheritdoc/>
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.OAuthAccessToken;

        /// <inheritdoc/>
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return ForceDelete
                ? $"{GeminiManager.BaseServiceUri}/{ApiVersion}/{ResourceId.ResourceName}?force=true"
                : $"{GeminiManager.BaseServiceUri}/{ApiVersion}/{ResourceId.ResourceName}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaDeleteRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="resourceId">The ID of the Corpora API resource to delete.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaDeleteRequest(IGeminiCorpusResourceId resourceId, bool useBetaApi = true)
        {
            ResourceId = resourceId;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
