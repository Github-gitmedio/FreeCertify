#if !NET8_0_OR_GREATER
using Newtonsoft.Json;
#endif
using System;
using System.Collections.Generic;

namespace Certes.Acme.Resource
{
    /// <summary>
    /// Represents the ACME Account resource.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <remarks>
        /// See <see cref="AccountStatus"/> for possible values.
        /// </remarks>
        /// <value>
        /// The status.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("status")]
#endif
        public AccountStatus? Status { get; set; }

        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        /// <value>
        /// The contact.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("contact")]
#endif
        public IList<string> Contact { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the terms of service is agreed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the terms of service is agreed; otherwise, <c>false</c>.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("termsOfServiceAgreed")]
#endif
        public bool? TermsOfServiceAgreed { get; set; }


        /// <summary>
        /// Gets or sets an external account binding
        /// </summary>
        /// <value>
        ///  
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("externalAccountBinding")]
#endif
        public object ExternalAccountBinding { get; set; }

        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        /// <value>
        /// The orders.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("orders")]
#endif
        public Uri Orders { get; set; }

        /// <summary>
        /// Represents the payload to retrieve existing account by key.
        /// </summary>
        /// <seealso cref="Certes.Acme.Resource.Account" />
        internal class Payload : Account
        {
            /// <summary>
            /// Gets or sets the only return existing flag.
            /// </summary>
            /// <value>
            /// The only return existing flag.
            /// </value>
#if !NET8_0_OR_GREATER
            [JsonProperty("onlyReturnExisting")]
#endif
            internal bool? OnlyReturnExisting { get; set; }
        }
    }
}
