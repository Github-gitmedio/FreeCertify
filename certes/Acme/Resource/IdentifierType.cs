using System;

#if NET8_0_OR_GREATER
using System.Text.Json;
using System.Text.Json.Serialization;
#else
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
#endif

namespace Certes.Acme.Resource
{
    /// <summary>
    /// Represents type of <see cref="Identifier"/>.
    /// </summary>
#if NET8_0_OR_GREATER
    [JsonConverter(typeof(IdentifierTypeJsonConverter))]
#else
    [JsonConverter(typeof(StringEnumConverter))]
#endif
    public enum IdentifierType
    {
#if NET8_0_OR_GREATER
        /// <summary>
        /// An unknown type.
        /// </summary>
        Unknown,
#endif

        /// <summary>
        /// The DNS type.
        /// </summary>
#if !NET8_0_OR_GREATER
        [EnumMember(Value = "dns")]
#endif
        Dns
    }

#if NET8_0_OR_GREATER
    /// <summary>
    /// Custom Json converter for <see cref="Identifier"/>.
    /// </summary>
    public class IdentifierTypeJsonConverter : JsonConverter<IdentifierType>
    {
        /// <summary>
        /// Convert from string to <see cref="Identifier"/>.
        /// </summary>
        public override IdentifierType Read(
            ref Utf8JsonReader _,
            Type __,
            JsonSerializerOptions ___) => IdentifierType.Dns;

        /// <summary>
        /// Convert from <see cref="Identifier"/> to string
        /// </summary>
        public override void Write(
            Utf8JsonWriter writer,
            IdentifierType _,
            JsonSerializerOptions __)
        {
            writer.WriteStringValue("dns");
        }
    }
#endif
}
