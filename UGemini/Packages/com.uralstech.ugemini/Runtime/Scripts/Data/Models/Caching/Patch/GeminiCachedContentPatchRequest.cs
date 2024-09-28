using Newtonsoft.Json;

namespace Uralstech.UGemini.Models.Caching
{
    /// <summary>
    /// Patches a <see cref="GeminiCachedContent"/> resource. Response type is <see cref="GeminiCachedContent"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiCachedContentPatchRequest : IGeminiPatchRequest
    {
        /// <summary>
        /// The patch data.
        /// </summary>
        public GeminiCachedContentPatchData Patch;

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
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.APIKey;

        /// <inheritdoc/>
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/cachedContents/{ContentId}?updateMask={Patch.GetFieldMask()}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCachedContentPatchRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="patch">The patch data.</param>
        /// <param name="cachedContentIdOrName">The ID or name (format cachedContents/{contentId}) of the cached content to patch.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCachedContentPatchRequest(GeminiCachedContentPatchData patch, string cachedContentIdOrName, bool useBetaApi = true)
        {
            Patch = patch;
            ContentId = cachedContentIdOrName.Split('/')[^1];
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(Patch);
        }
    }
}