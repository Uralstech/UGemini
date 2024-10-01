using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using Uralstech.UGemini.JsonConverters;

namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// A fine-tuned model created using ModelService.CreateTunedModel.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiTunedModel : GeminiModelId
    {
        /// <summary>
        /// The name to display for this model in user interfaces.
        /// </summary>
        /// <remarks>
        /// The display name must be up to 40 characters including spaces.
        /// </remarks>
        public string DisplayName;

        /// <summary>
        /// A short description of the model.
        /// </summary>
        public string Description;

        /// <summary>
        /// The state of the tuned model.
        /// </summary>
        public GeminiTunedModelState State;

        /// <summary>
        /// The timestamp when this model was created.
        /// </summary>
        public DateTime CreateTime;

        /// <summary>
        /// The timestamp when this model was updated.
        /// </summary>
        public DateTime UpdateTime;

        /// <summary>
        /// The tuning task that creates the tuned model.
        /// </summary>
        public GeminiTuningTask TuningTask;

        /// <summary>
        /// List of project numbers that have read access to the tuned model.
        /// </summary>
        [JsonConverter(typeof(GeminiLongArrayToStringArrayJsonConverter))]
        public long[] ReaderProjectNumbers;

        /// <summary>
        /// TunedModel to use as the starting point for training the new model.
        /// </summary>
        public GeminiTunedModelSource TunedModelSource;

        /// <summary>
        /// The name of the <see cref="GeminiModel"/> to tune. Example: models/gemini-1.5-flash-0
        /// </summary>
        [JsonConverter(typeof(GeminiModelIdStringConverter))]
        public GeminiModelId BaseModel;

        /// <summary>
        /// Controls the randomness of the output.
        /// </summary>
        /// <remarks>
        /// Values can range over [0.0,1.0], inclusive. A value closer to 1.0 will produce responses that are more varied, while a value closer<br/>
        /// to 0.0 will typically result in less surprising responses from the model. This value specifies default to be the one used by the<br/>
        /// base model while creating the model.
        /// </remarks>
        public float Temperature;

        /// <summary>
        /// For Nucleus sampling.
        /// </summary>
        /// <remarks>
        /// Nucleus sampling considers the smallest set of tokens whose probability sum is at least topP. This value specifies default to be<br/>
        /// the one used by the base model while creating the model.
        /// </remarks>
        public float TopP;

        /// <summary>
        /// For Top-k sampling.
        /// </summary>
        /// <remarks>
        /// Top-k sampling considers the set of topK most probable tokens. This value specifies default to be used by the backend while<br/>
        /// making the call to the model. This value specifies default to be the one used by the base model while creating the model.
        /// </remarks>
        public int TopK;

        /// <exclude />
        [JsonConstructor]
        internal GeminiTunedModel(
            string name,
            string displayName,
            string description,
            GeminiTunedModelState state,
            DateTime createTime,
            DateTime updateTime,
            GeminiTuningTask tuningTask,
            GeminiTunedModelSource tunedModelSource,
            GeminiModelId baseModel,
            float temperature,
            float topP,
            int topK) : base(name)
        {
            DisplayName = displayName;
            Description = description;
            State = state;
            CreateTime = createTime;
            UpdateTime = updateTime;
            TuningTask = tuningTask;
            TunedModelSource = tunedModelSource;
            BaseModel = baseModel;
            Temperature = temperature;
            TopP = topP;
            TopK = topK;
        }
    }
}
