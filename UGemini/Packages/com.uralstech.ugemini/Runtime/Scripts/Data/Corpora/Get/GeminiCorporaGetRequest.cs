namespace Uralstech.UGemini.CorporaAPI
{
    /// <summary>
    /// Gets information about a specific Corpus. Response type is <see cref="GeminiCorpus"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiCorporaGetRequest : IGeminiGetRequest
    {
        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <summary>
        /// The ID of the Corpus to get.
        /// </summary>
        public string CorpusId;

        /// <inheritdoc/>
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.OAuthAccessToken;

        /// <inheritdoc/>
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/corpora/{CorpusId}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaGetRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="corpusNameOrId">The name (format 'corpora/{corpusId}') or ID of the Corpus to get.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaGetRequest(string corpusNameOrId, bool useBetaApi = true)
        {
            CorpusId = corpusNameOrId.Split('/')[^1];
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
