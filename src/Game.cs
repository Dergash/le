
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
                renderAreaBackground(this.backgroundTextureId.Value);
            }
            renderLetter();
            this.SwapBuffers();
        }

        int vao;
        int vbo;
        int ebo;
        protected override void OnLoad(EventArgs e) {

            tempInitProgram();
            bindAreaBackground();

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
            if (this.backgroundTextureId.HasValue) {
                renderAreaBackground(this.backgroundTextureId.Value);
            }
            //renderLetter();
            this.SwapBuffers();
        }

        void renderEmptyBackground() {
            Color color = new Color(32, 50, 108, 0);
            GL.ClearColor(color);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
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
        int program;
        void tempInitProgram() {
            var vertexShader = new Shader(@"src/Render/Shaders/VertexShader.glsl", ShaderType.VertexShader);
            var fragmentShader = new Shader(@"src/Render/Shaders/FragmentShader.glsl", ShaderType.FragmentShader);
            var shaderProgram = new ShaderProgram();
            shaderProgram.Shaders.Add(vertexShader);
            shaderProgram.Shaders.Add(fragmentShader);
            shaderProgram.Build();
            this.program = shaderProgram.Id;
        }
        void bindAreaBackground() {
            this.vao = GL.GenVertexArray();
            this.vbo = GL.GenBuffer();
            this.ebo = GL.GenBuffer();
            // XYZ ST
            float[] backgroundBufferData = {
                1.0f, 1.0f, 0.0f,       1.0f, 1.0f,
                1.0f, -1.0f, 0.0f,      1.0f, 0.0f,
                -1.0f, -1.0f, 0.0f,     0.0f, 0.0f,
                -1.0f, 1.0f, 0.0f,      0.0f, 1.0f
            };
            int[] rectangleIndexes = {
                0, 1, 3,
                1, 2, 3
            };
            GL.BindVertexArray(vao);
                GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
                GL.BufferData(BufferTarget.ArrayBuffer,
                    (IntPtr) (backgroundBufferData.Length * sizeof(float)),
                    backgroundBufferData,
                    BufferUsageHint.StaticDraw);

                GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
                GL.BufferData(BufferTarget.ElementArrayBuffer,
                    (IntPtr) (rectangleIndexes.Length * sizeof(int)),
                    rectangleIndexes,
                    BufferUsageHint.StaticDraw);
                // Position
                GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);
                GL.EnableVertexAttribArray(0);
                // Texture
                GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float),
                    3 * sizeof(float));
                GL.EnableVertexAttribArray(1);
            GL.BindVertexArray(0);
        }
        void renderAreaBackground(int textureId) {
            GL.UseProgram(program);
            GL.BindTexture(TextureTarget.Texture2D, textureId);
            GL.BindVertexArray(vao);
                GL.DrawElements(BeginMode.Triangles, 6, DrawElementsType.UnsignedInt, 0);
            GL.BindVertexArray(0);
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }
    }
}