namespace Uralstech.UGemini.CorporaAPI
{
    /// <summary>
    /// Deletes a Corpus.
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
        /// The ID of the Corpus to delete.
        /// </summary>
        public string CorpusId;

        /// <summary>
        /// If set to <see langword="true"/>, any Documents and objects related to this Corpus will also be deleted. If <see langword="false"/>, a FAILED_PRECONDITION error will be returned if the Corpus contains any Documents.
        /// </summary>
        public bool ForceDelete = false;

        /// <inheritdoc/>
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.OAuthAccessToken;

        /// <inheritdoc/>
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/corpora/{CorpusId}?force={ForceDelete}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaDeleteRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="corpusNameOrId">The name (format 'corpora/{corpusId}') or ID of the Corpus to delete.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaDeleteRequest(string corpusNameOrId, bool useBetaApi = true)
        {
            CorpusId = corpusNameOrId.Split('/')[^1];
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
