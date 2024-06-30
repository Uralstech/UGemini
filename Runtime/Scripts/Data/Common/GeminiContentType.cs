
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UGemini
{
    /// <summary>
    /// Enum for the types of content able to be fed to the Gemini API.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiContentType
    {
        /// <summary>
        /// A PNG image.
        /// </summary>
        [EnumMember(Value = "image/png")]
        ImagePNG,

        /// <summary>
        /// A JPEG image.
        /// </summary>
        [EnumMember(Value = "image/jpeg")]
        ImageJPEG,

        /// <summary>
        /// A HEIC image.
        /// </summary>
        [EnumMember(Value = "image/heic")]
        ImageHEIC,

        /// <summary>
        /// A HEIF image.
        /// </summary>
        [EnumMember(Value = "image/heif")]
        ImageHEIF,

        /// <summary>
        /// A WebP image.
        /// </summary>
        [EnumMember(Value = "image/webp")]
        ImageWebP,

        /// <summary>
        /// WAV encoded audio.
        /// </summary>
        [EnumMember(Value = "audio/wav")]
        AudioWAV,

        /// <summary>
        /// MP3 encoded audio.
        /// </summary>
        [EnumMember(Value = "audio/mp3")]
        AudioMP3,

        /// <summary>
        /// AIFF encoded audio.
        /// </summary>
        [EnumMember(Value = "audio/aiff")]
        AudioAIFF,

        /// <summary>
        /// AAC encoded audio.
        /// </summary>
        [EnumMember(Value = "audio/aac")]
        AudioAAC,

        /// <summary>
        /// OGG encoded audio.
        /// </summary>
        [EnumMember(Value = "audio/ogg")]
        AudioOGG,

        /// <summary>
        /// FLAC encoded audio.
        /// </summary>
        [EnumMember(Value = "audio/flac")]
        AudioFLAC,

        /// <summary>
        /// MP4 encoded video.
        /// </summary>
        [EnumMember(Value = "video/mp4")]
        VideoMP4,

        /// <summary>
        /// MPEG encoded video.
        /// </summary>
        [EnumMember(Value = "video/mpeg")]
        VideoMPEG,

        /// <summary>
        /// MOV encoded video.
        /// </summary>
        [EnumMember(Value = "video/mov")]
        VideoMOV,

        /// <summary>
        /// AVI encoded video.
        /// </summary>
        [EnumMember(Value = "video/avi")]
        VideoAVI,

        /// <summary>
        /// FLV encoded video.
        /// </summary>
        [EnumMember(Value = "video/x-flv")]
        VideoXFLV,

        /// <summary>
        /// MPG encoded video.
        /// </summary>
        [EnumMember(Value = "video/mpg")]
        VideoMPG,

        /// <summary>
        /// WebM encoded video.
        /// </summary>
        [EnumMember(Value = "video/webm")]
        VideoWebM,

        /// <summary>
        /// WMV encoded video.
        /// </summary>
        [EnumMember(Value = "video/wmv")]
        VideoWMV,

        /// <summary>
        /// 3GPP encoded video.
        /// </summary>
        [EnumMember(Value = "video/3gpp")]
        Video3GPP,
    }
}