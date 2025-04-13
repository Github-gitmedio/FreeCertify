#if NET8_0_OR_GREATER
using System;
using Certes.Jws;

namespace Certes.Acme;

internal class SerializableObjects
{
    internal class Header
    {
        public string Alg { get; set; } = "";
        public string Kid { get; set; } = "";
        public Uri Url { get; set; }
    }

    internal class ProtectedHeader
    {
        public string Alg { get; set; } = "";
        public Uri Kid { get; set; }
        public string Nonce { get; set; } = "";
        public Uri Url { get; set; }
    }

    internal class ProtectedHeaderEC
    {
        public string Alg { get; set; } = "";
        public EcJsonWebKey Jwk { get; set; }
        public string Nonce { get; set; } = "";
        public Uri Url { get; set; }
    }

    internal class ProtectedHeaderRsa
    {
        public string Alg { get; set; } = "";
        public RsaJsonWebKey Jwk { get; set; }
        public string Nonce { get; set; } = "";
        public Uri Url { get; set; }
    }

    internal class KeyChangeEC
    {
        public Uri Account { get; set; }
        public EcJsonWebKey OldKey { get; set; }
    }

    internal class KeyChangeRsa
    {
        public Uri Account { get; set; }
        public RsaJsonWebKey OldKey { get; set; }
    }
}
#endif
