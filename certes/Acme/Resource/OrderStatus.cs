#if !NET8_0_OR_GREATER
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
#endif
using System.Runtime.Serialization;

namespace Certes.Acme.Resource
{
    /// <summary>
    /// Represents the status of <see cref="Order"/>.
    /// </summary>
    /// <remarks>
    /// As https://tools.ietf.org/html/draft-ietf-acme-acme-07#section-7.1.3
    /// </remarks>
#if NET8_0_OR_GREATER
    [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter<OrderStatus>))]
#else
    [JsonConverter(typeof(StringEnumConverter))]
#endif
    public enum OrderStatus
    {
        /// <summary>
        /// The server does not believe that the client has fulfilled the requirements.
        /// Check the "authorizations" array for entries that are still pending.
        /// </summary>
#if !NET8_0_OR_GREATER
        [EnumMember(Value = "pending")]
#endif
        Pending,

        /// <summary>
        /// The server agrees that the requirements have been fulfilled, and is awaiting finalization.
        /// Submit a finalization request.
        /// </summary>
        [EnumMember(Value = "ready")]
        Ready,

        /// <summary>
        /// The certificate is being issued.  Send a POST-as-GET request after the time given in the 
        /// Retry-After header field of the response, if any.
        /// </summary>
#if !NET8_0_OR_GREATER
        [EnumMember(Value = "processing")]
#endif
        Processing,

        /// <summary>
        /// The server has issued the certificate and provisioned its URL to the "certificate" field of the order.
        /// Download the certificate.
        /// </summary>
#if !NET8_0_OR_GREATER
        [EnumMember(Value = "valid")]
#endif
        Valid,

        /// <summary>
        /// The certificate will not be issued.  Consider this order process abandoned.
        /// </summary>
#if !NET8_0_OR_GREATER
        [EnumMember(Value = "invalid")]
#endif
        Invalid,
    }

}
