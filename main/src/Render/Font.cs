using System;

using SharpFont;

namespace LE {
    public class Font {

        Face face;
        private OpenTK.Color color;

        public OpenTK.Color Color {
            get {
                return color;
            }
            set {
                this.Atlas = changeAtlasColor(this.Atlas, value);
            }
        }

        public Bitmap[] Atlas;

        public Font(String pathToFont) {
            this.color = new OpenTK.Color(255, 255, 255, 255);
            Library library = new Library();
            this.face = new Face(library, pathToFont);
        }

        Face getFace() {
            return this.face;
        }

        public void initAtlas(uint size) {
            var atlas = new Bitmap[255];
            for (char asciiCode = (char)0; asciiCode < 255; asciiCode++) {
                atlas[asciiCode] = getLetterBitmap(asciiCode, size);
            }
            this.Atlas = atlas;
        }

        public Bitmap[] changeAtlasColor(Bitmap[] sourceAtlas, OpenTK.Color color) {
            var atlasWithNewColor = new Bitmap[sourceAtlas.Length];
            for (uint letterIndex = 0; letterIndex < sourceAtlas.Length; letterIndex++) {
                if (sourceAtlas[letterIndex].Format == BitmapFormat.Monochrome) {
                    atlasWithNewColor[letterIndex] = colorizeMonochromeLetter(color, sourceAtlas[letterIndex]);
                } else {
                    throw new NotImplementedException();
                }
            }
            return atlasWithNewColor;
        }

        public Bitmap getTextBitmap(String text) {
            Bitmap[] letters = new Bitmap[text.Length];
            for (int i = 0; i < text.Length; i++) {
                letters[i] = this.Atlas[text[i]];
            }
            return letters[0];
        }

        Bitmap getLetterBitmap(char letter, uint size) {
            this.face.SetCharSize(0, (float)size, 0, 96);
            uint glyphIndex = this.face.GetCharIndex(letter);
            this.face.LoadGlyph(glyphIndex, SharpFont.LoadFlags.Render, SharpFont.LoadTarget.Mono);
            var result = getBitmapFromFTBitmap(this.face.Glyph.Bitmap);
            return result;
        }

        Bitmap getBitmapFromFTBitmap(FTBitmap FTBitmap) {   
            if (FTBitmap.PixelMode != PixelMode.Mono) {
                throw new NotImplementedException();
            }
            uint targetTextureSize = (uint)(FTBitmap.Rows * FTBitmap.Width);
            byte[] targetTextureBytes = new byte[targetTextureSize];

            // Based on Dan Bader's python example
            for (uint sourceRowsIndex = 0; sourceRowsIndex < FTBitmap.Rows; sourceRowsIndex++) {
                for (uint sourcePitchIndex = 0; sourcePitchIndex < FTBitmap.Pitch; sourcePitchIndex++) {
                    byte sourceByte = FTBitmap.BufferData[sourceRowsIndex * FTBitmap.Pitch + sourcePitchIndex];
                    int bitsDone = (int)sourcePitchIndex * 8;
                    int rowStart = (int)sourceRowsIndex * (int)FTBitmap.Width + (int)sourcePitchIndex * 8;
                    int limit = ((int)FTBitmap.Width - bitsDone) < 8 ? FTBitmap.Width - bitsDone : 8;
                    for (uint bitIndex = 0; bitIndex < limit; bitIndex++) {
                        bool bit = Convert.ToBoolean(sourceByte & (1 << (7 - (int)bitIndex)));
                        targetTextureBytes[rowStart + bitIndex] = (bit) ? (byte)0xFF : (byte)0x00;
                    }
                }
            }
            return new Bitmap(BitmapFormat.Monochrome, (uint)FTBitmap.Width, (uint)FTBitmap.Rows, targetTextureBytes);
        }

        Bitmap colorizeMonochromeLetter(OpenTK.Color color, Bitmap letter) {
            return Bitmap.convertMonochromeToBGRA(letter, color);
        }
    }
}
