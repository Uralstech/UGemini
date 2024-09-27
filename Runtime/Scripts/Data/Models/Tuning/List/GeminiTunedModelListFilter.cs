using System.Runtime.Serialization;

namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// Simple filter to get models by account authorization.
    /// </summary>
    public enum GeminiTunedModelListFilter
    {
        /// <summary>
        /// Default value.
        /// </summary>
        None,

        /// <summary>
        /// Returns all tuned models to which caller has owner role.
        /// </summary>
        [EnumMember(Value = "owner:me")]
        IAmOwner,

        /// <summary>
        /// Returns all tuned models to which caller has writer role.
        /// </summary>
        [EnumMember(Value = "writers:me")]
        IAmWriter,

        /// <summary>
        /// Returns all tuned models to which caller has reader role.
        /// </summary>
        [EnumMember(Value = "readers:me")]
        IAmReader,

        /// <summary>
        /// Returns all tuned models to which caller has reader role.
        /// </summary>
        [EnumMember(Value = "readers:everyone")]
        EveryoneIsReader
    }
}
