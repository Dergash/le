using System;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace LE {
    public class Graphics {

        public Graphics() {

        }

        public void ClearBackground() {
            Color color = new Color(32, 50, 108, 0);
            GL.ClearColor(color);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }


        public Shader getAreaShader() {
            String vertexSource = @"src/Render/Shaders/VertexShader.glsl";
            String fragmentSource = @"src/Render/Shaders/FragmentShader.glsl";
            Shader shader = new Shader(vertexSource, fragmentSource);
            shader.Compile();
            return shader;
        }
    }
}
