using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LE {
    public abstract class LegacyCreatureReaderBase : ILegacyReader<Creature> {
        public IEnumerable<LegacyField> fields { get; set; }
        public abstract Creature readFromLegacy(byte[] binary);
        protected Boolean isSignatureValid(byte[] binary) {
            string signature = Utils.readLegacyFieldAsString("Signature", binary, fields);
            return signature == LegacyFields.CreatureSignature;
        }
        protected Alignment getAlignment(byte[] binary) {
            uint offset = this.fields.First(field => field.name == "Alignment").offset;
            if(binary != null && offset <= binary.Length) {   
                switch(binary[offset]) {
                    case 0x00: return Alignment.Neutral;
                    case 0x11: return Alignment.LawfulGood;
                    case 0x12: return Alignment.LawfulNeutral;
                    case 0x13: return Alignment.LawfulEvil;
                    case 0x21: return Alignment.NeutralGood;
                    case 0x22: return Alignment.TrueNeutral;
                    case 0x23: return Alignment.NeutralEvil;
                    case 0x31: return Alignment.ChaoticGood;
                    case 0x32: return Alignment.ChaoticNeutral;
                    case 0x33: return Alignment.ChaoticEvil;
                    default: return Alignment.Neutral;
                } 
            }
            return Alignment.Neutral;
        }
        protected Gender getGender(byte[] binary) {
            uint offset = this.fields.First(field => field.name == "Gender").offset;
            if(binary != null && offset <= binary.Length) {    
                return (Gender)binary[offset];
            }
            return Gender.UNKNOWN;
        }
        protected Strength getStrength(byte[] binary) {
            uint offset = this.fields.First(field => field.name == "Strength").offset;
            if(binary != null && offset <= binary.Length) {
                return new Strength(binary[offset]);
            }
            return new Strength(0);
        }
        protected Dexterity getDexterity(byte[] binary) {
            uint offset = this.fields.First(field => field.name == "Dexterity").offset;
            if(binary != null && offset <= binary.Length) {
                return new Dexterity(binary[offset]);
            }
            return new Dexterity(0);
        }
        protected Constitution getConstitution(byte[] binary) {
            uint offset = this.fields.First(field => field.name == "Constitution").offset;
            if(binary != null && offset <= binary.Length) {
                return new Constitution(binary[offset]);
            }
            return new Constitution(0);
        }
        protected Intelligence getIntelligence(byte[] binary) {
            uint offset = this.fields.First(field => field.name == "Intelligence").offset;
            if(binary != null && offset <= binary.Length) {
                return new Intelligence(binary[offset]);
            }
            return new Intelligence(0);
        }
        protected Wisdom getWisdom(byte[] binary) {
            uint offset = this.fields.First(field => field.name == "Wisdom").offset;
            if(binary != null && offset <= binary.Length) {
                return new Wisdom(binary[offset]);
            }
            return new Wisdom(0);
        }
        protected Charisma getCharisma(byte[] binary) {
            uint offset = this.fields.First(field => field.name == "Charisma").offset;
            if(binary != null && offset <= binary.Length) {
                return new Charisma(binary[offset]);
            }
            return new Charisma(0);
        }
        protected Boolean getFallenStatus(byte[] binary) {
            uint offset = this.fields.First(field => field.name == "CreatureFlags").offset;
            if(binary != null && offset <= binary.Length) {
                byte[] field = Utils.readByteArray(binary, offset, 4);    
                var creatureFlags = new BitArray(field);
                return creatureFlags[(int)LegacyCreatureFlags.FallenRanger]
                    || creatureFlags[(int)LegacyCreatureFlags.FallenPaladin];
            }
            return false;
        }
    }
}