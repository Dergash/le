using System;
using System.IO;

namespace LE {
    public class LegacyCharacter {
        const string signature = "CHR ";
        const uint offsetWithCREOffset = 0x0028;
        const uint lengthOfCREStructure = 0x002c;
        byte[] binary;
        public LegacyCharacter(String CHRFilePath) {
            var character = File.ReadAllBytes(CHRFilePath);;
            if (!isSignatureValid(character)) {
                throw new System.IO.InvalidDataException();
            }
            if (!isCreatureLengthValid(character)) {
                throw new System.IO.InvalidDataException();
            }
            this.binary = character;
        }
        Boolean isSignatureValid(byte[] binary) {
            string signature = Utils.readCharArray(binary, 0, 4);
            return signature == LegacyCharacter.signature;
        }
        Boolean isCreatureLengthValid(byte[] binary) {
            var offset = BitConverter.ToInt32(binary, (int)offsetWithCREOffset);
            var length = BitConverter.ToInt32(binary, (int)lengthOfCREStructure);
            return (binary.Length >= offset + length);
        }
        public Creature getCreature() {
            var offset = (uint)BitConverter.ToInt32(binary, (int)offsetWithCREOffset);
            var length = (uint)BitConverter.ToInt32(binary, (int)lengthOfCREStructure);
            var creatureFactory = new CreatureFactory();
            var creatureBinary = Utils.readByteArray(this.binary, offset, length);
            Creature result = creatureFactory.importFromLegacy(creatureBinary);
            return result;
        }
    }
}