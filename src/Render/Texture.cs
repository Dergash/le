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
        public Texture(String Filename) {
            if (String.IsNullOrEmpty(Filename)) {
                throw new ArgumentException(Filename);
            }

            Drawing.Image image;
            if(!File.Exists(Filename)) {
                this.Id = -1;
                return;
            };
            
            using(FileStream stream = File.OpenRead(Filename)) {
                image = new ImageProcessorCore.Image(stream);
            }

            this.Width = (uint)image.Width;
            this.Height = (uint)image.Height;

            byte[] pixels = getBGRFromImage(image);

            this.Id = getSquareTexture(pixels, Width, Height);
        }        

        int getSquareTexture(byte[] Pixels, uint Width, uint Height) {
            int id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, id);
    
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, (int)Width, (int)Height,
                0, PixelFormat.Bgr, PixelType.UnsignedByte, Pixels);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);
            
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            
            GL.BindTexture(TextureTarget.Texture2D, 0);
            return id;
        }

        byte[] getBGRFromImage(Drawing.Image Image) {
            byte[] pixels = new byte[Image.Height * Image.Width * 3];
            for(uint i = 0, j = 0; i < Image.Pixels.Length; i++, j += 3) {
                uint blue = j;
                uint green = j + 1;
                uint red = j + 2;
                pixels[blue] = Image.Pixels[i].B;
                pixels[green] = Image.Pixels[i].G;
                pixels[red] = Image.Pixels[i].R;
            }
            return pixels;
        }
    }
}