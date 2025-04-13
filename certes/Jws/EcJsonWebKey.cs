#if !NET8_0_OR_GREATER
using Newtonsoft.Json;
#endif

namespace Certes.Jws
{
    /// <summary>
    /// Represents a JWK using Elliptic Curve.
    /// </summary>
    /// <seealso cref="Certes.Jws.JsonWebKey" />
    internal class EcJsonWebKey : JsonWebKey
    {
        /// <summary>
        /// Gets or sets the curve identifies the cryptographic curve used with the key.
        /// </summary>
        /// <value>
        /// The curve identifies the cryptographic curve used with the key.
        /// </value>
#if NET8_0_OR_GREATER
        [System.Text.Json.Serialization.JsonPropertyName("crv")]
        [System.Text.Json.Serialization.JsonPropertyOrder(1)]
        public string Curve { get; set; }
#else
        [JsonProperty("crv", Order = 1)]
        internal string Curve { get; set; }
#endif

        /// <summary>
        /// Gets or sets the x coordinate for the Elliptic Curve point.
        /// </summary>
        /// <value>
        /// The x coordinate for the Elliptic Curve point.
        /// </value>
#if NET8_0_OR_GREATER
        [System.Text.Json.Serialization.JsonPropertyName("x")]
        [System.Text.Json.Serialization.JsonPropertyOrder(3)]
        public string X { get; set; }
#else
        [JsonProperty("x", Order = 3)]
        internal string X { get; set; }
#endif

        /// <summary>
        /// Gets or sets the y coordinate for the Elliptic Curve point.
        /// </summary>
        /// <value>
        /// The y coordinate for the Elliptic Curve point.
        /// </value>
#if NET8_0_OR_GREATER
        [System.Text.Json.Serialization.JsonPropertyName("y")]
        [System.Text.Json.Serialization.JsonPropertyOrder(4)]
        public string Y { get; set; }
#else
        [JsonProperty("y", Order = 4)]
        internal string Y { get; set; }
#endif
    }
}
