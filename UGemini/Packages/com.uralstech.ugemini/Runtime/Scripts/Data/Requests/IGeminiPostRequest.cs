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

namespace Uralstech.UGemini
{
    /// <summary>
    /// All Gemini API POST requests must inherit from this interface.
    /// </summary>
    public interface IGeminiPostRequest : IGeminiRequest
    {
        /// <summary>
        /// The MIME type of the request content.
        /// </summary>
        public string ContentType { get; }

        /// <summary>
        /// Converts the request object to a UTF-8 encoded <see cref="string"/>.
        /// </summary>
        /// <returns>The string data.</returns>
        public string GetUtf8EncodedData();
    }
}
