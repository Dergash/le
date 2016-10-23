using System;

namespace LE {
    public enum BitmapFormat {
        Monochrome,
        BGR
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
            if (newFormat == BitmapFormat.BGR) {
                return convertToBGR(source);
            }
            throw new NotImplementedException();
        }

        static Bitmap convertToBGR(Bitmap source) {
            if (source.Format == BitmapFormat.Monochrome) {
                byte[] target = new byte[source.Bytes.Length * 3];
                for (uint sourceIndex = 0, targetIndex = 0;
                    sourceIndex < source.Bytes.Length;
                    sourceIndex++, targetIndex += 3) {
                    byte value = (source.Bytes[sourceIndex] == (byte)0x00) ? (byte)0xFF : (byte)0x00;
                    target[targetIndex] = value;
                    target[targetIndex + 1] = value;
                    target[targetIndex + 2] = value;
                }
                return new Bitmap(BitmapFormat.BGR, source.Width, source.Height, target);
            }
            throw new NotImplementedException();
        }
    }
}