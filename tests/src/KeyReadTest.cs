using System;
using System.IO;
//using NUnit.Framework;
using LE;

namespace LETest {
    // [TestFixture]
    public class KeyReadTest {
        
        // [Test]
        public void testRead() {
            string srcGameDir = Config.Root["Game:SourceGamePath"];
            if (srcGameDir == null) {
             //    Assert.Ignore("Source game path is not set; skip");
                return;
            } 
            string keyFilePath = Path.Combine(srcGameDir, "Chitin.key");
            var reader = new LegacyKeyReader();
            var key = reader.Read(File.ReadAllBytes(keyFilePath));
           //  Assert.NotZero(key.BifEntriesCount, "Can read BIF entries count from KEY file");
        }
    }
}