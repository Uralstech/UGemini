namespace Uralstech.UGemini.FileAPI
{
    /// <summary>
    /// Requests metadata for an existing file. Return type is <see cref="GeminiFile"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiFileGetRequest : IGeminiGetRequest
    {
        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <summary>
        /// The ID of the file to get.
        /// </summary>
        public string FileId;

        /// <inheritdoc/>
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.APIKey;

        /// <inheritdoc/>
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/files/{FileId}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiFileGetRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="fileNameOrId">The name (format 'files/{fileId}') or ID of the file to get.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiFileGetRequest(string fileNameOrId, bool useBetaApi = true)
        {
            FileId = fileNameOrId.Split('/')[^1];
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
