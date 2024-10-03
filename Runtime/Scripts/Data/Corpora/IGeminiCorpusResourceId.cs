namespace Uralstech.UGemini.CorporaAPI
{
    /// <summary>
    /// Any object stand-in for a Corpus resource ID should inherit this interface.
    /// </summary>
    public interface IGeminiCorpusResourceId
    {
        /// <summary>
        /// The ID of the resource.
        /// </summary>
        public string ResourceId { get; }

        /// <summary>
        /// The full name of the resource.
        /// </summary>
        public string ResourceName { get; }
    }
}