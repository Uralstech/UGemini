namespace Uralstech.UGemini.Models.Caching
{
    /// <summary>
    /// Requests metadata for all existing cached content. Return type is <see cref="GeminiCachedContentListResponse"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiCachedContentListRequest : IGeminiGetRequest
    {
        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <summary>
        /// The maximum number of <see cref="GeminiCachedContent"/> objects to return (per page).
        /// </summary>
        /// <remarks>
        /// This method returns at most 1000 <see cref="GeminiCachedContent"/> objects per page, even if you pass a larger <see cref="MaxResponseContents"/>.
        /// </remarks>
        public int MaxResponseContents = 50;

        /// <summary>
        /// A page token from a previous <see cref="GeminiCachedContentListRequest"/> call.
        /// </summary>
        public string PageToken = string.Empty;

        /// <inheritdoc/>
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.APIKey;

        /// <inheritdoc/>
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return string.IsNullOrEmpty(PageToken)
                ? $"{GeminiManager.BaseServiceUri}/{ApiVersion}/cachedContents?pageSize={MaxResponseContents}"
                : $"{GeminiManager.BaseServiceUri}/{ApiVersion}/cachedContents?pageSize={MaxResponseContents}&pageToken={PageToken}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCachedContentListRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCachedContentListRequest(bool useBetaApi = true)
        {
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
