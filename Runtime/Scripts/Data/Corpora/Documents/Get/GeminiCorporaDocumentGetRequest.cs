namespace Uralstech.UGemini.CorporaAPI.Documents
{
    /// <summary>
    /// Gets information about a specific Document. Response type is <see cref="GeminiCorpusDocument"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiCorporaDocumentGetRequest : IGeminiGetRequest
    {
        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <summary>
        /// The ID of the Corpus which contains the Document to get.
        /// </summary>
        public string CorpusId;

        /// <summary>
        /// The ID of the Document to get.
        /// </summary>
        public string DocumentId;

        /// <inheritdoc/>
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.OAuthAccessToken;

        /// <inheritdoc/>
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/corpora/{CorpusId}/documents/{DocumentId}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaDocumentGetRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="documentName">The name (format 'corpora/{corpusId}/documents/{documentId}') of the Document to get.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaDocumentGetRequest(string documentName, bool useBetaApi = true)
        {
            string[] parts = documentName.Split('/');
            (CorpusId, DocumentId) = (parts[1], parts[3]);

            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaDocumentGetRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="corpusNameOrId">The name (format 'corpora/{corpusId}') or ID of the Corpus which contains the Document to get.</param>
        /// <param name="documentNameOrId">The name (format 'corpora/{corpusId}/documents/{documentId}') or ID of the Document to get.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaDocumentGetRequest(string corpusNameOrId, string documentNameOrId, bool useBetaApi = true)
        {
            CorpusId = corpusNameOrId.Split('/')[^1];
            DocumentId = documentNameOrId.Split('/')[^1];
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
