using Newtonsoft.Json;

namespace Uralstech.UGemini.CorporaAPI.Documents
{
    /// <summary>
    /// Updates a Document. Response type is <see cref="GeminiCorpusDocument"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiCorporaDocumentPatchRequest : IGeminiPatchRequest
    {
        /// <summary>
        /// The patch data.
        /// </summary>
        public GeminiCorpusDocumentPatchData Patch;

        /// <summary>
        /// The ID of the Corpus which contains the Document to patch.
        /// </summary>
        public string CorpusId;

        /// <summary>
        /// The ID of the Document to patch.
        /// </summary>
        public string DocumentId;

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
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/corpora/{CorpusId}/documents/{DocumentId}?updateMask={Patch.GetFieldMask()}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaDocumentPatchRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="documentName">The name (format 'corpora/{corpusId}/documents/{documentId}') of the Document to patch.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaDocumentPatchRequest(string documentName, bool useBetaApi = true)
        {
            string[] parts = documentName.Split('/');
            (CorpusId, DocumentId) = (parts[1], parts[3]);

            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaDocumentPatchRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="corpusNameOrId">The name (format 'corpora/{corpusId}') or ID of the Corpus which contains the Document to patch.</param>
        /// <param name="documentNameOrId">The name (format 'corpora/{corpusId}/documents/{documentId}') or ID of the Document to patch.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaDocumentPatchRequest(string corpusNameOrId, string documentNameOrId, bool useBetaApi = true)
        {
            CorpusId = corpusNameOrId.Split('/')[^1];
            DocumentId = documentNameOrId.Split('/')[^1];
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(Patch);
        }
    }
}