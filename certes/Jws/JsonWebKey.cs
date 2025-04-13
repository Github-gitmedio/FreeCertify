#if !NET8_0_OR_GREATER
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
#endif

namespace Certes.Jws
{
    /// <summary>
    /// Represents and JSON web key. 
    /// Note that inheriting classes must define JSON serialisation order to maintain lexographic order as per https://tools.ietf.org/html/rfc7638#page-8
    /// </summary>
    public class JsonWebKey
    {
        /// <summary>
        /// Gets or sets the type of the key.
        /// </summary>
        /// <value>
        /// The type of the key.
        /// </value>
#if NET8_0_OR_GREATER
        [System.Text.Json.Serialization.JsonPropertyName("kty")]
        [System.Text.Json.Serialization.JsonPropertyOrder(2)]
        public string KeyType { get; set; }
#else
        [JsonProperty("kty", Order = 2)]
        internal string KeyType { get; set; }
#endif
    }
}
