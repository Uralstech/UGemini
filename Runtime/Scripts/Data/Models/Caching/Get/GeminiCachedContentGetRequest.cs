namespace Uralstech.UGemini.Models.Caching
{
    /// <summary>
    /// Requests metadata cached content. Return type is <see cref="GeminiCachedContent"/>.
    /// </summary>
    public class GeminiCachedContentGetRequest : IGeminiGetRequest
    {
        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <summary>
        /// The ID of the cached content.
        /// </summary>
        public string ContentId;

        /// <inheritdoc>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"https://generativelanguage.googleapis.com/{ApiVersion}/cachedContents/{ContentId}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCachedContentGetRequest"/>.
        /// </summary>
        /// <param name="cachedContentIdOrName">The ID or name (format cachedContents/{contentId}) of the cached content to get.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCachedContentGetRequest(string cachedContentIdOrName, bool useBetaApi = false)
        {
            ContentId = cachedContentIdOrName.Split('/')[^1];
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
