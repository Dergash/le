using System; 
using System.IO;

namespace LE {
    public class LegacyCreatureReaderBG : LegacyCreatureReader {
        const uint genderOffset = 0x00000237; 
        public override Creature readFromLegacy(byte[] binary) {
            if(!base.isSignatureValid(binary)) {
                throw new FormatException();
            }
            var creature = new Creature();
            creature.Gender = this.getGender(binary);
            return creature;
        }

        public Gender getGender(byte[] binary) {
            if(binary != null && genderOffset <= binary.Length) {    
                return (Gender)binary[genderOffset];
            }
            return Gender.UNKNOWN;
        }
    }
}