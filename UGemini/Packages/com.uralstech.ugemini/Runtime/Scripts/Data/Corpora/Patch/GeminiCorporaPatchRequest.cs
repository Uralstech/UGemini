using Newtonsoft.Json;

namespace Uralstech.UGemini.CorporaAPI
{
    /// <summary>
    /// Updates a Corpus. Response type is <see cref="GeminiCorpus"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiCorporaPatchRequest : IGeminiPatchRequest
    {
        /// <summary>
        /// The patch data.
        /// </summary>
        public GeminiCorpusPatchData Patch;

        /// <summary>
        /// The ID of the Corpus to patch.
        /// </summary>
        public string CorpusId;

        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <inheritdoc/>
        public string ContentType => GeminiContentType.ApplicationJSON.MimeType();

        /// <inheritdoc/>
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.OAuthAccessToken;

        /// <inheritdoc/>
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/corpora/{CorpusId}?updateMask={Patch.GetFieldMask()}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaPatchRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="patch">The patch data.</param>
        /// <param name="corpusNameOrId">The name (format 'corpora/{corpusId}') or ID of the Corpus to patch.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaPatchRequest(GeminiCorpusPatchData patch, string corpusNameOrId, bool useBetaApi = true)
        {
            Patch = patch;
            CorpusId = corpusNameOrId.Split('/')[^1];
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(Patch);
        }
    }
}