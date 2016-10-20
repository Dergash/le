using System;
using System.IO;
using NUnit.Framework;

using LE;

namespace LETest {

    [TestFixture]
    public class FontTest {
        const String pathToFreetype = "freetype6.dll";
        const String pathToFont = "assets/fonts/Now-Regular.otf";

        [SetUp]
        public void FixtureSetUp() {
            if (!File.Exists(pathToFreetype)) {
                Assert.Ignore($"There is no {pathToFreetype} in root folder, required for font testing. Test ignored.");
            }
            if (!File.Exists(pathToFont)) {
                Assert.Ignore($"There is no font sample (expecting {pathToFont}). Test ignored.");
            }
        }

        [Test]
        public void getFaceTest() {
            var font = new Font(pathToFont).getFace();
            Assert.IsNotNull(font);
        }

        [Test]
        public void getLetterBitmapTest() {
             var font = new Font(pathToFont);
             Assert.Throws(typeof(NotImplementedException), () => {
                 var bitmap = font.getLetterBitmap('a', 8);
             });
        }
    }
}