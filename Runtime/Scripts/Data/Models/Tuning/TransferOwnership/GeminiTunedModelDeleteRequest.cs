using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// Transfers ownership of the tuned model. This is the only way to change ownership of the tuned model. The current owner will be downgraded to writer role. Does not return anything.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiTunedModelTransferOwnershipRequest : IGeminiPostRequest
    {
        /// <summary>
        /// The email address of the user to whom the tuned model is being transferred to.
        /// </summary>
        public string EmailAddress;

        /// <summary>
        /// The API version to use.
        /// </summary>
        [JsonIgnore]
        public string ApiVersion;

        /// <summary>
        /// The ID of the tuned model.
        /// </summary>
        [JsonIgnore]
        public GeminiModelId TunedModel;

        /// <inheritdoc>
        [JsonIgnore]
        public string ContentType => GeminiContentType.ApplicationJSON.MimeType();

        /// <inheritdoc>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"https://generativelanguage.googleapis.com/{ApiVersion}/{TunedModel.Name}:transferOwnership";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiTunedModelTransferOwnershipRequest"/>.
        /// </summary>
        /// <param name="tunedModel">The ID of the tuned model to transfer.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiTunedModelTransferOwnershipRequest(GeminiModelId tunedModel, bool useBetaApi = false)
        {
            TunedModel = tunedModel;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}