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
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UGemini.Models.Embedding
{
    /// <summary>
    /// Type of task for which the embedding will be used.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiEmbedTaskType
    {
        /// <summary>
        /// Unset value.
        /// </summary>
        [EnumMember(Value = "TASK_TYPE_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// Specifies the given text is a query in a search/retrieval setting.
        /// </summary>
        [EnumMember(Value = "RETRIEVAL_QUERY")]
        RetrievalQuery,

        /// <summary>
        /// Specifies the given text is a document from the corpus being searched.
        /// </summary>
        [EnumMember(Value = "RETRIEVAL_DOCUMENT")]
        RetrievalDocument,

        /// <summary>
        /// Specifies the given text will be used for STS.
        /// </summary>
        [EnumMember(Value = "SEMANTIC_SIMILARITY")]
        SemanticSimilarity,

        /// <summary>
        /// Specifies that the given text will be classified.
        /// </summary>
        [EnumMember(Value = "CLASSIFICATION")]
        Classification,

        /// <summary>
        /// Specifies that the embeddings will be used for clustering.
        /// </summary>
        [EnumMember(Value = "CLUSTERING")]
        Clustering,

        /// <summary>
        /// Specifies that the given text will be used for question answering.
        /// </summary>
        [EnumMember(Value = "QUESTION_ANSWERING")]
        QuestionAnswering,

        /// <summary>
        /// Specifies that the given text will be used for fact verification.
        /// </summary>
        [EnumMember(Value = "FACT_VERIFICATION")]
        FactVerification,
    }
}
