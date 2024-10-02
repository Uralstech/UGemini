namespace Uralstech.UGemini.CorporaAPI
{
    /// <summary>
    /// Lists all Corpora owned by the user. Response type is <see cref="GeminiCorporaListResponse"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiCorporaListRequest : IGeminiGetRequest
    {
        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <summary>
        /// Maximum number of Corpora to return per page. If unspecified, defaults to 10. Maximum is 20.
        /// </summary>
        public int MaxResponseCorpora = 10;

        /// <summary>
        /// A page token from a previous <see cref="GeminiCorporaListRequest"/> call.
        /// </summary>
        public string PageToken = string.Empty;

        /// <inheritdoc/>
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.OAuthAccessToken;

        /// <inheritdoc/>
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return string.IsNullOrEmpty(PageToken)
                ? $"{GeminiManager.BaseServiceUri}/{ApiVersion}/corpora?pageSize={MaxResponseCorpora}"
                : $"{GeminiManager.BaseServiceUri}/{ApiVersion}/corpora?pageSize={MaxResponseCorpora}&pageToken={PageToken}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaListRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaListRequest(bool useBetaApi = true)
        {
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
