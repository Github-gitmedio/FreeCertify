using System;
using System.Text;
using Certes.Acme;
#if !NET8_0_OR_GREATER
using Certes.Json;
using Newtonsoft.Json;
#endif

namespace Certes.Jws
{
    /// <summary>
    /// Represents an signer for JSON Web Signature.
    /// </summary>
    internal class JwsSigner
    {
        private readonly IKey keyPair;

        /// <summary>
        /// Initializes a new instance of the <see cref="JwsSigner"/> class.
        /// </summary>
        /// <param name="keyPair">The keyPair.</param>
        public JwsSigner(IKey keyPair)
        {
            this.keyPair = keyPair;
        }

        /// <summary>
        /// Signs the specified payload.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <param name="nonce">The nonce.</param>
        /// <returns>The signed payload.</returns>
        public JwsPayload Sign(object payload, string nonce)
            => Sign(payload, null, null, nonce);

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <param name="keyId">The key identifier.</param>
        /// <param name="url">The URL.</param>
        /// <param name="nonce">The nonce.</param>
        /// <returns>The signed payload.</returns>
        public JwsPayload Sign(
            object payload,
            Uri keyId = null,
            Uri url = null,
            string nonce = null)
        {
            var protectedHeader = (keyId) == null ?
                (object)new
                {
                    alg = keyPair.Algorithm.ToJwsAlgorithm(),
                    jwk = keyPair.JsonWebKey,
                    nonce,
                    url,
                } :
                new
                {
                    alg = keyPair.Algorithm.ToJwsAlgorithm(),
                    kid = keyId,
                    nonce,
                    url,
                };

#if NET8_0_OR_GREATER
            var entityJson = payload == null ?
               "" :
               System.Text.Json.JsonSerializer.Serialize(payload, payload.GetType(), CertesJsonSerializerContext.Default);

            string protectedHeaderJson;
            if (keyId == null)
            {
                var jwk = keyPair.JsonWebKey;
                if (jwk is EcJsonWebKey)
                {
                    var serializableObject = new SerializableObjects.ProtectedHeaderEC
                    {
                        Alg = keyPair.Algorithm.ToJwsAlgorithm(),
                        Jwk = keyPair.JsonWebKey as EcJsonWebKey,
                        Nonce = nonce,
                        Url = url
                    };

                    protectedHeaderJson = System.Text.Json.JsonSerializer.Serialize(serializableObject, serializableObject.GetType(), CertesJsonSerializerContext.Default);
                }
                else if (jwk is RsaJsonWebKey)
                {
                    var serializableObject = new SerializableObjects.ProtectedHeaderRsa
                    {
                        Alg = keyPair.Algorithm.ToJwsAlgorithm(),
                        Jwk = keyPair.JsonWebKey as RsaJsonWebKey,
                        Nonce = nonce,
                        Url = url
                    };

                    protectedHeaderJson = System.Text.Json.JsonSerializer.Serialize(serializableObject, serializableObject.GetType(), CertesJsonSerializerContext.Default);
                }
                else
                {
                    throw new Exception("JsonWebKey is not serializable");
                }
            }
            else
            {
                var serializableObject = new SerializableObjects.ProtectedHeader
                {
                    Alg = keyPair.Algorithm.ToJwsAlgorithm(),
                    Kid = keyId,
                    Nonce = nonce,
                    Url = url
                };

                protectedHeaderJson = System.Text.Json.JsonSerializer.Serialize(serializableObject, serializableObject.GetType(), CertesJsonSerializerContext.Default);
            }
#else
            var jsonSettings = JsonUtil.CreateSettings();
            var entityJson = payload == null ?
                "" :
                JsonConvert.SerializeObject(payload, Newtonsoft.Json.Formatting.None, jsonSettings);
            var protectedHeaderJson = JsonConvert.SerializeObject(protectedHeader, Newtonsoft.Json.Formatting.None, jsonSettings);
#endif
            var payloadEncoded = JwsConvert.ToBase64String(Encoding.UTF8.GetBytes(entityJson));
            var protectedHeaderEncoded = JwsConvert.ToBase64String(Encoding.UTF8.GetBytes(protectedHeaderJson));

            var signature = $"{protectedHeaderEncoded}.{payloadEncoded}";
            var signatureBytes = Encoding.UTF8.GetBytes(signature);
            var signedSignatureBytes = keyPair.GetSigner().SignData(signatureBytes);
            var signedSignatureEncoded = JwsConvert.ToBase64String(signedSignatureBytes);

            var body = new JwsPayload
            {
                Protected = protectedHeaderEncoded,
                Payload = payloadEncoded,
                Signature = signedSignatureEncoded
            };

            return body;
        }
    }
}
