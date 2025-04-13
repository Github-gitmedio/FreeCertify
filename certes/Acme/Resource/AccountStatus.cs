#if NET8_0_OR_GREATER
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
#else
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Data.Entity.Core.Metadata.Edm;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#endif

namespace Certes.Acme.Resource
{
    /// <summary>
    /// Represents the status of <see cref="Account"/>.
    /// </summary>
#if NET8_0_OR_GREATER
    [JsonConverter(typeof(AccountStatusJsonConverter))]
#else
    [JsonConverter(typeof(StringEnumConverter))]
#endif
    public enum AccountStatus
    {
        /// <summary>
        /// The valid status.
        /// </summary>
#if !NET8_0_OR_GREATER
        [EnumMember(Value = "valid")]
#endif
        Valid,

        /// <summary>
        /// The deactivated status, initiated by client.
        /// </summary>
#if !NET8_0_OR_GREATER
        [EnumMember(Value = "deactivated")]
#endif
        Deactivated,

        /// <summary>
        /// The revoked status, initiated by server.
        /// </summary>
#if !NET8_0_OR_GREATER
        [EnumMember(Value = "revoked")]
#endif
        Revoked
    }

#if NET8_0_OR_GREATER
    /// <summary>
    /// Custom Json converter for <see cref="AccountStatus"/>.
    /// </summary>
    public class AccountStatusJsonConverter : JsonConverter<AccountStatus>
    {
        /// <summary>
        /// Convert from string to <see cref="AccountStatus"/>.
        /// </summary>
        public override AccountStatus Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            var content = reader.GetString();
            return content switch
            {
                "valid" => AccountStatus.Valid,
                "deactivated" => AccountStatus.Deactivated,
                "revoked" => AccountStatus.Revoked,
                _ => AccountStatus.Valid,
            };
        }

        /// <summary>
        /// Convert from <see cref="AccountStatus"/> to string
        /// </summary>
        public override void Write(
            Utf8JsonWriter writer,
            AccountStatus accountStatus,
            JsonSerializerOptions options)
        {
            var serializedValue = accountStatus switch
            {
                AccountStatus.Valid => "valid",
                AccountStatus.Deactivated => "deactivated",
                AccountStatus.Revoked => "revoked",
                _ => "valid",
            };

            writer.WriteStringValue(serializedValue);
        }
    }
#endif
}
