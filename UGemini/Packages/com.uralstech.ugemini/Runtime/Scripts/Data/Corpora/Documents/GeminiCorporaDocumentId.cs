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

namespace Uralstech.UGemini.CorporaAPI.Documents
{
    /// <summary>
    /// A Document is a collection of Chunks. A Corpus can have a maximum of 10,000 Documents.
    /// </summary>
    public class GeminiCorpusDocumentId : IGeminiCorpusResourceId
    {
        /// <summary>
        /// The ID of the Corpus which contains this Document.
        /// </summary>
        public string CorpusId;

        /// <summary>
        /// The ID of the Document.
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// The resource name of this Document (format 'corpora/{corpusId}/documents/{documentId}').
        /// </summary>
        public string ResourceName => $"corpora/{CorpusId}/documents/{ResourceId}";

        /// <summary>
        /// Creates a new <see cref="GeminiCorpusDocumentId"/>.
        /// </summary>
        /// <param name="documentName">The name (format 'corpora/{corpusId}/documents/{documentId}') of the Document.</param>
        public GeminiCorpusDocumentId(string documentName)
        {
            string[] parts = documentName.Split('/');
            (CorpusId, ResourceId) = (parts[1], parts[3]);
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorpusDocumentId"/>.
        /// </summary>
        /// <param name="corpusId">The resource ID of the Corpus which contains the Document.</param>
        /// <param name="documentNameOrId">The name (format 'corpora/{corpusId}/documents/{documentId}') or ID of the Document.</param>
        public GeminiCorpusDocumentId(GeminiCorpusId corpusId, string documentNameOrId)
        {
            CorpusId = corpusId.ResourceId;
            ResourceId = documentNameOrId.Split('/')[^1];
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorpusDocumentId"/>.
        /// </summary>
        /// <param name="documentName">The name (format 'corpora/{corpusId}/documents/{documentId}') of the Document.</param>
        public static explicit operator GeminiCorpusDocumentId(string documentName)
        {
            return new(documentName);
        }
    }
}