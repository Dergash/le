using System;
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
            throw new NotImplementedException();
            // SharpFont provides ToGdipBitmap for converting to GDI+ bitmap
            // which we should replace by our conversion to ImageProcessor.Image;
            // We also can skip ImageProcessor and convert directly to a Texture

            // Conversion sample from SharpFont src:

            /*
            case PixelMode.Mono:
				{
					Bitmap bmp = new Bitmap(rec.width, rec.rows, PixelFormat.Format1bppIndexed);
					var locked = bmp.LockBits(new Rectangle(0, 0, rec.width, rec.rows), ImageLockMode.ReadWrite, PixelFormat.Format1bppIndexed);

					for (int i = 0; i < rec.rows; i++)
						PInvokeHelper.Copy(Buffer, i * rec.pitch, locked.Scan0, i * locked.Stride, locked.Stride);

					bmp.UnlockBits(locked);

					ColorPalette palette = bmp.Palette;
					palette.Entries[0] = Color.FromArgb(0, color);
					palette.Entries[1] = Color.FromArgb(255, color);

					bmp.Palette = palette;
					return bmp;
				}
            */

            // So we probably should use width, rows and Marshal.Copy to get our pixels info
        }
    }
}