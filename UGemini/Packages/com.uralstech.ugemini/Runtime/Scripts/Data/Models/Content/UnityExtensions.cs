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
