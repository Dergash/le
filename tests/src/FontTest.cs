using System;
using System.IO;
using Xunit;
using LE;

namespace LETest {
    public class FontTest {
        
        const String pathToFreetype = "freetype6.dll";
        const String pathToFont = "assets/fonts/Now-Regular.otf";

       // [SetUp]
        public void FixtureSetUp() {

          //      Assert.Ignore($"There is no {pathToFreetype} in root folder, required for font testing. Test ignored.");
           // }
           // if (!File.Exists(pathToFont)) {
         //       Assert.Ignore($"There is no font sample (expecting {pathToFont}). Test ignored.");
           // }
        }

        [Fact]
        public void readFontFile() {
            var font = new Font(pathToFont);
            Assert.NotNull(font);
        }

        [Fact]
        public void initAtlas() {
            var font = new Font(pathToFont);
            font.initAtlas(48);
            Assert.True(font != null && font.Atlas.Length == 255);
        }
    }
}
