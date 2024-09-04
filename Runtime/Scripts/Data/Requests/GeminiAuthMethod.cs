namespace Uralstech.UGemini
{
    /// <summary>
    /// The preferred authentication method to use with the Gemini API.
    /// </summary>
    public enum GeminiAuthMethod
    {
        /// <summary>
        /// Use the provided API key.
        /// </summary>
        APIKey,

        /// <summary>
        /// Use an OAuth access token.
        /// </summary>
        OAuthAccessToken,
    }
}