using System; 
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LE {
    public class LegacyCreatureReaderBG : LegacyCreatureReaderBase {

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
            creature.Race = getRace(binary);
            return creature;
        }

        public Race getRace(byte[] binary) {
            uint offset = this.fields.First(field => field.name == "Race").offset;
            if(binary != null && offset <= binary.Length) {
                switch((LegacyRace)binary[offset]) {
                    case LegacyRace.HUMAN: return Race.Human;
                    case LegacyRace.ELF: return Race.Elf;
                    case LegacyRace.DWARF: return Race.Dwarf;
                    case LegacyRace.GNOME: return Race.Gnome;
                    case LegacyRace.HALF_ELF: return Race.HalfElf;
                    case LegacyRace.HALFLING: return Race.Halfling;
                    default: return Race.Monster;
                }
            }
            return Race.Monster;
        }
    }
}