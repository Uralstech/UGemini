using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using Uralstech.UGemini.JsonConverters;

namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// Data to patch an existing cached content resource with new data.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiTunedModelPatchData
    {
        /// <summary>
        /// The name to display for this model in user interfaces.
        /// </summary>
        /// <remarks>
        /// The display name must be up to 40 characters including spaces.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string DisplayName = null;

        /// <summary>
        /// A short description of the model.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string Description = null;

        /// <summary>
        /// The tuning task that creates the tuned model.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiInitialTuningTask TuningTask = null;

        /// <summary>
        /// TunedModel to use as the starting point for training the new model.
        /// </summary>
        /// <remarks>
        /// If not provided, <see cref="BaseModel"/> must be provided.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiTunedModelSource TunedModelSource = null;

        /// <summary>
        /// The name of the <see cref="GeminiModel"/> to tune. Example: models/gemini-1.5-flash-0
        /// </summary>
        /// <remarks>
        /// If not provided, <see cref="TunedModelSource"/> must be provided.
        /// </remarks>
        [JsonConverter(typeof(GeminiModelIdStringConverter)), JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiModelId BaseModel = null;

        /// <summary>
        /// Controls the randomness of the output.
        /// </summary>
        /// <remarks>
        /// Values can range over [0.0,1.0], inclusive. A value closer to 1.0 will produce responses that are more varied, while a value closer<br/>
        /// to 0.0 will typically result in less surprising responses from the model. This value specifies default to be the one used by the<br/>
        /// base model while creating the model.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public float? Temperature = null;

        /// <summary>
        /// For Nucleus sampling.
        /// </summary>
        /// <remarks>
        /// Nucleus sampling considers the smallest set of tokens whose probability sum is at least topP. This value specifies default to be<br/>
        /// the one used by the base model while creating the model.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public float? TopP = null;

        /// <summary>
        /// For Top-k sampling.
        /// </summary>
        /// <remarks>
        /// Top-k sampling considers the set of topK most probable tokens. This value specifies default to be used by the backend while<br/>
        /// making the call to the model. This value specifies default to be the one used by the base model while creating the model.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public int? TopK = null;
    }
}