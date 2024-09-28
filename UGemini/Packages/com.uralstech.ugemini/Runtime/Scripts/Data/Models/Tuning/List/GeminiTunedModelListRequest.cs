namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// Requests metadata for all existing tuned models. Return type is <see cref="GeminiTunedModelListResponse"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiTunedModelListRequest : IGeminiGetRequest
    {
        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <summary>
        /// Simple filter to get models by account authorizations.
        /// </summary>
        public GeminiTunedModelListFilter Filter;

        /// <summary>
        /// The maximum number of <see cref="GeminiTunedModel"/>s to return (per page).
        /// </summary>
        /// <remarks>
        /// This method returns at most 1000 models per page, even if you pass a larger <see cref="MaxResponseModels"/>.
        /// </remarks>
        public int MaxResponseModels = 50;

        /// <summary>
        /// A page token from a previous <see cref="GeminiTunedModelListRequest"/> call.
        /// </summary>
        public string PageToken = string.Empty;

        /// <inheritdoc/>
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.OAuthAccessToken;

        /// <inheritdoc/>
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            string uri = Filter == GeminiTunedModelListFilter.None
                ? $"{GeminiManager.BaseServiceUri}/{ApiVersion}/tunedModels?pageSize={MaxResponseModels}"
                : $"{GeminiManager.BaseServiceUri}/{ApiVersion}/tunedModels?filter={Filter.EnumMemberValue()}&pageSize={MaxResponseModels}";

            if (!string.IsNullOrEmpty(PageToken))
                uri += $"&pageToken={PageToken}";
            return uri;
        }

        /// <summary>
        /// Creates a new <see cref="GeminiTunedModelListRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiTunedModelListRequest(bool useBetaApi = true)
        {
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
