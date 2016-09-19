using System; 
using System.Collections.Generic;

namespace LE {
    public class LegacyCreatureReaderBG : LegacyCreatureReader {

        public LegacyCreatureReaderBG() {
            base.fields = LegacyFields.CreatureV1_0;
        }

        public override Creature readFromLegacy(byte[] binary) {
            if(!base.isSignatureValid(binary)) {
                throw new FormatException();
            }
            var creature = new Creature();
            creature.Gender = base.getGender(binary);
            return creature;
        }
    }
}