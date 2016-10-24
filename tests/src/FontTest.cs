using System;
using System.IO;
using NUnit.Framework;
using OpenTK;
using OpenTK.Graphics.OpenGL;

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
        public void readFontFile() {
            var font = new Font(pathToFont);
            Assert.NotNull(font);
        }

        [Test]
        public void initAtlas() {
            var font = new Font(pathToFont);
            font.initAtlas(48);
            Assert.That(font != null && font.Atlas.Length == 255);
        }

        

    }
}