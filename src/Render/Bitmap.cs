using System;

namespace LE {
    public enum BitmapFormat {
        Monochrome,
        BGRA
    }

    public struct Bitmap {

        public BitmapFormat Format;
        public uint Width;
        public uint Height;
        public byte[] Bytes;

        public Bitmap(BitmapFormat Format, uint Width, uint Height, byte[] Bytes) {
            this.Format = Format;
            this.Width = Width;
            this.Height = Height;
            this.Bytes = Bytes;
        }

        // TODO : Probably should move this to some image convertor class
        public static Bitmap Convert(Bitmap source, BitmapFormat newFormat) {
            if (source.Format == newFormat) {
                return source;
            }
            if (newFormat == BitmapFormat.BGRA) {
                return convertMonochromeToBGRA(source);
            }
            throw new NotImplementedException();
        }

        public static Bitmap convertMonochromeToBGRA(Bitmap source) {
            return convertMonochromeToBGRA(source, OpenTK.Color.White);
        }

        public static Bitmap convertMonochromeToBGRA(Bitmap source, OpenTK.Color color) {
            if (source.Format == BitmapFormat.Monochrome) {
                byte[] target = new byte[source.Bytes.Length * 4];
                for (uint srcIndex = 0, targetIndex = 0; srcIndex < source.Bytes.Length; srcIndex++, targetIndex += 4) {
                    if (source.Bytes[srcIndex] == (byte)0x00) { // Letter background
                         target[targetIndex + 3] = (byte)0x00;
                    } else { // Letter
                        target[targetIndex] = color.B;
                        target[targetIndex + 1] = color.G;
                        target[targetIndex + 2] = color.R;
                        target[targetIndex + 3] = color.A;
                    }
                }
                return new Bitmap(BitmapFormat.BGRA, source.Width, source.Height, target);
            }
            throw new NotImplementedException();
        }
    }
}
