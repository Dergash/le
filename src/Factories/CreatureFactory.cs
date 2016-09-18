using System;
using System.IO;

namespace LE {
    public class CreatureFactory: ILegacyFactory<Creature> {
        static readonly UInt16 versionOffset = 0x00000004;
        static readonly UInt16 versionSize = 4;
        public Creature importFromLegacy(byte[] binary) {
            byte[] binaryVersion = Utils.readByteArray(binary, versionOffset, versionSize);
            switch(System.Text.Encoding.ASCII.GetString(binaryVersion)) {
                case "V1.0": {
                    return new LegacyCreatureReaderBG().readFromLegacy(binary);
                }
                default: return null;
            }
        }
    }
}