#if !NET8_0_OR_GREATER
using Newtonsoft.Json;
#endif

namespace Certes.Acme.Resource
{
    /// <summary>
    /// Represents the identifier for <see cref="Authorization"/>.
    /// </summary>
    public class Identifier
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("type")]
#endif
        public IdentifierType Type { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("value")]
#endif
        public string Value { get; set; }
    }
}
