namespace Uralstech.UGemini.FileAPI
{
    /// <summary>
    /// Requests metadata for all existing files. Return type is <see cref="GeminiFileListResponse"/>.
    /// </summary>
    public class GeminiFileListRequest : IGeminiGetRequest
    {
        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <summary>
        /// Maximum number of Files to return per page. If unspecified, defaults to 10. Maximum pageSize is 100.
        /// </summary>
        public int MaxResponseFiles = 10;

        /// <summary>
        /// A page token from a previous files.list call.
        /// </summary>
        public string PageToken = string.Empty;

        /// <inheritdoc>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return string.IsNullOrEmpty(PageToken)
                ? $"https://generativelanguage.googleapis.com/{ApiVersion}/files?pageSize={MaxResponseFiles}"
                : $"https://generativelanguage.googleapis.com/{ApiVersion}/files?pageSize={MaxResponseFiles}&pageToken={PageToken}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiFileGetRequest"/>.
        /// </summary>
        /// <param name="fileId">The ID of the file to get.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiFileListRequest(bool useBetaApi = true)
        {
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
