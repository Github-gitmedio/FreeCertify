#if !NET8_0_OR_GREATER
using Newtonsoft.Json;
#endif

namespace Certes.Acme.Resource
{
    /// <summary>
    /// Represents the payload for certificate revocation.
    /// </summary>
    internal class CertificateRevocation
    {
        /// <summary>
        /// Gets or sets the certificate to be revoked, in the base64url-encoded version of the DER format..
        /// </summary>
        /// <value>
        /// The certificate to be revoked, in the base64url-encoded version of the DER format.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("certificate")]
#endif
        public string Certificate { get; set; }


        /// <summary>
        /// Gets or sets the revocation reason.
        /// </summary>
        /// <value>
        /// The revocation reason.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("reason")]
#endif
        public RevocationReason? Reason { get; set; }
    }
}
