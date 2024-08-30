
using Newtonsoft.Json;

namespace Uralstech.UGemini.Models.Caching
{
    /// <summary>
    /// Creates a <see cref="GeminiCachedContent"/> resource. Response type is <see cref="GeminiCachedContent"/>.
    /// </summary>
    public class GeminiCachedContentCreateRequest : IGeminiPostRequest
    {
        /// <summary>
        /// The content to be cached.
        /// </summary>
        public GeminiCachedContent Content;

        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <inheritdoc/>
        public string ContentType => GeminiContentType.ApplicationJSON.MimeType();

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"https://generativelanguage.googleapis.com/{ApiVersion}/cachedContents";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCachedContentCreateRequest"/>.
        /// </summary>
        /// <param name="content">The content to cache.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCachedContentCreateRequest(GeminiCachedContent content, bool useBetaApi = false)
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