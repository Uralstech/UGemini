namespace Uralstech.UGemini.Models.Caching
{
    /// <summary>
    /// Requests for deletion of a cached content resource.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiCachedContentDeleteRequest : IGeminiDeleteRequest
    {
        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <summary>
        /// The ID of the cached content.
        /// </summary>
        public string ContentId;

        /// <inheritdoc/>
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.APIKey;

        /// <inheritdoc/>
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/cachedContents/{ContentId}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCachedContentDeleteRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="cachedContentIdOrName">The ID or name (format cachedContents/{contentId}) of the cached content to delete.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCachedContentDeleteRequest(string cachedContentIdOrName, bool useBetaApi = true)
        {
            ContentId = cachedContentIdOrName.Split('/')[^1];
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
