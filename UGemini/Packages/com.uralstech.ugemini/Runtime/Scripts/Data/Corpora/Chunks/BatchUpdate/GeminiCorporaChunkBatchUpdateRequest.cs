using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Uralstech.UGemini.CorporaAPI.Documents;

namespace Uralstech.UGemini.CorporaAPI.Chunks
{
    /// <summary>
    /// Updates/patches multiple Chunk resources. Response type is <see cref="GeminiCorporaChunkBatchUpdateResponse"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorporaChunkBatchUpdateRequest : IGeminiPostRequest
    {
        /// <summary>
        /// The request messages specifying the Chunks to update. A maximum of 100 Chunks can be updated in a batch.
        /// </summary>
        public GeminiCorporaChunkBatchUpdateRequestPart[] Requests;

        /// <summary>
        /// The API version to use.
        /// </summary>
        [JsonIgnore]
        public string ApiVersion;

        /// <summary>
        /// Optional. The parent Document containing the Chunks to update.
        /// </summary>
        /// <remarks>
        /// If given, the parent field in every <see cref="GeminiCorporaChunkBatchUpdateRequestPart"/> must match this value.
        /// </remarks>
        [JsonIgnore]
        public GeminiCorpusDocumentId ParentDocumentId = null;

        /// <inheritdoc/>
        [JsonIgnore]
        public string ContentType => GeminiContentType.ApplicationJSON.MimeType();

        /// <inheritdoc/>
        [JsonIgnore]
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.OAuthAccessToken;

        /// <inheritdoc/>
        [JsonIgnore]
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            string parentDocument = ParentDocumentId != null ? $"/{ParentDocumentId.ResourceName}" : string.Empty;
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}{parentDocument}/chunks:batchUpdate";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaChunkBatchUpdateRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaChunkBatchUpdateRequest(bool useBetaApi = true)
        {
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
