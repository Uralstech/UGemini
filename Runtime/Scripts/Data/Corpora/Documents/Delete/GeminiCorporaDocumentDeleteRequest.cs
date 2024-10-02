namespace Uralstech.UGemini.CorporaAPI.Documents
{
    /// <summary>
    /// Deletes a Document.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiCorporaDocumentDeleteRequest : IGeminiDeleteRequest
    {
        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <summary>
        /// The ID of the Corpus which contains the Document to delete.
        /// </summary>
        public string CorpusId;

        /// <summary>
        /// The ID of the Document to delete.
        /// </summary>
        public string DocumentId;

        /// <summary>
        /// If set to <see langword="true"/>, any Chunks and objects related to this Document will also be deleted. If <see langword="false"/>, a FAILED_PRECONDITION error will be returned if Document contains any Chunks.
        /// </summary>
        public bool ForceDelete = false;

        /// <inheritdoc/>
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.OAuthAccessToken;

        /// <inheritdoc/>
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/corpora/{CorpusId}/documents/{DocumentId}?force={ForceDelete}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaDocumentDeleteRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="documentName">The name (format 'corpora/{corpusId}/documents/{documentId}') of the Document to delete.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaDocumentDeleteRequest(string documentName, bool useBetaApi = true)
        {
            string[] parts = documentName.Split('/');
            (CorpusId, DocumentId) = (parts[1], parts[3]);

            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaDocumentDeleteRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="corpusNameOrId">The name (format 'corpora/{corpusId}') or ID of the Corpus which contains the Document to delete.</param>
        /// <param name="documentNameOrId">The name (format 'corpora/{corpusId}/documents/{documentId}') or ID of the Document to delete.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaDocumentDeleteRequest(string corpusNameOrId, string documentNameOrId, bool useBetaApi = true)
        {
            CorpusId = corpusNameOrId.Split('/')[^1];
            DocumentId = documentNameOrId.Split('/')[^1];
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
