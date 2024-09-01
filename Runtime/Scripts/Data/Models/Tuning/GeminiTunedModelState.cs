using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// The state of the tuned model.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiTunedModelState
    {
        /// <summary>
        /// The default value. This value is unused.
        /// </summary>
        [EnumMember(Value = "STATE_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// The model is being created.
        /// </summary>
        [EnumMember(Value = "CREATING")]
        Creating,

        /// <summary>
        /// 	The model is ready to be used.
        /// </summary>
        [EnumMember(Value = "ACTIVE")]
        Active,

        /// <summary>
        /// The model failed to be created.
        /// </summary>
        [EnumMember(Value = "FAILED")]
        Failed,
    }
}
