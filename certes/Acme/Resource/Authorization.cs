#if !NET8_0_OR_GREATER
using Newtonsoft.Json;
#endif
using System;
using System.Collections.Generic;

namespace Certes.Acme.Resource
{
    /// <summary>
    /// Represents the ACME Authorization resource.
    /// </summary>
    public class Authorization
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("identifier")]
#endif
        public Identifier Identifier { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("status")]
#endif
        public AuthorizationStatus? Status { get; set; }

        /// <summary>
        /// Gets or sets the expires.
        /// </summary>
        /// <value>
        /// The expires.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("expires")]
#endif
        public DateTimeOffset? Expires { get; set; }

        /// <summary>
        /// Gets or sets the scope.
        /// </summary>
        /// <value>
        /// The scope.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("scope")]
#endif
        public Uri Scope { get; set; }

        /// <summary>
        /// Gets or sets the challenges.
        /// </summary>
        /// <value>
        /// The challenges.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("challenges")]
#endif
        public IList<Challenge> Challenges { get; set; }

        /// <summary>
        /// Gets or sets the flag indicating if this authorization is for wildcard.
        /// </summary>
        /// <value>
        /// The flag indicating if this authorization is for wildcard.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("wildcard")]
#endif
        public bool? Wildcard { get; set; }

    }
}
