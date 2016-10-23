using System;
using System.Runtime.InteropServices;

using SharpFont;
using ImageProcessorCore;

namespace LE {
    public class Font {
        Face face;
        public Font(String pathToFont) {
            Library library = new Library();
            this.face = new Face(library, pathToFont);
        }
        public Face getFace() {
            return this.face;
        }

        public Bitmap getLetterBitmap(char letter, uint size) {
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
    }
}