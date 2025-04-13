#if !NET8_0_OR_GREATER
using Newtonsoft.Json;
#endif

namespace Certes.Jws
{
    /// <summary>
    /// Represents data signed with JWS.
    /// </summary>
    public class JwsPayload
    {
        /// <summary>
        /// Gets or sets the protected.
        /// </summary>
        /// <value>
        /// The protected.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("protected")]
#endif
        public string Protected { get; set; }

        /// <summary>
        /// Gets or sets the payload.
        /// </summary>
        /// <value>
        /// The payload.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("payload")]
#endif
        public string Payload { get; set; }

        /// <summary>
        /// Gets or sets the signature.
        /// </summary>
        /// <value>
        /// The signature.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("signature")]
#endif
        public string Signature { get; set; }
    }

}
