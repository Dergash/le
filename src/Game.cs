
using System;
using System.IO;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using Drawing = ImageProcessorCore;

namespace LE {
    public class Game : GameWindow {

        public Game() {
            base.Title = "Princess colour";
        }
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, this.Width, this.Height);
        }
        protected override void OnLoad(EventArgs e) {
           // base.OnLoad(e);


           // GL.ClearColor(10.0f, 110.0f, 0.0f, 0.0f);
            
           // int textureId = loadTexture("samples/area.bmp");
           // GL.BindTexture(TextureTarget.Texture2D, textureId);
           Color color = new Color(32,50,108,0);
         //  GL.ClearColor()
            GL.ClearColor(color);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        
            this.SwapBuffers();

        }
        protected override void OnRenderFrame(FrameEventArgs e) {
            //Matrix4 modelView = Matrix4.LookAt(Vector)
         /*   Bitmap areaBackground = new Bitmap();
            int textureId = loadTexture("samples/area.bmp");
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, -1.0, 1.0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, textureId);

            GL.Begin(PrimitiveType.Quads);

            GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(-1.0f, -1.0f);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(1.0f, -1.0f);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(1.0f, 1.0f);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(-1.0f, 1.0f);

            GL.End();*/
        }

        protected int loadTexture(String filename) {
            if (String.IsNullOrEmpty(filename)) {
                throw new ArgumentException(filename);
            }
            int id = GL.GenTexture();
            using(FileStream stream = File.OpenRead(filename)) {
                Drawing.Image image = new ImageProcessorCore.Image(stream);
               // byte[ , , ] data = new byte[image.Height, image.Width, 3];
                byte[] pixels = new byte[image.Height * image.Width * 3];

                for(int i = 0; i < image.Pixels.Length * 3; i++) {
                    pixels[i] = 33;
                }
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height,
                    0, PixelFormat.Bgra, PixelType.UnsignedByte, pixels);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
                
                //GL.BindTexture(TextureTarget.Texture2D, 0);
            }
            return id;
        }
    }
}