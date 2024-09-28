namespace Uralstech.UGemini.Models
{
    /// <summary>
    /// Requests metadata for all existing models. Return type is <see cref="GeminiModelListResponse"/>.
    /// </summary>
    public class GeminiModelListRequest : IGeminiGetRequest
    {
        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <summary>
        /// The maximum number of <see cref="GeminiModel"/>s to return (per page).
        /// </summary>
        /// <remarks>
        /// This method returns at most 1000 models per page, even if you pass a larger <see cref="MaxResponseModels"/>.
        /// </remarks>
        public int MaxResponseModels = 50;

        /// <summary>
        /// A page token from a previous <see cref="GeminiModelListRequest"/> call.
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
                ? $"{GeminiManager.BaseServiceUri}/{ApiVersion}/models?pageSize={MaxResponseModels}"
                : $"{GeminiManager.BaseServiceUri}/{ApiVersion}/models?pageSize={MaxResponseModels}&pageToken={PageToken}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiModelListRequest"/>.
        /// </summary>
        /// <remarks>
        /// Some newer models do not work with this request unless through the Beta API.
        /// </remarks>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiModelListRequest(bool useBetaApi = false)
        {
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
