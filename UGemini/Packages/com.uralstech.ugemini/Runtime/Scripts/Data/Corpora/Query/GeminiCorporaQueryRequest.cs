using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using Uralstech.UGemini.CorporaAPI.Filters;

namespace Uralstech.UGemini.CorporaAPI
{
    /// <summary>
    /// Performs semantic search over a Corpus or Document. Response type is <see cref="GeminiCorporaQueryResponse"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorporaQueryRequest : IGeminiPostRequest
    {
        /// <summary>
        /// Query string to perform semantic search.
        /// </summary>
        public string Query;

        /// <summary>
        /// Filter for Chunk and Document metadata.
        /// </summary>
        /// <remarks>
        /// Each <see cref="GeminiMetadataFilter"/> object should correspond to a unique key. Multiple MetadataFilter objects are joined by logical "AND"s.
        /// <br/><br/>
        /// Example query at document level:<br/>
        /// (year &gt;= 2020 OR year &lt; 2010) AND (genre = drama OR genre = action)<br/>
        /// Note: Document-level filtering is not supported for query requests on Documents because a Document name is already specified.
        /// <br/><br/>
        /// MetadataFilter object list:<br/>
        /// MetadataFilters = [{Key = "document.custom_metadata.year", Conditions = [{NumericValue = 2020, Operation = GreaterThanOrEqual}, {NumericValue = 2010, Operation = LessThan<br/>
        /// }]}, {Key = "document.custom_metadata.year", Conditions = [{NumericValue = 2020, Operation = GreaterThanOrEqual}, {NumericValue = 2010, Operation = LessThan}]}, {Key =<br/>
        /// "document.custom_metadata.genre", Conditions = [{StringValue = "drama", Operation = Equal}, {StringValue = "action", Operation = Equal}]}]
        /// <br/><br/>
        /// Example query at chunk level for a numeric range of values:<br/>
        /// (year &gt; 2015 AND year &lt;= 2020)
        /// <br/><br/>
        /// MetadataFilter object list:<br/>
        /// metadataFilters = [{Key = "chunk.custom_metadata.year", Conditions = [{NumericValue = 2015, Operation = GreaterThan}]}, {Key = "chunk.custom_metadata.year"<br/>
        /// Conditions = [{NumericValue = 2020, Operation = LessThanOrEqual}]}]
        /// <br/><br/>
        /// Note: "AND"s for the same Key are only supported for numeric values. String values only support "OR"s for the same Key.
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
        /// The resource ID of the Corpus or Document to query.
        /// </summary>
        [JsonIgnore]
        public IGeminiCorpusResourceId ResourceId;

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
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/{ResourceId.ResourceName}:query";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaQueryRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="resourceId">The resource ID of the Corpus or Document to Query.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaQueryRequest(IGeminiCorpusResourceId resourceId, bool useBetaApi = true)
        {
            ResourceId = resourceId;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
