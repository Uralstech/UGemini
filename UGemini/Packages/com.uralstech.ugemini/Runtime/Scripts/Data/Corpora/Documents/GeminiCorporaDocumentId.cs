namespace Uralstech.UGemini.CorporaAPI.Documents
{
    /// <summary>
    /// A Document is a collection of Chunks. A Corpus can have a maximum of 10,000 Documents.
    /// </summary>
    public class GeminiCorpusDocumentId : IGeminiCorpusResourceId
    {
        /// <summary>
        /// The ID of the Corpus which contains this Document.
        /// </summary>
        public string CorpusId;

        /// <summary>
        /// The ID of the Document.
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// The resource name of this Document (format 'corpora/{corpusId}/documents/{documentId}').
        /// </summary>
        public string ResourceName => $"corpora/{CorpusId}/documents/{ResourceId}";

        /// <summary>
        /// Creates a new <see cref="GeminiCorpusDocumentId"/>.
        /// </summary>
        /// <param name="documentName">The name (format 'corpora/{corpusId}/documents/{documentId}') of the Document.</param>
        public GeminiCorpusDocumentId(string documentName)
        {
            string[] parts = documentName.Split('/');
            (CorpusId, ResourceId) = (parts[1], parts[3]);
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorpusDocumentId"/>.
        /// </summary>
        /// <param name="corpusId">The resource ID of the Corpus which contains the Document.</param>
        /// <param name="documentNameOrId">The name (format 'corpora/{corpusId}/documents/{documentId}') or ID of the Document.</param>
        public GeminiCorpusDocumentId(GeminiCorpusId corpusId, string documentNameOrId)
        {
            CorpusId = corpusId.ResourceId;
            ResourceId = documentNameOrId.Split('/')[^1];
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorpusDocumentId"/>.
        /// </summary>
        /// <param name="documentName">The name (format 'corpora/{corpusId}/documents/{documentId}') of the Document.</param>
        public static explicit operator GeminiCorpusDocumentId(string documentName)
        {
            return new(documentName);
        }
    }
}