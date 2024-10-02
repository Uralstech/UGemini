using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using Uralstech.UGemini.CorporaAPI.Filters;

namespace Uralstech.UGemini.CorporaAPI.Documents
{
    /// <summary>
    /// Performs semantic search over a Document. Response type is <see cref="GeminiCorporaQueryResponse"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorporaDocumentQueryRequest : IGeminiPostRequest
    {
        /// <summary>
        /// Query string to perform semantic search.
        /// </summary>
        public string Query;

        /// <summary>
        /// Filter for Chunk metadata.
        /// </summary>
        /// <remarks>
        /// Each <see cref="GeminiMetadataFilter"/> object should correspond to a unique key. Multiple MetadataFilter objects are joined by logical "AND"s.
        /// <br/>
        /// Note: Document-level filtering is not supported for this request because a Document name is already specified.
        /// <br/><br/>
        /// Example query:<br/>
        /// (year &gt;= 2020 OR year &lt; 2010) AND (genre = drama OR genre = action)
        /// <br/><br/>
        /// MetadataFilter object list:<br/>
        /// MetadataFilters = [{Key = "chunk.custom_metadata.year", Conditions = [{NumericValue = 2020, Operation = GreaterThanOrEqual}, {NumericValue = 2010,<br/>
        /// Operation = LessThan}}, {Key = "chunk.custom_metadata.genre", Conditions = [{StringValue = "drama", Operation = Equal}, {StringValue = "action",<br/>
        /// Operation = Equal}}]
        /// <br/><br/>
        /// Example query for a numeric range of values:<br/>
        /// (year &gt; 2015 AND year &lt;= 2020)
        /// <br/><br/>
        /// MetadataFilter object list:<br/>
        /// MetadataFilters = [{Key = "chunk.custom_metadata.year", Conditions = [{NumericValue = 2015, Operation = GreaterThan}]},<br/>
        /// {Key = "chunk.custom_metadata.year", Conditions = [{NumericValue = 2020, Operation = LessThanOrEqual}]}]
        /// <br/><br/>
        /// Note: "AND"s for the same key are only supported for numeric values. String values only support "OR"s for the same key.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiMetadataFilter[] MetadataFilters;

        /// <summary>
        /// The maximum number of Chunks to return. The service may return fewer Chunks.
        /// </summary>
        /// <remarks>
        /// If unspecified, at most 10 Chunks will be returned. The maximum specified result count is 100.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(-1)]
        public int ResultsCount = -1;

        /// <summary>
        /// The API version to use.
        /// </summary>
        [JsonIgnore]
        public string ApiVersion;

        /// <summary>
        /// The ID of the Corpus which contains the Document to query.
        /// </summary>
        [JsonIgnore]
        public string CorpusId;

        /// <summary>
        /// The ID of the Document to query.
        /// </summary>
        [JsonIgnore]
        public string DocumentId;

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
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/corpora/{CorpusId}/documents/{DocumentId}:query";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaDocumentQueryRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="documentName">The name (format 'corpora/{corpusId}/documents/{documentId}') of the Document to query.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaDocumentQueryRequest(string documentName, bool useBetaApi = true)
        {
            string[] parts = documentName.Split('/');
            (CorpusId, DocumentId) = (parts[1], parts[3]);

            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaDocumentQueryRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="corpusNameOrId">The name (format 'corpora/{corpusId}') or ID of the Corpus which contains the Document to query.</param>
        /// <param name="documentNameOrId">The name (format 'corpora/{corpusId}/documents/{documentId}') or ID of the Document to query.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaDocumentQueryRequest(string corpusNameOrId, string documentNameOrId, bool useBetaApi = true)
        {
            CorpusId = corpusNameOrId.Split('/')[^1];
            DocumentId = documentNameOrId.Split('/')[^1];
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
