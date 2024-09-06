using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Uralstech.UGemini.Status;

namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// The response type for a <see cref="GeminiTunedModelCreateRequest"/>.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiTunedModelCreateResponse
    {
        /// <summary>
        /// The server-assigned name, which is only unique within the same service that originally returns it.
        /// </summary>
        /// <remarks>
        /// If you use the default HTTP mapping, the name should be a resource name ending with operations/{unique_id}.
        /// </remarks>
        public string Name;

        /// <summary>
        /// Service-specific metadata associated with the operation. It typically contains progress information and common metadata such as create time.<br/>
        /// Some services might not provide such metadata. Any method that returns a long-running operation should document the metadata type, if any.
        /// </summary>
        /// <remarks>
        /// An object containing fields of an arbitrary type. An additional field <see cref="GeminiStatusDetails.Type"/> contains a URI identifying the type.<br/>
        /// Example: { "id": 1234, "@type": "types.example.com/standard/id" }. Here, "@type" would be populated as <see cref="GeminiStatusDetails.Type"/> and<br/>
        /// "id" as a field in <see cref="GeminiStatusDetails.Data"/>.
        /// </remarks>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GeminiTunedModelCreationOperationMetadata Metadata = null;

        /// <summary>
        /// If the value is false, it means the operation is still in progress. If true, the operation is completed, and either error or response is available.
        /// </summary>
        public bool Done;

        /// <summary>
        /// The error result of the operation in case of failure or cancellation.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GeminiStatus Error = null;

        /// <summary>
        /// The normal, successful response of the operation.
        /// </summary>
        /// <remarks>
        /// If the original method returns no data on success, such as Delete, the response is google.protobuf.Empty. If the original method is standard Get/Create/Update,<br/>
        /// the response should be the resource. For other methods, the response should have the type XxxResponse, where Xxx is the original method name. For example, if<br/>
        /// the original method name is TakeSnapshot(), the inferred response type is TakeSnapshotResponse.
        /// <br/><br/>
        /// An object containing fields of an arbitrary type.An additional field "@type" contains a URI identifying the type. Example:<br/>
        /// { "id": 1234, "@type": "types.example.com/standard/id" }. Here, "@type" would be populated as <see cref="GeminiStatusDetails.Type"/> and<br/>
        /// "id" as a field in <see cref="GeminiStatusDetails.Data"/>.
        /// "id" as a field in <see cref="GeminiStatusDetails.Data"/>.
        /// </remarks>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GeminiStatusDetails Response = null;
    }
}