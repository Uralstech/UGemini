namespace Uralstech.UGemini
{
    /// <summary>
    /// All Gemini API POST requests with multi-part data must inherit from this interface.
    /// </summary>
    public interface IGeminiMultiPartPostRequest : IGeminiRequest
    {
        /// <summary>
        /// Converts the request object to a UTF-8 encoded multi-part <see cref="string"/>.
        /// </summary>
        /// <param name="dataSeperator">The boundary to seperate each part of the data.</param>
        /// <returns>The string data.</returns>
        public string GetUtf8EncodedData(string dataSeperator);
    }
}
