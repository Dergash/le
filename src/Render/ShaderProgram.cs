using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
namespace LE {
    public class ShaderProgram {

        public int Id { get; }

        public List<Shader> Shaders { get; }

        public ShaderProgram() {
            this.Shaders = new List<Shader>();
            this.Id = GL.CreateProgram();
        }

        public void Build() {
            foreach (var shader in Shaders) {
                GL.AttachShader(this.Id, shader.Id);
            }
            GL.LinkProgram(this.Id);
        }
    }
}