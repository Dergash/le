using System;
using System.IO;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using Drawing = ImageProcessorCore;

namespace LE {
    public class Texture {

        public readonly int Id;
        public readonly uint Width;
        public readonly uint Height;

        string mockImage = @"assets\missing.png";
        
        public Texture(String Filename) {
            if (String.IsNullOrEmpty(Filename)) {
                throw new ArgumentException(Filename);
            }

            Drawing.Image image;
            if (!File.Exists(Filename)) {
                Filename = mockImage;
            };
            
            using(FileStream stream = File.OpenRead(Filename)) {
                image = new ImageProcessorCore.Image(stream);
            }

            this.Width = (uint)image.Width;
            this.Height = (uint)image.Height;

            byte[] pixels = getBGRFromImage(image);

            this.Id = getTexture(pixels, Width, Height);
        }
        
        public Texture(Bitmap bitmap) {
            this.Width = bitmap.Width;
            this.Height = bitmap.Height;
            if (bitmap.Format != BitmapFormat.BGRA) {
                var bgrBitmap = Bitmap.Convert(bitmap, BitmapFormat.BGRA);
                this.Id = getTexture(bgrBitmap.Bytes, bgrBitmap.Width, bgrBitmap.Height);
            } else {
                this.Id = getTexture(bitmap.Bytes, bitmap.Width, bitmap.Height);
            }
        }

        int getTexture(byte[] Pixels, uint Width, uint Height) {
            int id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, id);

           // GL.PixelStore(PixelStoreParameter.UnpackAlignment, 1);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, (int)Width, (int)Height,
                0, PixelFormat.Bgra, PixelType.UnsignedByte, Pixels);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);
            
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            
            GL.BindTexture(TextureTarget.Texture2D, 0);
            return id;
        }

        byte[] getBGRFromImage(Drawing.Image Image) {
            byte[] pixels = new byte[Image.Height * Image.Width * 4];
            for (uint i = 0, j = 0; i < Image.Pixels.Length; i++, j += 4) {
                uint blue = j;
                uint green = j + 1;
                uint red = j + 2;
                uint alpha = j + 3;
                pixels[blue] = Image.Pixels[i].B;
                pixels[green] = Image.Pixels[i].G;
                pixels[red] = Image.Pixels[i].R;
                pixels[alpha] = Image.Pixels[i].A;
            }
            return pixels;
        }
    }
}
