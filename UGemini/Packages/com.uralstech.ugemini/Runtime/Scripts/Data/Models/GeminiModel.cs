using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models
{
    /// <summary>
    /// Information about a Generative Language Model.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiModel : GeminiModelId
    {
        /// <summary>
        /// <a href="https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.0-pro-vision">
        /// Note: Gemini 1.0 Pro Vision is deprecated. Use 1.5 Flash or 1.5 Pro instead.
        /// <br/><br/>
        /// Gemini 1.0 Pro Vision is a performance-optimized multimodal model that can perform visual-related tasks.<br/>
        /// For example, 1.0 Pro Vision can generate image descriptions, identify objects present in images, provide<br/>
        /// information about places or objects present in images, and more.
        /// </a>
        /// </summary>
        /// <remarks>
        /// Supports image, video and text input.
        /// </remarks>
        public readonly static GeminiModelId Gemini1_0ProVision = "gemini-pro-vision";

        /// <summary>
        /// <a href="https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.0-pro">
        /// Gemini 1.0 Pro is an NLP model that handles tasks like multi-turn text and code chat, and code generation.
        /// </a>
        /// </summary>
        /// <remarks>
        /// Supports text input.
        /// </remarks>
        public readonly static GeminiModelId Gemini1_0Pro = "gemini-1.0-pro";

        /// <summary>
        /// Finetuning-supported version of <see cref="Gemini1_0Pro"/>.
        /// </summary>
        /// <remarks>
        /// <a href="https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.0-pro">
        /// Gemini 1.0 Pro is an NLP model that handles tasks like multi-turn text and code chat, and code generation.
        /// </a>
        /// Supports text input.
        /// </remarks>
        public readonly static GeminiModelId Gemini1_0ProTuning = "gemini-1.0-pro-001";

        /// <summary>
        /// <a href="https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.5-pro">
        /// Gemini 1.5 Pro is a mid-size multimodal model that is optimized for a wide-range of reasoning tasks.<br/>
        /// 1.5 Pro can process large amounts of data at once, including 2 hours of video, 19 hours of audio,<br/>
        /// codebases with 60,000 lines of code, or 2,000 pages of text.
        /// </a>
        /// </summary>
        /// <remarks>
        /// Supports audio, image, video and text input.
        /// </remarks>
        public readonly static GeminiModelId Gemini1_5Pro = "gemini-1.5-pro";

        /// <summary>
        /// <a href="https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.5-flash">
        /// Gemini 1.5 Flash is a fast and versatile multimodal model for scaling across diverse tasks.
        /// </a>
        /// </summary>
        /// <remarks>
        /// Supports audio, image, video and text input.
        /// </remarks>
        public readonly static GeminiModelId Gemini1_5Flash = "gemini-1.5-flash";

        /// <summary>
        /// Finetuning-supported version of <see cref="Gemini1_5Flash"/>.
        /// </summary>
        /// <remarks>
        /// <a href="https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.5-flash">
        /// Gemini 1.5 Flash is a fast and versatile multimodal model for scaling across diverse tasks.
        /// </a>
        /// Supports audio, image, video and text input.
        /// </remarks>
        public readonly static GeminiModelId Gemini1_5FlashTuning = "gemini-1.5-flash-001-tuning";

        /// <summary>
        /// <a href="https://ai.google.dev/gemini-api/docs/models/gemini#text-embedding">
        /// text-embedding-004 achieves a stronger retrieval performance and outperforms existing models with comparable dimensions, on the standard MTEB embedding benchmarks.
        /// </a>
        /// </summary>
        /// <remarks>
        /// Supports text input.
        /// </remarks>
        public readonly static GeminiModelId TextEmbedding004 = "text-embedding-004";

        /// <summary>
        /// <a href="https://ai.google.dev/gemini-api/docs/models/gemini#aqa">
        /// You can use the AQA model to perform Attributed Question-Answering (AQA)–related tasks over a document, corpus, or a set of passages. The AQA model returns answers
        /// to questions that are grounded in provided sources, along with estimating answerable probability.
        /// </a>
        /// </summary>
        /// <remarks>
        /// Supports text input.
        /// </remarks>
        public readonly static GeminiModelId Aqa = "aqa";

        /// <summary>
        /// The version number of the model.
        /// </summary>
        /// <remarks>
        /// This represents the major version
        /// </remarks>
        public string Version;

        /// <summary>
        /// The human-readable name of the model. E.g. "Chat Bison".
        /// </summary>
        /// <remarks>
        /// The name can be up to 128 characters long and can consist of any UTF-8 characters.
        /// </remarks>
        public string DisplayName;

        /// <summary>
        /// A short description of the model.
        /// </summary>
        public string Description;

        /// <summary>
        /// Maximum number of input tokens allowed for this model.
        /// </summary>
        public int InputTokenLimit;

        /// <summary>
        /// Maximum number of output tokens available for this model.
        /// </summary>
        public int OutputTokenLimit;

        /// <summary>
        /// The model's supported generation methods.
        /// </summary>
        /// <remarks>
        /// The method names are defined as Pascal case strings, such as <c>generateMessage</c> which correspond to API methods.
        /// </remarks>
        public string[] SupportedGenerationMethods;

        /// <summary>
        /// Controls the randomness of the output.
        /// </summary>
        /// <remarks>
        /// Values can range over [0.0,2.0], inclusive. A higher value will produce responses that are more varied, while a value closer to<br/>
        /// 0.0 will typically result in less surprising responses from the model. This value specifies default to be used by the backend<br/>
        /// while making the call to the model.
        /// </remarks>
        public float Temperature;

        /// <summary>
        /// The maximum temperature this model can use.
        /// </summary>
        public float MaxTemperature;

        /// <summary>
        /// For Nucleus sampling.
        /// </summary>
        /// <remarks>
        /// Nucleus sampling considers the smallest set of tokens whose probability sum is at least topP. This value specifies default to be used<br/>
        /// by the backend while making the call to the model.
        /// </remarks>
        public float TopP;

        /// <summary>
        /// For Top-k sampling.
        /// </summary>
        /// <remarks>
        /// Top-k sampling considers the set of topK most probable tokens. This value specifies default to be used by the backend while making the call<br/>
        /// to the model. If unset, indicates the model doesn't use top-k sampling, and topK isn't allowed as a generation parameter.
        /// </remarks>
        public int TopK;

        /// <exclude />
        [JsonConstructor]
        internal GeminiModel(
            string name,
            string baseModelId,
            string version,
            string displayName,
            string description,
            int inputTokenLimit,
            int outputTokenLimit,
            string[] supportedGenerationMethods,
            float temperature,
            float topP,
            int topK
        ) : base(name, baseModelId)
        {
            if (string.IsNullOrEmpty(BaseModelId) && !string.IsNullOrEmpty(name))
                BaseModelId = name.Split('/')[^1];

            Version = version;
            DisplayName = displayName;
            Description = description;
            InputTokenLimit = inputTokenLimit;
            OutputTokenLimit = outputTokenLimit;
            SupportedGenerationMethods = supportedGenerationMethods;
            Temperature = temperature;
            TopP = topP;
            TopK = topK;
        }
    }
}
