
using System;
using System.IO;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace LE {
    public class Game : GameWindow {
        GameContext context;
        int? backgroundTextureId;
        Texture letterTexture;
        public Game(GameContext context) {
            base.Title = "Princess colour";
            this.context = context;
        }
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, this.Width, this.Height);
            renderEmptyBackground();
            if(this.backgroundTextureId.HasValue) {
                renderBackground();
            }
            this.SwapBuffers();
        }
        protected override void OnLoad(EventArgs e) {
            
            GL.MatrixMode(MatrixMode.Projection);
            GL.Ortho(0, Width, 0, Height, 0, 1);     

            GL.Enable(EnableCap.Texture2D);
            var texture = new Texture("assets/forest.png");
            if(texture.Id != -1) {    
                this.backgroundTextureId = texture.Id;
            }
            this.letterTexture = getLetterTexture();
        }
        protected override void OnRenderFrame(FrameEventArgs e) {
            renderEmptyBackground();
            if(this.backgroundTextureId.HasValue) {
               renderBackground();
               renderLetter();
            }
            this.SwapBuffers();
        }

        void renderEmptyBackground() {
            Color color = new Color(32, 50, 108, 0);
            GL.ClearColor(color);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        void renderBackground() {
            GL.BindTexture(TextureTarget.Texture2D, this.backgroundTextureId.Value);
            GL.Begin(PrimitiveType.Quads);
                GL.TexCoord2(0, 0); GL.Vertex2(0, 600);
                GL.TexCoord2(1, 0); GL.Vertex2(800, 600);
                GL.TexCoord2(1, 1); GL.Vertex2(800, 0);
                GL.TexCoord2(0, 1); GL.Vertex2(0,0);
            GL.End();
        }

        Texture getLetterTexture() {
            var font = context.getFont();
            if (font != null) {
                var letter = context.getFont().getLetterBitmap('B', 48);
                return new Texture(letter);
            }
            return null;

        }
        void renderLetter() {
            var texture = this.letterTexture;
            if (texture == null) {
                return;
            }
            GL.BindTexture(TextureTarget.Texture2D, texture.Id);
            GL.Begin(PrimitiveType.Quads);
                GL.TexCoord2(0, 0); GL.Vertex2(0, texture.Height);
                GL.TexCoord2(1, 0); GL.Vertex2(texture.Width, texture.Height);
                GL.TexCoord2(1, 1); GL.Vertex2(texture.Width, 0);
                GL.TexCoord2(0, 1); GL.Vertex2(0,0);
            GL.End();
        }
    }
}