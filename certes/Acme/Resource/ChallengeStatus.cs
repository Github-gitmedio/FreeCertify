#if !NET8_0_OR_GREATER
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
#endif

namespace Certes.Acme.Resource
{
    /// <summary>
    /// Represents the status for <see cref="Challenge"/>.
    /// </summary>
#if NET8_0_OR_GREATER
    [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter<ChallengeStatus>))]
#else
    [JsonConverter(typeof(StringEnumConverter))]
#endif
    public enum ChallengeStatus
    {
        /// <summary>
        /// The pending status.
        /// </summary>
#if !NET8_0_OR_GREATER
        [JsonProperty("pending")]
#endif
        Pending,

        /// <summary>
        /// The processing status.
        /// </summary>
#if !NET8_0_OR_GREATER
        [JsonProperty("processing")]
#endif
        Processing,

        /// <summary>
        /// The valid status.
        /// </summary>
#if !NET8_0_OR_GREATER
        [JsonProperty("valid")]
#endif
        Valid,

        /// <summary>
        /// The invalid status.
        /// </summary>
#if !NET8_0_OR_GREATER
        [JsonProperty("invalid")]
#endif
        Invalid,
    }
}
