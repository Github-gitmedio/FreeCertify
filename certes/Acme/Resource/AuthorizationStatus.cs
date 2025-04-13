#if NET8_0_OR_GREATER
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
#else
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
#endif

namespace Certes.Acme.Resource
{
    /// <summary>
    /// Represents the status of <see cref="Authorization"/>.
    /// </summary>
#if NET8_0_OR_GREATER
    [JsonConverter(typeof(AuthorizationStatusJsonConverter))]
#else
    [JsonConverter(typeof(StringEnumConverter))]
#endif
    public enum AuthorizationStatus
    {
        /// <summary>
        /// The pending status.
        /// </summary>
#if !NET8_0_OR_GREATER
        [EnumMember(Value = "pending")]
#endif
        Pending,

        /// <summary>
        /// The valid status.
        /// </summary>
#if !NET8_0_OR_GREATER
        [EnumMember(Value = "valid")]
#endif
        Valid,

        /// <summary>
        /// The invalid status.
        /// </summary>
#if !NET8_0_OR_GREATER
        [EnumMember(Value = "invalid")]
#endif
        Invalid,

        /// <summary>
        /// The revoked status.
        /// </summary>
#if !NET8_0_OR_GREATER
        [EnumMember(Value = "revoked")]
#endif
        Revoked,

        /// <summary>
        /// The deactivated status.
        /// </summary>
#if !NET8_0_OR_GREATER
        [EnumMember(Value = "deactivated")]
#endif
        Deactivated,

        /// <summary>
        /// The expired status.
        /// </summary>
#if !NET8_0_OR_GREATER
        [EnumMember(Value = "expired")]
#endif
        Expired,
    }

#if NET8_0_OR_GREATER
    /// <summary>
    /// Custom Json converter for <see cref="AuthorizationStatus"/>.
    /// </summary>
    public class AuthorizationStatusJsonConverter : JsonConverter<AuthorizationStatus>
    {
        /// <summary>
        /// Convert from string to <see cref="AuthorizationStatus"/>.
        /// </summary>
        public override AuthorizationStatus Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            var content = reader.GetString();
            return content switch
            {
                "pending" => AuthorizationStatus.Pending,
                "invalid" => AuthorizationStatus.Invalid,
                "valid" => AuthorizationStatus.Valid,
                "revoked" => AuthorizationStatus.Revoked,
                "deactivated" => AuthorizationStatus.Deactivated,
                "expired" => AuthorizationStatus.Expired,
                _ => AuthorizationStatus.Pending,
            };
        }

        /// <summary>
        /// Convert from <see cref="AuthorizationStatus"/> to string
        /// </summary>
        public override void Write(
            Utf8JsonWriter writer,
            AuthorizationStatus accountStatus,
            JsonSerializerOptions options)
        {
            var serializedValue = accountStatus switch
            {
                AuthorizationStatus.Pending => "pending",
                AuthorizationStatus.Invalid => "invalid",
                AuthorizationStatus.Valid => "valid",
                AuthorizationStatus.Revoked => "revoked",
                AuthorizationStatus.Deactivated => "deactivated",
                AuthorizationStatus.Expired => "expired",
                _ => "pending",
            };

            writer.WriteStringValue(serializedValue);
        }
    }
#endif
}
