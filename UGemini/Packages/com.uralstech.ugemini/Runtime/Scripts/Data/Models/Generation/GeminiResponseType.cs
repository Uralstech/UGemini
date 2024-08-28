using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UGemini.Models.Generation
{
    /// <summary>
    /// The response type for Gemini model responses.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiResponseType
    {
        /// <summary>
        /// Unspecified, don't use.
        /// </summary>
        Unspecified,

        /// <summary>
        /// (default) Plain text response type.
        /// </summary>
        [EnumMember(Value = "text/plain")]
        PlainText,

        /// <summary>
        /// JSON response type.
        /// </summary>
        [EnumMember(Value = "application/json")]
        Json,
    }
}