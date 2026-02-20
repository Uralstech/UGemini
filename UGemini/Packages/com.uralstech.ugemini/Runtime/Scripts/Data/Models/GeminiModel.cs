// Copyright 2024 URAV ADVANCED LEARNING SYSTEMS PRIVATE LIMITED
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models
{
    /// <summary>
    /// Information about a Generative Language Model.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class GeminiModel : GeminiModelId
    {
        /// <summary>
        /// The version number of the model.
        /// </summary>
        /// <remarks>
        /// This represents the major version (1.0 or 1.5).
        /// </remarks>
        public string Version;

        /// <summary>
        /// The human-readable name of the model. E.g. "Gemini 1.5 Flash".
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
        /// The corresponding API method names are defined as Pascal case strings, such as generateMessage and generateContent.
        /// </remarks>
        public string[] SupportedGenerationMethods;

        /// <summary>
        /// Controls the randomness of the output.
        /// </summary>
        /// <remarks>
        /// Values can range over [0.0,<see cref="MaxTemperature"/>], inclusive. A higher value will produce responses that are more varied, while a value closer to<br/>
        /// 0.0 will typically result in less surprising responses from the model. This value specifies default to be used by the backend<br/>
        /// while making the call to the model.
        /// </remarks>
        public float Temperature;

        /// <summary>
        /// The maximum temperature this model can use.
        /// </summary>
        public float MaxTemperature;

        /// <summary>
        /// For <a href="https://ai.google.dev/gemini-api/docs/prompting-strategies#top-p">Nucleus sampling</a>.
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
