using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.FileAPI
{
    /// <summary>
    /// Response for a file upload request.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiFileUploadResponse
    {
        /// <summary>
        /// Metadata for the created file.
        /// </summary>
        public GeminiFile File;
    }
}
