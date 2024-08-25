using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UGemini.FileAPI
{
    /// <summary>
    /// States for the lifecycle of a File.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiFileState
    {
        /// <summary>
        /// The default value. This value is used if the state is omitted.
        /// </summary>
        [EnumMember(Value = "STATE_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// File is being processed and cannot be used for inference yet.
        /// </summary>
        [EnumMember(Value = "PROCESSING")]
        Processing,

        /// <summary>
        /// File is processed and available for inference.
        /// </summary>
        [EnumMember(Value = "ACTIVE")]
        Active,

        /// <summary>
        /// File failed processing.
        /// </summary>
        [EnumMember(Value = "FAILED")]
        Failed,
    }
}
