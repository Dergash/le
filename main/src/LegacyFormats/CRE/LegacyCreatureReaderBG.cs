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
            if (!base.isSignatureValid(binary)) {
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
            creature.Luck = base.getLuck(binary);
            creature.Fallen = base.getFallenStatus(binary);
            creature.Race = getRace(binary);
            creature.Class = getClass(binary);
            creature.Kit = getKit(binary);
            return creature;
        }

        public Race getRace(byte[] binary) {
            uint offset = this.fields.First(field => field.name == "Race").offset;
            if (binary != null && offset <= binary.Length) {
                switch ((LegacyRace)binary[offset]) {
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

        public List<Class> getClass(byte[] binary) {
            var result = new List<Class>();
            uint offset = this.fields.First(field => field.name == "Class").offset;
            if (binary != null && offset <= binary.Length) {
                switch ((LegacyClass)binary[offset]) {
                    case LegacyClass.FIGHTER:
                        result.Add(Class.Fighter);
                        break;
                    case LegacyClass.THIEF:
                        result.Add(Class.Thief);
                        break;
                    case LegacyClass.CLERIC:
                        result.Add(Class.Cleric);
                        break;
                    case LegacyClass.MAGE:
                        result.Add(Class.Mage);
                        break;
                    case LegacyClass.PALADIN:
                        result.Add(Class.Paladin);
                        break;
                    case LegacyClass.RANGER:
                        result.Add(Class.Ranger);
                        break;
                    case LegacyClass.BARD:
                        result.Add(Class.Bard);
                        break;
                    case LegacyClass.FIGHTER_THIEF:
                        result.Add(Class.Fighter);
                        result.Add(Class.Thief);
                        break;
                    case LegacyClass.FIGHTER_CLERIC:
                        result.Add(Class.Fighter);
                        result.Add(Class.Cleric);
                        break;
                    case LegacyClass.FIGHTER_MAGE:
                        result.Add(Class.Fighter);
                        result.Add(Class.Mage);
                        break;
                    case LegacyClass.FIGHTER_DRUID:
                        result.Add(Class.Fighter);
                        result.Add(Class.Druid);
                        break;
                    case LegacyClass.FIGHTER_MAGE_CLERIC:
                        result.Add(Class.Fighter);
                        result.Add(Class.Mage);
                        result.Add(Class.Cleric);
                        break;
                    case LegacyClass.FIGHTER_MAGE_THIEF:
                        result.Add(Class.Fighter);
                        result.Add(Class.Mage);
                        result.Add(Class.Thief);
                        break;
                    case LegacyClass.CLERIC_MAGE:
                        result.Add(Class.Cleric);
                        result.Add(Class.Thief);
                        break;
                    case LegacyClass.CLERIC_THIEF:
                        result.Add(Class.Cleric);
                        result.Add(Class.Thief);
                        break;
                    case LegacyClass.CLERIC_RANGER:
                        result.Add(Class.Cleric);
                        result.Add(Class.Ranger);
                        break;
                    case LegacyClass.MAGE_THIEF:
                        result.Add(Class.Mage);
                        result.Add(Class.Thief);
                        break;
                    case LegacyClass.DRIZZT:
                        result.Add(Class.Ranger);
                        break;
                    case LegacyClass.SAREVOK:
                        result.Add(Class.Fighter);
                        break;
                    case LegacyClass.VOLO:
                        result.Add(Class.Mage);
                        break;
                    case LegacyClass.ELMINSTER:
                        result.Add(Class.Mage);
                        break;
                    default:
                        result.Add(Class.Monster);
                        break;
                }
            }
            else {  
                result.Add(Class.Monster);
            }
            return result;
        }

        public Kit getKit(byte[] binary) {
            uint offset = this.fields.First(field => field.name == "Kit").offset;
            if (binary != null && offset <= binary.Length) {
                switch ((LegacyKit)BitConverter.ToInt32(binary, (int)offset)) {
                    case LegacyKit.ABJURER: return Kit.Abjurer;
                    case LegacyKit.CONJURER: return Kit.Conjurer;
                    case LegacyKit.DIVINER: return Kit.Diviner;
                    case LegacyKit.ENCHANTER: return Kit.Enchanter;
                    case LegacyKit.ILLUSIONIST: return Kit.Illusionist;
                    case LegacyKit.INVOKER: return Kit.Invoker;
                    case LegacyKit.NECROMANCER: return Kit.Necromancer;
                    case LegacyKit.TRANSMUTER: return Kit.Transmuter;
                    default: return Kit.None;
                }
            }
            return Kit.None;
        }
    }
}
