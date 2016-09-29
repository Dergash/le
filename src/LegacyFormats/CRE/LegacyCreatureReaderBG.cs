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
            creature.Alignment = base.getAlignment(binary);
            creature.Strength = base.getStrength(binary);
            creature.Dexterity = base.getDexterity(binary);
            creature.Constitution = base.getConstitution(binary);
            creature.Intelligence = base.getIntelligence(binary);
            creature.Wisdom = base.getWisdom(binary);
            creature.Charisma = base.getCharisma(binary);
            creature.Fallen = base.getFallenStatus(binary);
            return creature;
        }
    }
}