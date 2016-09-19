using System;
using System.Collections.Generic;
using System.Linq;

namespace LE {
    public abstract class LegacyCreatureReader : ILegacyReader<Creature> {
        public IEnumerable<LegacyField> fields { get; set; }
        public abstract Creature readFromLegacy(byte[] binary);
        protected Boolean isSignatureValid(byte[] binary) {
            string signature = Utils.readLegacyFieldAsString("Signature", binary, fields);
            return signature == LegacyFields.CreatureSignature;
        }
        
        protected Gender getGender(byte[] binary) {
            uint offset = this.fields.First(field => field.name == "Gender").offset;
            if(binary != null && offset <= binary.Length) {    
                return (Gender)binary[offset];
            }
            return Gender.UNKNOWN;
        }
    }
}