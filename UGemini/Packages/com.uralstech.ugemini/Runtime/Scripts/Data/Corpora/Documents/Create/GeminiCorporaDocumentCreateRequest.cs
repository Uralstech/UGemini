using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

namespace Uralstech.UGemini.CorporaAPI.Documents
{
    /// <summary>
    /// Creates an empty Document. Response type is <see cref="GeminiCorpusDocument"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorporaDocumentCreateRequest : IGeminiPostRequest
    {
        /// <summary>
        /// The Document resource name.
        /// </summary>
        /// <remarks>
        /// The ID (name excluding the "corpora/*/documents/" prefix) can contain up to 40 characters that are lowercase alphanumeric<br/>
        /// or dashes (-). The ID cannot start or end with a dash. If the name is empty on create, a unique name will be derived from<br/>
        /// displayName along with a 12 character random suffix. Example: corpora/{corpus_id}/documents/my-awesome-doc-123a456b789c
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string Name = null;

        /// <summary>
        /// The human-readable display name for the Document.
        /// </summary>
        /// <remarks>
        /// The display name must be no more than 512 characters in length, including spaces. Example: "Semantic Retriever Documentation"
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string DisplayName = null;

        /// <summary>
        /// User provided custom metadata stored as key-value pairs used for querying. A Document can have a maximum of 20 CustomMetadata.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiCorpusCustomMetadata[] CustomMetadata = null;

        /// <summary>
        /// The API version to use.
        /// </summary>
        [JsonIgnore]
        public string ApiVersion;

        /// <summary>
        /// The ID of the Corpus to create the Document in.
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
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/corpora/{CorpusId}/documents";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaDocumentCreateRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="corpusNameOrId">The name (format 'corpora/{corpusId}') or ID of the Corpus to create the document in.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaDocumentCreateRequest(string corpusNameOrId, bool useBetaApi = true)
        {
            CorpusId = corpusNameOrId.Split('/')[^1];
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaDocumentCreateRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="corpusNameOrId">The name (format 'corpora/{corpusId}') or ID of the Corpus to create the Document in.</param>
        /// <param name="documentNameOrId">The name (format 'corpora/{corpusId}/documents/{documentId}') or ID of the Document to create.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaDocumentCreateRequest(string corpusNameOrId, string documentNameOrId, bool useBetaApi = true)
        {
            CorpusId = corpusNameOrId.Split('/')[^1];
            Name = $"corpora/{CorpusId}/documents/{documentNameOrId.Split("/")[^1]}";

            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
