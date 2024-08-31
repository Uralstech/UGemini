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

        /// <summary>
        /// (File API) Plain text.
        /// </summary>
        [EnumMember(Value = "text/plain")]
        TextPlain,

        /// <summary>
        /// (File API) HTML text.
        /// </summary>
        [EnumMember(Value = "text/html")]
        TextHTML,

        /// <summary>
        /// (File API) CSS text.
        /// </summary>
        [EnumMember(Value = "text/css")]
        TextCSS,

        /// <summary>
        /// (File API) JavaScript text.
        /// </summary>
        [EnumMember(Value = "text/javascript")]
        TextJavaScript,

        /// <summary>
        /// (File API) TypeScript text.
        /// </summary>
        [EnumMember(Value = "text/x-typescript")]
        TextXTypeScript,

        /// <summary>
        /// (File API) CSV text.
        /// </summary>
        [EnumMember(Value = "text/csv")]
        TextCSV,

        /// <summary>
        /// (File API) Markdown text.
        /// </summary>
        [EnumMember(Value = "text/markdown")]
        TextMarkdown,

        /// <summary>
        /// (File API) Python text.
        /// </summary>
        [EnumMember(Value = "text/x-python")]
        TextXPython,

        /// <summary>
        /// (File API) XML text.
        /// </summary>
        [EnumMember(Value = "text/xml")]
        TextXML,

        /// <summary>
        /// (File API) RTF text.
        /// </summary>
        [EnumMember(Value = "text/rtf")]
        TextRTF,

        /// <summary>
        /// (File API) Application JavaScript content.
        /// </summary>
        [EnumMember(Value = "application/x-javascript")]
        ApplicationXJavaScript,

        /// <summary>
        /// (File API) Application TypeScript content.
        /// </summary>
        [EnumMember(Value = "application/x-typescript")]
        ApplicationXTypeScript,

        /// <summary>
        /// (File API) Application Python content.
        /// </summary>
        [EnumMember(Value = "application/x-python-code")]
        ApplicationXPython,

        /// <summary>
        /// (File API) Application JSON content.
        /// </summary>
        [EnumMember(Value = "application/json")]
        ApplicationJSON,

        /// <summary>
        /// (File API) Application RTF content.
        /// </summary>
        [EnumMember(Value = "application/rtf")]
        ApplicationRTF,

        /// <summary>
        /// (File API) Application PDF content.
        /// </summary>
        [EnumMember(Value = "application/pdf")]
        ApplicationPDF,
    }
}