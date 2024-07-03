namespace Uralstech.UGemini.FileAPI
{
    /// <summary>
    /// Requests the deletion of a file.
    /// </summary>
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

        /// <inheritdoc>
        public string EndpointUri => $"https://generativelanguage.googleapis.com/{ApiVersion}/files/{FileId}";

        /// <summary>
        /// Creates a new <see cref="GeminiFileGetRequest"/>.
        /// </summary>
        /// <param name="fileId">The ID of the file to delete.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiFileDeleteRequest(string fileId, bool useBetaApi = true)
        {
            FileId = fileId;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
