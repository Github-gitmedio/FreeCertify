#if !NET8_0_OR_GREATER
using Newtonsoft.Json;
#endif
using System;
using System.Collections.Generic;

namespace Certes.Acme.Resource
{
    /// <summary>
    /// Represents the ACME Orders List resource.
    /// </summary>
    /// <remarks>
    /// As https://tools.ietf.org/html/draft-ietf-acme-acme-07#section-7.1.2.1
    /// </remarks>
    public class OrderList
    {
        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        /// <value>
        /// The orders.
        /// </value>
#if !NET8_0_OR_GREATER
        [JsonProperty("orders")]
#endif
        public IList<Uri> Orders { get; set; }
    }
}
