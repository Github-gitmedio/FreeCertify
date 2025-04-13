#if !NET8_0_OR_GREATER
using Newtonsoft.Json;
#endif

namespace Certes.Jws
{
    /// <summary>
    /// Represents a JWK using RSA.
    /// </summary>
    /// <seealso cref="Certes.Jws.JsonWebKey" />
    internal class RsaJsonWebKey : JsonWebKey
    {
        /// <summary>
        /// Gets or sets the exponent value for the RSA public key.
        /// </summary>
        /// <value>
        /// The exponent value for the RSA public key.
        /// </value>
#if NET8_0_OR_GREATER
        [System.Text.Json.Serialization.JsonPropertyName("e")]
        [System.Text.Json.Serialization.JsonPropertyOrder(1)]
        public string Exponent { get; set; }
#else
        [JsonProperty("e", Order = 1)]
        internal string Exponent { get; set; }
#endif

        /// <summary>
        /// Gets or sets the modulus value for the RSA public key.
        /// </summary>
        /// <value>
        /// The modulus value for the RSA public key.
        /// </value>
#if NET8_0_OR_GREATER
        [System.Text.Json.Serialization.JsonPropertyName("n")]
        [System.Text.Json.Serialization.JsonPropertyOrder(3)]
        public string Modulus { get; set; }
#else
        [JsonProperty("n", Order = 3)]
        internal string Modulus { get; set; }
#endif
    }
}
