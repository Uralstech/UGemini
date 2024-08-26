
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UGemini.Models.Content
{
    /// <summary>
    /// The role of a Gemini content creator.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiRole
    {
        /// <summary>
        /// Don't use this.
        /// </summary>
        Unspecified,

        /// <summary>
        /// The content was made by the user.
        /// </summary>
        [EnumMember(Value = "user")]
        User,

        /// <summary>
        /// The content was made by the model.
        /// </summary>
        [EnumMember(Value = "model")]
        Assistant,

        /// <summary>
        /// The content was made by a function.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        [EnumMember(Value = "function")]
        ToolResponse,
    }
}