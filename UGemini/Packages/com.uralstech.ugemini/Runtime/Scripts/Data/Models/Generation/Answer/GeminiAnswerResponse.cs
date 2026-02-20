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
using Uralstech.UGemini.Models.Generation.Candidate;

namespace Uralstech.UGemini.Models.Generation.QuestionAnswering
{
    /// <summary>
    /// Response from the model for a grounded answer.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiAnswerResponse
    {
        /// <summary>
        /// Candidate answer from the model.
        /// </summary>
        /// <remarks>
        /// The model always attempts to provide a grounded answer, even when the answer is unlikely to be answerable from the given passages.<br/>
        /// In that case, a low-quality or ungrounded answer may be provided, along with a low <see cref="AnswerableProbability"/>.
        /// </remarks>
        public GeminiCandidate Answer;

        /// <summary>
        /// The model's estimate of the probability that its answer is correct and grounded in the input passages.
        /// </summary>
        /// <remarks>
        /// A low answerableProbability indicates that the answer might not be grounded in the sources.
        /// <br/><br/>
        /// When answerableProbability is low, some clients may wish to:<br/>
        /// - Display a message to the effect of "We couldn’t answer that question" to the user.<br/>
        /// - Fall back to a general-purpose LLM that answers the question from world knowledge. The threshold and nature of such fallbacks will depend on individual clients’ use cases. 0.5 is a good starting threshold.
        /// </remarks>
        public float AnswerableProbability;

        /// <summary>
        ///  Feedback related to the input data used to answer the question, as opposed to model-generated response to the question.
        /// </summary>
        /// <remarks>
        /// "Input data" can be one or more of the following:<br/>
        /// - Question specified by the last entry in <see cref="GeminiAnswerRequest.Contents"/><br/>
        /// - Conversation history specified by the other entries in <see cref="GeminiAnswerRequest.Contents"/><br/>
        /// - Grounding sources (<see cref="GeminiAnswerRequest.SemanticRetriever"/> or <see cref="GeminiAnswerRequest.InlinePassages"/>)<br/>
        /// </remarks>
        public GeminiPromptFeedback InputFeedback;
    }
}
