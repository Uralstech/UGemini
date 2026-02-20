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

namespace Uralstech.UGemini.CorporaAPI
{
    /// <summary>
    /// A Corpus is a collection of Documents. A project can create up to 5 corpora.
    /// </summary>
    public class GeminiCorpusId : IGeminiCorpusResourceId
    {
        /// <summary>
        /// The ID of the Corpus.
        /// </summary>
        public string ResourceId { get; }

        /// <summary>
        /// The name (format 'corpora/{corpusId}') of the Corpus.
        /// </summary>
        public string ResourceName => $"corpora/{ResourceId}";

        /// <summary>
        /// Creates a new <see cref="GeminiCorpusId"/>.
        /// </summary>
        /// <param name="corpusNameOrId">The name (format 'corpora/{corpusId}') or ID of the Corpus.</param>
        public GeminiCorpusId(string corpusNameOrId)
        {
            ResourceId = corpusNameOrId.Split('/')[^1];
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorpusId"/>.
        /// </summary>
        /// <param name="corpusNameOrId">The name (format 'corpora/{corpusId}') or ID of the Corpus.</param>
        public static explicit operator GeminiCorpusId(string corpusNameOrId)
        {
            return new(corpusNameOrId);
        }
    }
}