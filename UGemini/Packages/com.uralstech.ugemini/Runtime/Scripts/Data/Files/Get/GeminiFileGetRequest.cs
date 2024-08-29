namespace Uralstech.UGemini.FileAPI
{
    /// <summary>
    /// Requests metadata for an existing file. Return type is <see cref="GeminiFile"/>.
    /// </summary>
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

        /// <inheritdoc>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"https://generativelanguage.googleapis.com/{ApiVersion}/files/{FileId}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiFileGetRequest"/>.
        /// </summary>
        /// <param name="fileNameOrId">The name (format 'files/{fileId}') or ID of the file to get.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiFileGetRequest(string fileNameOrId, bool useBetaApi = true)
        {
            FileId = fileNameOrId.Split('/')[^1];
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
