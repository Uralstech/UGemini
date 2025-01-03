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

using System;
using UnityEngine;

namespace Uralstech.UGemini.Models.Content
{
    /// <summary>
    /// Extensions for Unity types.
    /// </summary>
    public static class UnityExtensions
    {
#if UTILITIES_ENCODING_WAV_1_0_0_OR_GREATER && UTILITIES_AUDIO_1_0_0_OR_GREATER

        /// <summary>
        /// Converts the given <see cref="AudioClip"/> to WAV bytes.
        /// </summary>
        /// <param name="clip">The <see cref="AudioClip"/>.</param>
        /// <returns>The WAV encoded <see cref="byte"/> array.</returns>
        public static byte[] ToWAV(this AudioClip clip)
        {
            return Utilities.Encoding.Wav.AudioClipExtensions.EncodeToWav(clip);
        }

        /// <summary>
        /// Converts the given <see cref="AudioClip"/> to a WAV Base64 encoded string.
        /// </summary>
        /// <param name="clip">The <see cref="AudioClip"/>.</param>
        /// <returns>The Base64 encoded <see cref="string"/>.</returns>
        public static string ToBase64WAV(this AudioClip clip)
        {
            return Convert.ToBase64String(clip.ToWAV());
        }
#endif

        /// <summary>
        /// Converts the given <see cref="Texture2D"/> to a PNG Base64 encoded string.
        /// </summary>
        /// <param name="image">The <see cref="Texture2D"/>.</param>
        /// <returns>The Base64 encoded <see cref="string"/>.</returns>
        public static string ToBase64PNG(this Texture2D image)
        {
            return Convert.ToBase64String(image.EncodeToPNG());
        }

        /// <summary>
        /// Converts the given <see cref="Texture2D"/> to a JPEG Base64 encoded string.
        /// </summary>
        /// <param name="image">The <see cref="Texture2D"/>.</param>
        /// <returns>The Base64 encoded <see cref="string"/>.</returns>
        public static string ToBase64JPEG(this Texture2D image)
        {
            return Convert.ToBase64String(image.EncodeToJPG());
        }
    }
}
