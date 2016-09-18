using System;
using System.IO;

namespace LE {
    public abstract class LegacyCreatureReader : ILegacyReader<Creature> {
        const uint signatureOffset = 0x00000000;
        const uint signatureSize = 4;
        const string signature = "CRE ";
        public abstract Creature readFromLegacy(byte[] binary);
        protected Boolean isSignatureValid(byte[] binary) {
            string signature = Utils.readCharArray(binary, signatureOffset, signatureSize);
            return signature == LegacyCreatureReader.signature;
        }
    }
}