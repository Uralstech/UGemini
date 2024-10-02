namespace Uralstech.UGemini.CorporaAPI.Documents
{
    /// <summary>
    /// Lists all Documents in a Corpus. Response type is <see cref="GeminiCorporaDocumentListResponse"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiCorporaDocumentListRequest : IGeminiGetRequest
    {
        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <summary>
        /// The ID of the Corpus which contains the Documents to list.
        /// </summary>
        public string CorpusId;

        /// <summary>
        /// The maximum number of Documents to return (per page). The service may return fewer Documents. If unspecified, defaults to 10. Maximum is 20.
        /// </summary>
        public int MaxResponseDocuments = 10;

        /// <summary>
        /// A page token from a previous <see cref="GeminiCorporaDocumentListRequest"/> call.
        /// </summary>
        public string PageToken = string.Empty;

        /// <inheritdoc/>
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.OAuthAccessToken;

        /// <inheritdoc/>
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return string.IsNullOrEmpty(PageToken)
                ? $"{GeminiManager.BaseServiceUri}/{ApiVersion}/corpora/{CorpusId}/documents?pageSize={MaxResponseDocuments}"
                : $"{GeminiManager.BaseServiceUri}/{ApiVersion}/corpora/{CorpusId}/documents?pageSize={MaxResponseDocuments}&pageToken={PageToken}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaDocumentListRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="corpusNameOrId">The name (format 'corpora/{corpusId}') or ID of the Corpus which contains the Documents to list.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaDocumentListRequest(string corpusNameOrId, bool useBetaApi = true)
        {
            CorpusId = corpusNameOrId.Split('/')[^1];
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
