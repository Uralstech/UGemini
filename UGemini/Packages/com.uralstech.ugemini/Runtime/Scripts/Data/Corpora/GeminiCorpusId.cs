namespace Uralstech.UGemini.CorporaAPI
{
    /// <summary>
    /// A Corpus is a collection of Documents. A project can create up to 5 corpora.
    /// </summary>
    public class GeminiCorpusId : IGeminiCorpusResourceId
    {
        /// <summary>
        /// The ID of the Corpus.
        /// </summary>
        public string ResourceId { get; }

        /// <summary>
        /// The name (format 'corpora/{corpusId}') of the Corpus.
        /// </summary>
        public string ResourceName => $"corpora/{ResourceId}";

        /// <summary>
        /// Creates a new <see cref="GeminiCorpusId"/>.
        /// </summary>
        /// <param name="corpusNameOrId">The name (format 'corpora/{corpusId}') or ID of the Corpus.</param>
        public GeminiCorpusId(string corpusNameOrId)
        {
            ResourceId = corpusNameOrId.Split('/')[^1];
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorpusId"/>.
        /// </summary>
        /// <param name="corpusNameOrId">The name (format 'corpora/{corpusId}') or ID of the Corpus.</param>
        public static explicit operator GeminiCorpusId(string corpusNameOrId)
        {
            return new(corpusNameOrId);
        }
    }
}