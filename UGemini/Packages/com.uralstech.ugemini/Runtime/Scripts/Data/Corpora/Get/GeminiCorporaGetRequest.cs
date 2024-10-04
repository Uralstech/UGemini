namespace Uralstech.UGemini.CorporaAPI
{
    /// <summary>
    /// Gets information about a specific Corpora API resource. Response type can be <see cref="GeminiCorpus"/>,
    /// <see cref="Documents.GeminiCorpusDocument"/> or <see cref="Chunks.GeminiCorpusChunk"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiCorporaGetRequest : IGeminiGetRequest
    {
        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <summary>
        /// The ID of the resource to get.
        /// </summary>
        public IGeminiCorpusResourceId ResourceId;

        /// <inheritdoc/>
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.OAuthAccessToken;

        /// <inheritdoc/>
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/{ResourceId.ResourceName}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaGetRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="resourceId">The ID of the resource to get.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaGetRequest(IGeminiCorpusResourceId resourceId, bool useBetaApi = true)
        {
            ResourceId = resourceId;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
