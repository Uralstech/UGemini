using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using Uralstech.UGemini.Models.Generation.Schema;

namespace Uralstech.UGemini.Models.Generation
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

        /// <summary>
        /// Presence penalty applied to the next token's logprobs if the token has already been seen in the response.
        /// </summary>
        /// <remarks>
        /// This penalty is binary on/off and not dependant on the number of times the token is used (after the first). Use<br/>
        /// <see cref="FrequencyPenalty"/> for a penalty that increases with each use. A positive penalty will<br/>
        /// discourage the use of tokens that have already been used in the response, increasing the vocabulary. A negative<br/>
        /// penalty will encourage the use of tokens that have already been used in the response, decreasing the vocabulary.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(-1f)]
        public float PresencePenalty = -1f;

        /// <summary>
        /// Frequency penalty applied to the next token's logprobs, multiplied by the number of times each token has been seen in the response so far.
        /// </summary>
        /// <remarks>
        /// A positive penalty will discourage the use of tokens that have already been used, proportional to the number<br/>
        /// of times the token has been used: The more a token is used, the more dificult it is for the model to use that<br/>
        /// token again increasing the vocabulary of responses.
        /// <br/><br/>
        /// Caution: A negative penalty will encourage the model to reuse tokens proportional to the number of times the<br/>
        /// token has been used. Small negative values will reduce the vocabulary of a response. Larger negative values<br/>
        /// will cause the model to start repeating a common token until it hits the<br/>
        /// <see cref="MaxOutputTokens"/> limit: "...the the the the the...".
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(-1f)]
        public float FrequencyPenalty = -1f;

        /// <summary>
        /// If <see langword="true"/>, export the logprobs results in response.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public bool? ResponseLogprobs = null;

        /// <summary>
        /// Only valid if <see cref="ResponseLogprobs"/> = <see langword="true"/>. This sets the number of top logprobs to return at each decoding step in the <see cref="Candidate.GeminiCandidate.LogprobsResult"/>.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(-1)]
        public int Logprobs = -1;
    }
}