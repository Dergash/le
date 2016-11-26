using System;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace LE {
    public class Graphics {

        ShaderProgram areaShader;
        TextRenderer textRenderer;

        public Graphics() {
            this.areaShader = getAreaShader();
            var font = GameContext.getInstance().getFont();
            this.textRenderer = new TextRenderer(font);
        }

        public void ClearBackground() {
            Color color = new Color(32, 50, 108, 0);
            GL.ClearColor(color);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        public void DrawSprite(Texture texture, int x, int y, uint width, uint height) {
            int vertexArrayId = GL.GenVertexArray();
            setupRectangleVAO(vertexArrayId);
            GL.UseProgram(areaShader.Id);
            GL.BindTexture(TextureTarget.Texture2D, texture.Id);
            GL.BindVertexArray(vertexArrayId);
                GL.DrawElements(BeginMode.Triangles, 6, DrawElementsType.UnsignedInt, 0);
            GL.BindVertexArray(0);
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }

        public void DrawTextLine(string text, int x, int y) {
            if (text.Length > 1) {
                throw new NotImplementedException();
            }
            var textTexture = this.textRenderer.getTextTexture("B");
            DrawSprite(textTexture, 0, 0, textTexture.Width, textTexture.Height);
        }

        ShaderProgram getAreaShader() {
            var vertexShader = new Shader(@"src/Render/Shaders/VertexShader.glsl", ShaderType.VertexShader);
            var fragmentShader = new Shader(@"src/Render/Shaders/FragmentShader.glsl", ShaderType.FragmentShader);
            var shaderProgram = new ShaderProgram();
            shaderProgram.Shaders.Add(vertexShader);
            shaderProgram.Shaders.Add(fragmentShader);
            shaderProgram.Build();
            return shaderProgram;
        }

        void setupRectangleVAO(int vertexArrayObjectId) {
            int vbo = GL.GenBuffer();
            int ebo = GL.GenBuffer();
            float[] backgroundBufferData = { // XYZ ST
                1.0f, 1.0f, 0.0f,       1.0f, 1.0f,
                1.0f, -1.0f, 0.0f,      1.0f, 0.0f,
                -1.0f, -1.0f, 0.0f,     0.0f, 0.0f,
                -1.0f, 1.0f, 0.0f,      0.0f, 1.0f
            };
            int[] rectangleIndexes = {
                0, 1, 3,
                1, 2, 3
            };
            GL.BindVertexArray(vertexArrayObjectId);
                GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
                GL.BufferData(BufferTarget.ArrayBuffer,
                    (IntPtr)(backgroundBufferData.Length * sizeof(float)),
                    backgroundBufferData,
                    BufferUsageHint.StaticDraw);
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
                GL.BufferData(BufferTarget.ElementArrayBuffer,
                    (IntPtr)(rectangleIndexes.Length * sizeof(int)),
                    rectangleIndexes,
                    BufferUsageHint.StaticDraw);
                // Position
                GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false,
                    5 * sizeof(float), 0);
                GL.EnableVertexAttribArray(0);
                // Texture
                GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false,
                    5 * sizeof(float), 3 * sizeof(float));
                GL.EnableVertexAttribArray(1);
            GL.BindVertexArray(0);
        }
    }
}
