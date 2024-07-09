namespace Uralstech.UGemini
{
    /// <summary>
    /// All Gemini API POST requests must inherit from this interface.
    /// </summary>
    public interface IGeminiPostRequest : IGeminiRequest
    {
        /// <summary>
        /// The MIME type of the request content.
        /// </summary>
        public string ContentType { get; }

        /// <summary>
        /// Converts the request object to a UTF-8 encoded <see cref="string"/>.
        /// </summary>
        /// <returns>The string data.</returns>
        public string GetUtf8EncodedData();
    }
}
