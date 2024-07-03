using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Status
{
    /// <summary>
    /// The <see cref="GeminiStatus"/> type defines a logical error model that is suitable for different programming environments, including REST APIs and RPC APIs. It is used by gRPC.
    /// </summary>
    /// <remarks>
    /// Each <see cref="GeminiStatus"/> message contains three pieces of data: error code, error message, and error details.
    /// </remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiStatus
    {
        /// <summary>
        /// The status code, which should be an enum value of google.rpc.Code.
        /// </summary>
        public int Code;

        /// <summary>
        /// A developer-facing error message, which should be in English.
        /// </summary>
        /// <remarks>
        /// Any user-facing error message should be localized and sent in the google.rpc.Status.details field, or localized by the client.
        /// </remarks>
        public string Message;

        /// <summary>
        /// A list of messages that carry the error details. There is a common set of message types for APIs to use.
        /// </summary>
        public GeminiStatusDetails[] Details;
    }
}
