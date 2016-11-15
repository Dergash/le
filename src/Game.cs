
using System;

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
            GL.Viewport(0, 0, Width, Height);
            renderEmptyBackground();
            if(this.backgroundTextureId.HasValue) {
                renderBackground();
            }
            renderLetter();
            this.SwapBuffers();
        }

        int vao;
        int vbo;
        protected override void OnLoad(EventArgs e) {

            /* TEMP : Comment for testing rendering through shaders */
            GL.MatrixMode(MatrixMode.Projection);
            GL.Ortho(0, Width, 0, Height, 0, 1);
            /* END TEMP */
            tempInitProgram();
            tempBuildShadersTriangle();

            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            var texture = new Texture("assets/forest.png");
            if(texture.Id != -1) {    
                this.backgroundTextureId = texture.Id;
            }
            this.letterTexture = getLetterTexture();
        }
        protected override void OnRenderFrame(FrameEventArgs e) {
            renderEmptyBackground();
            renderShadersTriangle();
            if (this.backgroundTextureId.HasValue) {
                renderBackground();
            }
            renderLetter();
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
                context.getFont().Color = Color.HotPink;
                var letter = context.getFont().Atlas['B'];
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
                GL.TexCoord2(0, 0); GL.Vertex2(0, 480);
                GL.TexCoord2(1, 0); GL.Vertex2(texture.Width, 480);
                GL.TexCoord2(1, 1); GL.Vertex2(texture.Width, 480 - (int)texture.Height);
                GL.TexCoord2(0, 1); GL.Vertex2(0, 480 - (int)texture.Height);
            GL.End();
        }

        // All stuff below is just for testing OpenGL 3.3
        void renderShadersTriangle() {
            GL.UseProgram(program);
            GL.BindVertexArray(vao);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            GL.BindVertexArray(0);
        }
        int program;
        void tempBuildShadersTriangle() {
            this.vao = GL.GenVertexArray();
            this.vbo = GL.GenBuffer();

            float[] backgroundBufferData = {
                -0.5f, -0.5f, 0.0f,
                0.5f, -0.5f, 0.0f,
                0.0f, 0.5f, 0.0f
            };

            GL.BindVertexArray(vao);
                GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
                GL.BufferData(BufferTarget.ArrayBuffer,
                    (IntPtr) (backgroundBufferData.Length * sizeof(float)),
                    backgroundBufferData,
                    BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            GL.BindVertexArray(0);
        }
        void tempInitProgram() {
            var vertexShader = new Shader(@"src/Render/Shaders/VertexShader.glsl");
            var fragmentShader = new Shader(@"src/Render/Shaders/FragmentShader.glsl");
            var shaderProgram = new ShaderProgram();
            shaderProgram.Shaders.Add(vertexShader);
            shaderProgram.Shaders.Add(fragmentShader);
            shaderProgram.Build();
            this.program = shaderProgram.Id;
        }
    }
}