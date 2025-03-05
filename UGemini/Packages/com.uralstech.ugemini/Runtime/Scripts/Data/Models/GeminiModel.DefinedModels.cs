// Copyright 2025 URAV ADVANCED LEARNING SYSTEMS PRIVATE LIMITED
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

namespace Uralstech.UGemini.Models
{
    public partial class GeminiModel
    {
        /// <summary>
        /// <a href="https://ai.google.dev/gemini-api/docs/models/gemini#gemini-2.0-flash">
        /// Gemini 2.0 Flash delivers next-gen features and improved capabilities, including superior speed,
        /// native tool use, multimodal generation, and a 1M token context window.
        /// </a>
        /// </summary>
        /// <remarks>
        /// Supports audio, image, video and text input.
        /// </remarks>
        public static readonly GeminiModelId Gemini2_0Flash = "gemini-2.0-flash";

        /// <summary>
        /// <a href="https://ai.google.dev/gemini-api/docs/models/gemini#gemini-2.0-flash-lite">
        /// A Gemini 2.0 Flash model optimized for cost efficiency and low latency.
        /// </a>
        /// </summary>
        /// <remarks>
        /// Supports audio, image, video and text input.
        /// </remarks>
        public static readonly GeminiModelId Gemini2_0FlashLite = "gemini-2.0-flash-lite";

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
        public static readonly GeminiModelId Gemini1_5Pro = "gemini-1.5-pro";

        /// <summary>
        /// <a href="https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.5-flash">
        /// Gemini 1.5 Flash is a fast and versatile multimodal model for scaling across diverse tasks.
        /// </a>
        /// </summary>
        /// <remarks>
        /// Supports audio, image, video and text input.
        /// </remarks>
        public static readonly GeminiModelId Gemini1_5Flash = "gemini-1.5-flash";

        /// <summary>
        /// Finetuning-supported version of <see cref="Gemini1_5Flash"/>.
        /// </summary>
        /// <remarks>
        /// <a href="https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.5-flash">
        /// Gemini 1.5 Flash is a fast and versatile multimodal model for scaling across diverse tasks.
        /// </a>
        /// Supports audio, image, video and text input.
        /// </remarks>
        public static readonly GeminiModelId Gemini1_5FlashTuning = "gemini-1.5-flash-001-tuning";

        /// <summary>
        /// <a href="https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.5-flash-8b">
        /// Gemini 1.5 Flash-8B is a small model designed for lower intelligence tasks.
        /// </a>
        /// </summary>
        /// <remarks>
        /// Supports audio, image, video and text input.
        /// </remarks>
        public static readonly GeminiModelId Gemini1_5Flash8B = "gemini-1.5-flash-8b";

        /// <summary>
        /// <a href="https://ai.google.dev/gemini-api/docs/models/gemini#text-embedding">
        /// text-embedding-004 achieves a stronger retrieval performance and outperforms existing models with comparable dimensions, on the standard MTEB embedding benchmarks.
        /// </a>
        /// </summary>
        /// <remarks>
        /// Supports text input.
        /// </remarks>
        public static readonly GeminiModelId TextEmbedding004 = "text-embedding-004";

        /// <summary>
        /// <a href="https://ai.google.dev/gemini-api/docs/models/gemini#aqa">
        /// You can use the AQA model to perform Attributed Question-Answering (AQA)–related tasks over a document, corpus, or a set of passages. The AQA model returns answers
        /// to questions that are grounded in provided sources, along with estimating answerable probability.
        /// </a>
        /// </summary>
        /// <remarks>
        /// Supports text input.
        /// </remarks>
        public static readonly GeminiModelId Aqa = "aqa";
    }
}
