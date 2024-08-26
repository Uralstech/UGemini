using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using Uralstech.UGemini.Models.Generation.Schema;

namespace Uralstech.UGemini.Models.Generation.Chat
{
    /// <summary>
    /// Configuration options for model generation and outputs. Not all parameters may be configurable for every model.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiGenerationConfiguration
    {
        /// <summary>
        /// The set of character sequences (up to 5) that will stop output generation. If specified, the API will stop at the first appearance of a stop sequence. The stop sequence will not be included as part of the response.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string[] StopSequences = null;

        /// <summary>
        /// Output response type of the generated candidate text.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(GeminiResponseType.Unspecified)]
        public GeminiResponseType ResponseMimeType = GeminiResponseType.Unspecified;

        /// <summary>
        /// Output response schema of the generated candidate text when response mime type can have schema.
        /// </summary>
        /// <remarks>
        /// If set, a compatible <see cref="GeminiResponseType"/> must also be set. Compatible types: <see cref="GeminiResponseType.Json"/>: Schema for JSON response.
        /// <br/><br/>
        /// Only available in the beta API.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiSchema ResponseSchema = null;

        /// <summary>
        /// Number of generated responses to return.
        /// </summary>
        /// <remarks>
        /// Currently, this value can only be set to 1. If unset, this will default to 1.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(1)]
        public int CandidateCount = 1;

        /// <summary>
        /// The maximum number of tokens to include in a candidate.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(-1)]
        public int MaxOutputTokens = -1;

        /// <summary>
        /// Controls the randomness of the output. Values can range from 0.0 - 2.0.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(-1f)]
        public float Temperature = -1f;

        /// <summary>
        /// The maximum cumulative probability of tokens to consider when sampling.
        /// </summary>
        /// <remarks>
        /// The model uses combined Top-k and nucleus sampling.
        /// <br/><br/>
        /// Tokens are sorted based on their assigned probabilities so that only the most likely tokens are considered.<br/>
        /// Top-k sampling directly limits the maximum number of tokens to consider, while Nucleus sampling limits<br/>
        /// number of tokens based on the cumulative probability.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(-1f)]
        public float TopP = -1f;

        /// <summary>
        /// The maximum number of tokens to consider when sampling.
        /// </summary>
        /// <remarks>
        /// Models use nucleus sampling or combined Top-k and nucleus sampling. Top-k sampling considers the set of topK most<br/>
        /// probable tokens. Models running with nucleus sampling don't allow topK setting.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(-1)]
        public int TopK = -1;
    }
}