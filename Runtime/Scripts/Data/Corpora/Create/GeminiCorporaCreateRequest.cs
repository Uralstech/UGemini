using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

namespace Uralstech.UGemini.CorporaAPI
{
    /// <summary>
    /// Creates an empty Corpus. Response type is <see cref="GeminiCorpus"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorporaCreateRequest : IGeminiPostRequest
    {
        /// <summary>
        /// The Corpus resource name.
        /// </summary>
        /// <remarks>
        /// The ID (name excluding the "corpora/" prefix) can contain up to 40 characters that are lowercase alphanumeric or dashes (-).<br/>
        /// The ID cannot start or end with a dash. If the name is empty on create, a unique name will be derived from displayName along<br/>
        /// with a 12 character random suffix. Example: corpora/my-awesome-corpora-123a456b789c
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string Name = null;

        /// <summary>
        /// The human-readable display name for the Corpus.
        /// </summary>
        /// <remarks>
        /// The display name must be no more than 512 characters in length, including spaces. Example: "Docs on Semantic Retriever"
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string DisplayName = null;

        /// <summary>
        /// The API version to use.
        /// </summary>
        [JsonIgnore]
        public string ApiVersion;

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
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/corpora";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaCreateRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaCreateRequest(bool useBetaApi = true)
        {
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaCreateRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="corpusNameOrId">The name (format 'corpora/{corpusId}') or ID of the Corpus to create.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaCreateRequest(string corpusNameOrId, bool useBetaApi = true)
        {
            Name = $"corpora/{corpusNameOrId.Split('/')[^1]}";
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
