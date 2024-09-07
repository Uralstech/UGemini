namespace Uralstech.UGemini.FileAPI
{
    /// <summary>
    /// Requests the deletion of a file.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiFileDeleteRequest : IGeminiDeleteRequest
    {
        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <summary>
        /// The ID of the file to delete.
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
        /// Creates a new <see cref="GeminiFileDeleteRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="fileNameOrId">The name (format 'files/{fileId}') or ID of the file to delete.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiFileDeleteRequest(string fileNameOrId, bool useBetaApi = true)
        {
            FileId = fileNameOrId.Split('/')[^1];
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
