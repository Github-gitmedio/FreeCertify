#if !NET8_0_OR_GREATER
using Newtonsoft.Json;
#endif
using System;

namespace Certes.Acme.Resource
{
    /// <summary>
    /// Represents a challenge for <see cref="Identifier"/>.
    /// </summary>
    public class Challenge
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
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("url")]
#endif
        public Uri Url { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("status")]
#endif
        public ChallengeStatus? Status { get; set; }

        /// <summary>
        /// Gets or sets the validation time.
        /// </summary>
        /// <value>
        /// The validation time.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("validated")]
#endif
        public DateTimeOffset? Validated { get; set; }

        /// <summary>
        /// Gets or sets the error.
        /// Only if the status is invalid
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("error")]
#endif
        public AcmeError Error { get; set; }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("token")]
#endif
        public string Token { get; set; }
    }
}
