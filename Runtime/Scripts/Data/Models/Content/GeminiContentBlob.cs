using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UnityEngine;

namespace Uralstech.UGemini.Models.Content
{
    /// <summary>
    /// Raw media bytes.
    /// 
    /// Text should not be sent as raw bytes, use the <see cref="GeminiContentPart.Text"/> field.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiContentBlob
    {
        /// <summary>
        /// The type of the data.
        /// </summary>
        /// <remarks>
        /// You can use <see cref="GeminiContentTypeExtensions.ContentType(string)"/> to convert <see cref="string"/>
        /// values to their <see cref="GeminiContentType"/> equivalents, like:
        /// <c>"image/png".ContentType()</c>
        /// </remarks>
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
        /// Requires <a href="https://openupm.com/packages/com.utilities.encoder.wav/">Utilities.Encoding.Wav</a>.
        /// </remarks>
        /// <param name="audio">The <see cref="AudioClip"/> to use.</param>
        /// <returns>A new <see cref="GeminiContentBlob"/> object.</returns>
        public static GeminiContentBlob GetContentBlob(AudioClip audio)
        {
            return new GeminiContentBlob()
            {
                MimeType = GeminiContentType.AudioWAV,
                Data = audio.ToBase64WAV()
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
                    Data = image.ToBase64JPEG()
                }
                : new GeminiContentBlob()
                {
                    MimeType = GeminiContentType.ImagePNG,
                    Data = image.ToBase64PNG()
                };
        }
    }
}