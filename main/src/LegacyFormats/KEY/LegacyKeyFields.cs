/* Thanks to http://gibberlings3.net/iesdp/file_formats/ie_formats/key_v1.htm */

using System;
using System.Collections.Generic;

namespace LE {
    public class LegacyKeyFields {

        public static readonly String KeySignature = "CRE ";
        public static readonly List<LegacyField> Key = new List<LegacyField> {
            new LegacyField(0x0000, 4, "Signature"), 
            new LegacyField(0x0004, 4, "Version"),
            new LegacyField(0x0008, 4, "BIFEntriesCount"),
            new LegacyField(0x000C, 4, "ResourceEntriesCount"),
            new LegacyField(0x0010, 4, "BIFEntriesOffset"),
            new LegacyField(0x0014, 4, "ResourceEntriesOffset"),
        };

        public static readonly List<LegacyField> BifEntry = new List<LegacyField> {
            new LegacyField(0x0000, 4, "FileLength"), 
            new LegacyField(0x0004, 4, "FilenameOffset"),
            new LegacyField(0x0008, 2, "FilenameLength"),
            new LegacyField(0x000A, 2, "Location"),
        };

        public static readonly List<LegacyField> ResourceEntry = new List<LegacyField> {
            new LegacyField(0x0000, 8, "ResourceName"), 
            new LegacyField(0x0008, 2, "ResourceType"),
            new LegacyField(0x0010, 4, "ResourceLocator"),
        };
    }
}