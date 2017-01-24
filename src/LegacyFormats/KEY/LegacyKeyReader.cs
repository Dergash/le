using System;
using System.Linq;

namespace LE {
    class LegacyKeyReader {

        public LegacyKey Read(byte[] binary) {
            int bifEntriesCount = 0; 
            uint offset = LegacyKeyFields.Key.First(field => field.name == "BIFEntriesCount").offset;
            if (binary != null && offset <= binary.Length) {  
                bifEntriesCount = BitConverter.ToInt32(binary, (int)offset);
            }
            return new LegacyKey {
                BifEntriesCount = bifEntriesCount
            };
        }
    }
}