using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Uralstech.UCloud.Operations.Generic;

namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// The response type for a <see cref="GeminiTunedModelCreateRequest"/>.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiTunedModelCreateResponse : Operation<GeminiTunedModelCreationOperationMetadata, GeminiTunedModel> { }
}