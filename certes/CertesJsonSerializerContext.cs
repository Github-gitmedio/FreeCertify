#if NET8_0_OR_GREATER
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Certes.Acme;
using Certes.Acme.Resource;
using Certes.Jws;

namespace Certes;

[JsonSerializable(typeof(IKey))]
[JsonSerializable(typeof(JsonWebKey))]
[JsonSerializable(typeof(SerializableObjects.Header))]
[JsonSerializable(typeof(SerializableObjects.ProtectedHeader))]
[JsonSerializable(typeof(SerializableObjects.ProtectedHeaderEC))]
[JsonSerializable(typeof(SerializableObjects.ProtectedHeaderRsa))]
[JsonSerializable(typeof(SerializableObjects.KeyChangeEC))]
[JsonSerializable(typeof(SerializableObjects.KeyChangeRsa))]
[JsonSerializable(typeof(AcmeError))]
[JsonSerializable(typeof(JwsPayload))]

[JsonSerializable(typeof(Account))]
[JsonSerializableAttribute(typeof(Order.Payload), TypeInfoPropertyName = "AccountPayload")]
[JsonSerializable(typeof(Account.Payload))]

[JsonSerializable(typeof(Order))]
[JsonSerializableAttribute(typeof(Order.Payload), TypeInfoPropertyName = "OrderPayload")]
[JsonSerializable(typeof(Order.Payload))]

[JsonSerializable(typeof(CertificateRevocation))]
[JsonSerializable(typeof(Authorization))]
[JsonSerializable(typeof(EmptyResource))]
[JsonSerializable(typeof(Directory))]
[JsonSerializable(typeof(EcJsonWebKey))]
[JsonSerializable(typeof(RsaJsonWebKey))]
[JsonSourceGenerationOptions(
    PropertyNameCaseInsensitive = true,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault)]
internal partial class CertesJsonSerializerContext : JsonSerializerContext
{

}
#endif
