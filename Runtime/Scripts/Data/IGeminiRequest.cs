namespace Uralstech.UGemini
{
    /// <summary>
    /// All Gemini API requests must inherit from this interface.
    /// </summary>
    public interface IGeminiRequest
    {
        /// <summary>
        /// The URI to the API endpoint.
        /// </summary>
        public string EndpointUri { get; }
    }
}
