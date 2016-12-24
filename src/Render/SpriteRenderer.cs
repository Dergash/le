using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace LE {
    public class SpriteRenderer {

        public Shader shader;
        int vertexArrayObjectId;

        public SpriteRenderer(Shader shader) {
            this.shader = shader;
            this.init();
        }

        public void DrawSprite(Texture texture, float x, float y, float width, float height, float rotate) {
            this.shader.Use();
            Matrix4 model = Matrix4.Identity;

            Matrix4 transaction = Matrix4.CreateTranslation(x, y, 0);
            model = transaction * model;

            Matrix4 scale = Matrix4.CreateScale(width, height, 1.0f);
            model = scale * model;
            
            this.shader.SetMatrix("model", model);
            GL.BindTexture(TextureTarget.Texture2D, texture.Id);
            GL.BindVertexArray(vertexArrayObjectId);
                GL.DrawArrays(PrimitiveType.Triangles, 0, 6);
            GL.BindVertexArray(0);
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }

        void init() {
            int vbo = GL.GenBuffer();
            int ebo = GL.GenBuffer();
            float[] backgroundBufferData = {
                // Pos      // Tex
                0.0f, 1.0f, 0.0f, 1.0f,
                1.0f, 0.0f, 1.0f, 0.0f,
                0.0f, 0.0f, 0.0f, 0.0f, 
            
                0.0f, 1.0f, 0.0f, 1.0f,
                1.0f, 1.0f, 1.0f, 1.0f,
                1.0f, 0.0f, 1.0f, 0.0f
            };
            int[] rectangleIndexes = {
                0, 1, 3,
                1, 2, 3
            };
            vertexArrayObjectId = GL.GenVertexArray();
            GL.BindVertexArray(vertexArrayObjectId);
                GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
                GL.BufferData(BufferTarget.ArrayBuffer,
                    (IntPtr)(backgroundBufferData.Length * sizeof(float)),
                    backgroundBufferData,
                    BufferUsageHint.StaticDraw);
                // Position
                GL.VertexAttribPointer(0, 4, VertexAttribPointerType.Float, false,
                    4 * sizeof(float), 0);
                GL.EnableVertexAttribArray(0);
                GL.BindVertexArray(0);
        }

        public void SetProjection(float width, float height) {
            Matrix4 projection = Matrix4.CreateOrthographicOffCenter(0, width, height, 0, -1.0f, 1.0f);
            this.shader.SetMatrix("projection", projection);
        }
    }
}