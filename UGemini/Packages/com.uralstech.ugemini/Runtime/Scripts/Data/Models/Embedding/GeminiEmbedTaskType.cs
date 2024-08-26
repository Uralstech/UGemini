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
