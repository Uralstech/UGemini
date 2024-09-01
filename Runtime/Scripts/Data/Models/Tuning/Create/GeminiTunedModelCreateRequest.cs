using Newtonsoft.Json;

namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// Creates a tuned model. Response type is <see cref="GeminiTunedModel"/>.
    /// </summary>
    public class GeminiTunedModelCreateRequest : IGeminiPostRequest
    {
        /// <summary>
        /// The tuned model to be created.
        /// </summary>
        public GeminiTunedModelCreationData Model;

        /// <summary>
        /// The unique id for the tuned model if specified.
        /// </summary>
        /// <remarks>
        /// This value should be up to 40 characters, the first character must be a letter, the last could<br/>
        /// be a letter or a number. The id must match the regular expression: <c>[a-z]([a-z0-9-]{0,38}[a-z0-9])?</c>.
        /// </remarks>
        public GeminiModelId ModelId = string.Empty;

        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <inheritdoc/>
        public string ContentType => GeminiContentType.ApplicationJSON.MimeType();

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return !string.IsNullOrEmpty(ModelId)
                ? $"https://generativelanguage.googleapis.com/{ApiVersion}/tunedModels?tunedModelId={ModelId.BaseModelId}"
                : $"https://generativelanguage.googleapis.com/{ApiVersion}/tunedModels";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiTunedModelCreateRequest"/>.
        /// </summary>
        /// <param name="model">The tuned model to be created.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiTunedModelCreateRequest(GeminiTunedModelCreationData model, bool useBetaApi = false)
        {
            Model = model;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(Model);
        }
    }
}