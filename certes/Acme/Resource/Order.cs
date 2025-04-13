using System;
using System.Collections.Generic;
#if NET8_0_OR_GREATER
using System.Text.Json.Serialization;
#else
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
#endif

namespace Certes.Acme.Resource
{
    /// <summary>
    /// Represents the ACME Order resource.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        /// <remarks>
        /// See <see cref="OrderStatus"/> for possible values.
        /// </remarks>
#if !NET8_0_OR_GREATER
        [JsonProperty("status")]
#endif
        public OrderStatus? Status { get; set; }

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
        /// Gets or sets the identifiers.
        /// </summary>
        /// <value>
        /// The identifiers.
        /// </value>
        public IList<Identifier> Identifiers { get; set; }

        /// <summary>
        /// Gets or sets the not before.
        /// </summary>
        /// <value>
        /// The not before.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("notBefore")]
#endif
        public DateTimeOffset? NotBefore { get; set; }

        /// <summary>
        /// Gets or sets the not after.
        /// </summary>
        /// <value>
        /// The not after.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("notAfter")]
#endif
        public DateTimeOffset? NotAfter { get; set; }

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        /// <remarks>
        /// TODO: model https://tools.ietf.org/html/rfc7807
        /// </remarks>
#if !NET8_0_OR_GREATER
        [JsonProperty("error")]
#endif
        public object Error { get; set; }

        /// <summary>
        /// Gets or sets the authorizations.
        /// </summary>
        /// <value>
        /// The authorizations.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("authorizations")]
#endif
        public IList<Uri> Authorizations { get; set; }

        /// <summary>
        /// Gets or sets the finalize.
        /// </summary>
        /// <value>
        /// The finalize.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("finalize")]
#endif
        public Uri Finalize { get; set; }

        /// <summary>
        /// Gets or sets the certificate.
        /// </summary>
        /// <value>
        /// The certificate.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("certificate")]
#endif
        public Uri Certificate { get; set; }

        /// <summary>
        /// Represents the payload to finalize an order.
        /// </summary>
        /// <seealso cref="Certes.Acme.Resource.Order" />
        internal class Payload : Order
        {
            /// <summary>
            /// Gets or sets the CSR.
            /// </summary>
            /// <value>
            /// The CSR.
            /// </value>
#if NET8_0_OR_GREATER
            public string Csr { get; set; }
#else
            [JsonProperty("csr")]
            internal string Csr { get; set; }
#endif
        }
    }
}
