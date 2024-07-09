namespace Uralstech.UGemini
{
    /// <summary>
    /// All Gemini API requests must inherit from this interface.
    /// </summary>
    public interface IGeminiRequest
    {
        /// <summary>
        /// Gets the URI to the API endpoint.
        /// </summary>
        /// <param name="metadata">The metadata of the request to be carried out on the URI.</param>
        /// <returns>The URI.</returns>
        public string GetEndpointUri(GeminiRequestMetadata metadata);
    }
}
