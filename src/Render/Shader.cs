using System;
using System.IO;
using OpenTK.Graphics.OpenGL;

namespace LE {
    public class Shader {

        int id;
        public int Id {
            get {
                return this.id;
            }
        }

        String vertexSource;
        int vertexShaderId;

        String fragmentSource;
        int fragmentShaderId;

        public void Compile() {
            GL.ShaderSource(vertexShaderId, vertexSource);
            GL.CompileShader(vertexShaderId);
            checkShaderErrors(vertexShaderId);

            GL.ShaderSource(fragmentShaderId, fragmentSource);
            GL.CompileShader(fragmentShaderId);
            checkShaderErrors(fragmentShaderId);

            this.id = GL.CreateProgram();
            GL.AttachShader(this.Id, vertexShaderId);
            GL.AttachShader(this.Id, fragmentShaderId);
            GL.LinkProgram(this.Id);
            checkProgramErrors();

            GL.DeleteShader(this.vertexShaderId);
            GL.DeleteShader(this.fragmentShaderId);
        }

        public Shader(String vertexSource, String framgentSource) {
            using (var stream = new FileStream(vertexSource, FileMode.Open)) 
            using (var reader = new StreamReader(stream)) {
                var source = reader.ReadToEnd();
                this.vertexShaderId = GL.CreateShader(ShaderType.VertexShader);
                this.vertexSource = source;
            }

            using (var stream = new FileStream(framgentSource, FileMode.Open)) 
            using (var reader = new StreamReader(stream)) {
                var source = reader.ReadToEnd();
                this.fragmentShaderId = GL.CreateShader(ShaderType.FragmentShader);
                this.fragmentSource = source;
            }
        }

        public void Use() {
            GL.UseProgram(this.Id);
        }

        void checkShaderErrors(int shaderId) {
            int statusCode;
            string statusText;
            GL.GetShaderInfoLog(shaderId, out statusText);
            GL.GetShader(shaderId, ShaderParameter.CompileStatus, out statusCode);
            if (statusCode != 1) {
                throw new ApplicationException(statusText);
            }
        }

        void checkProgramErrors() {
            int statusCode;
            string statusText;
            GL.GetProgram(this.Id, GetProgramParameterName.LinkStatus, out statusCode);
            if (statusCode != 1) {
                statusText = GL.GetProgramInfoLog(this.Id);
                throw new ApplicationException(statusText);
            }
        }
    }
}
