using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using Uralstech.UGemini.CorporaAPI.Filters;

namespace Uralstech.UGemini.CorporaAPI
{
    /// <summary>
    /// Performs semantic search over a Corpus. Response type is <see cref="GeminiCorporaQueryResponse"/>.
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
        /// (year &gt;= 2020 OR year &lt; 2010) AND (genre = drama OR genre = action)
        /// <br/><br/>
        /// MetadataFilter object list:<br/>
        /// MetadataFilters = [{Key = "document.custom_metadata.year", Conditions = [{NumericValue = 2020, operation = GreaterThanOrEqual}, {NumericValue = 2010, operation = LessThan<br/>
        /// }]}, {Key = "document.custom_metadata.year" Conditions = [{NumericValue = 2020, operation = GreaterThanOrEqual}, {NumericValue = 2010, operation = LessThan}]}, {Key =<br/>
        /// "document.custom_metadata.genre" Conditions = [{StringValue = "drama", operation = Equal}, {StringValue = "action", operation = Equal}]}]
        /// <br/><br/>
        /// Example query at chunk level for a numeric range of values:<br/>
        /// (year &gt; 2015 AND year &lt;= 2020)
        /// <br/><br/>
        /// MetadataFilter object list:<br/>
        /// metadataFilters = [{Key = "chunk.custom_metadata.year" Conditions = [{NumericValue = 2015, operation = GreaterThan}]}, {Key = "chunk.custom_metadata.year"<br/>
        /// Conditions = [{NumericValue = 2020, operation = LessThanOrEqual}]}]
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
        /// The ID of the Corpus to query.
        /// </summary>
        [JsonIgnore]
        public string CorpusId;

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
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/corpora/{CorpusId}:query";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaQueryRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="corpusNameOrId">The name (format 'corpora/{corpusId}') or ID of the Corpus to query.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaQueryRequest(string corpusNameOrId, bool useBetaApi = true)
        {
            CorpusId = corpusNameOrId.Split('/')[^1];
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
