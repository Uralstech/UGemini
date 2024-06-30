using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using UnityEngine;

namespace Uralstech.UGemini
{
    /// <summary>
    /// Raw media bytes.
    /// 
    /// Text should not be sent as raw bytes, use the <see cref="GeminiContentPart.Text"/>> field.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiContentBlob
    {
        /// <summary>
        /// The type of the data.
        /// </summary>
        public GeminiContentType MimeType;

        /// <summary>
        /// The base64 encoded bytes of data.
        /// </summary>
        public string Data;

#if UTILITIES_ENCODING_WAV_1_0_0_OR_GREATER && UTILITIES_AUDIO_1_0_0_OR_GREATER

        /// <summary>
        /// Converts the given <see cref="AudioClip"/> to a <see cref="GeminiContentBlob"/>.
        /// </summary>
        /// <remarks>
        /// Requires <see href="https://openupm.com/packages/com.utilities.encoder.wav/">Utilities.Encoding.Wav</see>.
        /// </remarks>
        /// <param name="audio">The <see cref="AudioClip"/> to use.</param>
        /// <returns>A new <see cref="GeminiContentBlob"/> object.</returns>
        public static GeminiContentBlob GetContentBlob(AudioClip audio)
        {
            return new GeminiContentBlob()
            {
                MimeType = GeminiContentType.AudioWAV,
                Data = Convert.ToBase64String(Utilities.Encoding.Wav.AudioClipExtensions.EncodeToWav(audio))
            };
        }
#endif

        /// <summary>
        /// Converts the given <see cref="Texture2D"/> to a <see cref="GeminiContentBlob"/>.
        /// </summary>
        /// <param name="image">The <see cref="Texture2D"/> to use.</param>
        /// <param name="useJPEG">Should the encoder use JPEG instead of PNG?</param>
        /// <returns>A new <see cref="GeminiContentBlob"/> object.</returns>
        public static GeminiContentBlob GetContentBlob(Texture2D image, bool useJPEG = false)
        {
            return useJPEG
                ? new GeminiContentBlob()
                {
                    MimeType = GeminiContentType.ImageJPEG,
                    Data = Convert.ToBase64String(image.EncodeToJPG())
                }
                : new GeminiContentBlob()
                {
                    MimeType = GeminiContentType.ImagePNG,
                    Data = Convert.ToBase64String(image.EncodeToPNG())
                };
        }
    }
}