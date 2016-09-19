using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace LE {
    public static class Utils {
        public static byte[] readBinary(FileStream fileStream) {
            using(var memoryStream = new MemoryStream()) {
                fileStream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public static byte[] readByteArray(byte[] block, uint offset, uint size) {
            byte[] result = new byte[size];
            if(block != null && offset <= block.Length + size) {
                for(uint i = offset, j = 0; i < offset + size; i++, j++) {
                    result[j] = block[i];
                }
                return result;
            }
            return new byte[0];
        }

        public static String readCharArray(byte[] block, uint offset, uint size) {
            byte[] buffer = readByteArray(block, offset, size);
            return System.Text.Encoding.ASCII.GetString(buffer);
        }

        public static Byte[] readLegacyField(string fieldName, byte[] binary, IEnumerable<LegacyField> fields) {
            LegacyField field = fields.First(x => x.name == fieldName);  
            uint offset = field.offset;
            uint size = field.size;
            return readByteArray(binary, offset, size);
        }

        public static String readLegacyFieldAsString(string fieldName, byte[] binary, IEnumerable<LegacyField> fields) {
            LegacyField field = fields.First(x => x.name == fieldName);  
            uint offset = field.offset;
            uint size = field.size;
            return readCharArray(binary, offset, size);
        }
    }
}