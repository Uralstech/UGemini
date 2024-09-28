
using Newtonsoft.Json;

namespace Uralstech.UGemini.Models.Caching
{
    /// <summary>
    /// Creates a <see cref="GeminiCachedContent"/> resource. Response type is <see cref="GeminiCachedContent"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiCachedContentCreateRequest : IGeminiPostRequest
    {
        /// <summary>
        /// The content to be cached.
        /// </summary>
        public GeminiCachedContentCreationData Content;

        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <inheritdoc/>
        public string ContentType => GeminiContentType.ApplicationJSON.MimeType();

        /// <inheritdoc/>
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.APIKey;

        /// <inheritdoc/>
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/cachedContents";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCachedContentCreateRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="content">The content to cache.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCachedContentCreateRequest(GeminiCachedContentCreationData content, bool useBetaApi = true)
        {
            Content = content;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(Content);
        }
    }
}