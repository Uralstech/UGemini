using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Uralstech.UGemini.CorporaAPI
{
    /// <summary>
    /// A Corpus is a collection of Documents. A project can create up to 5 corpora.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorpus
    {
        /// <summary>
        /// The Corpus resource name.
        /// </summary>
        /// <remarks>
        /// The ID (name excluding the "corpora/" prefix) can contain up to 40 characters that are lowercase alphanumeric or dashes (-).<br/>
        /// The ID cannot start or end with a dash. If the name is empty on create, a unique name will be derived from displayName along<br/>
        /// with a 12 character random suffix. Example: corpora/my-awesome-corpora-123a456b789c
        /// </remarks>
        public string Name;

        /// <summary>
        /// The human-readable display name for the Corpus.
        /// </summary>
        /// <remarks>
        /// The display name must be no more than 512 characters in length, including spaces. Example: "Docs on Semantic Retriever"
        /// </remarks>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName = null;

        /// <summary>
        /// The timestamp of when the Corpus was created.
        /// </summary>
        public DateTime CreateTime;

        /// <summary>
        /// The timestamp of when the Corpus was last updated.
        /// </summary>
        public DateTime UpdateTime;
    }
}
