using System;
using System.IO;

using OpenTK;
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
            this.vertexShaderId = -1;
            this.fragmentShaderId = -1;
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

        public void SetMatrix(String name, Matrix4 matrix) {
            GL.UseProgram(this.Id);
            float[] matrixAsArray = { // I think conversion method is hiding somewhere...
                matrix.M11, matrix.M12, matrix.M13, matrix.M14,
                matrix.M21, matrix.M22, matrix.M23, matrix.M24,
                matrix.M31, matrix.M32, matrix.M33, matrix.M34,
                matrix.M41, matrix.M42, matrix.M43, matrix.M44,
            };
            GL.UniformMatrix4(GL.GetUniformLocation(this.Id, name), 1, false, matrixAsArray);
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
