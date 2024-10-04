using Uralstech.UGemini.CorporaAPI.Documents;

namespace Uralstech.UGemini.CorporaAPI.Chunks
{
    /// <summary>
    /// A Chunk is a subpart of a Document that is treated as an independent unit for the purposes of vector<br/>
    /// representation and storage. A Corpus can have a maximum of 1 million Chunks.
    /// </summary>
    public class GeminiCorpusChunkId : IGeminiCorpusResourceId
    {
        /// <summary>
        /// The ID of the Corpus which contains this Chunk's parent Document.
        /// </summary>
        public string CorpusId;

        /// <summary>
        /// The ID of this Chunk's parent Document.
        /// </summary>
        public string DocumentId;

        /// <summary>
        /// The ID of the Chunk.
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// The resource name of this Chunk (format 'corpora/{corpusId}/documents/{documentId}/chunks/{chunkId}').
        /// </summary>
        public string ResourceName => $"corpora/{CorpusId}/documents/{DocumentId}/chunks/{ResourceId}";

        /// <summary>
        /// Creates a new <see cref="GeminiCorpusChunkId"/>.
        /// </summary>
        /// <param name="chunkName">The name (format 'corpora/{corpusId}/documents/{documentId}/chunks/{chunkId}') of the Chunk.</param>
        public GeminiCorpusChunkId(string chunkName)
        {
            string[] parts = chunkName.Split('/');
            (CorpusId, DocumentId, ResourceId) = (parts[1], parts[3], parts[5]);
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorpusChunkId"/>.
        /// </summary>
        /// <param name="documentId">The resource ID of the Documet which contains the Chunk.</param>
        /// <param name="chunkId">The ID of the Chunk.</param>
        public GeminiCorpusChunkId(GeminiCorpusDocumentId documentId, string chunkId)
        {
            (CorpusId, DocumentId) = (documentId.CorpusId, documentId.ResourceId);
            ResourceId = chunkId;
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorpusChunkId"/>.
        /// </summary>
        /// <param name="chunkName">The name (format 'corpora/{corpusId}/documents/{documentId}/chunks/{chunkId}') of the Chunk.</param>
        public static explicit operator GeminiCorpusChunkId(string chunkName)
        {
            return new(chunkName);
        }
    }
}