using Newtonsoft.Json;

namespace Uralstech.UGemini.Models.Caching
{
    /// <summary>
    /// Patches a <see cref="GeminiCachedContent"/> resource.
    /// </summary>
    public class GeminiCachedContentPatchRequest : IGeminiPatchRequest
    {
        /// <summary>
        /// The patch content.
        /// </summary>
        public GeminiCachedContent Content;

        /// <summary>
        /// The ID of the cached content.
        /// </summary>
        public string ContentId;

        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <inheritdoc/>
        public string ContentType => GeminiContentType.ApplicationJSON.MimeType();

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"https://generativelanguage.googleapis.com/{ApiVersion}/cachedContents/{ContentId}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCachedContentPatchRequest"/>.
        /// </summary>
        /// <param name="content">The patch content.</param>
        /// <param name="cachedContentIdOrName">The ID or name (format cachedContents/{contentId}) of the cached content to patch.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCachedContentPatchRequest(GeminiCachedContent content, string cachedContentIdOrName, bool useBetaApi = false)
        {
            Content = content;
            ContentId = cachedContentIdOrName.Split('/')[^1];
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(Content);
        }
    }
}