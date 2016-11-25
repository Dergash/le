using System;
using System.IO;
using OpenTK.Graphics.OpenGL;

namespace LE {
    
    public class Shader : IDisposable {

        private int id;
        public int Id {
            get {
                return this.id;
            }
        }

        public Shader(String srcFilePath, ShaderType ShaderType) {
            int shaderId;
            using (var stream = new FileStream(srcFilePath, FileMode.Open)) 
            using (var reader = new StreamReader(stream)) {
                var source = reader.ReadToEnd();
                shaderId = GL.CreateShader(ShaderType);
                GL.ShaderSource(shaderId, source);
                GL.CompileShader(shaderId);

                int statusCode;
                string statusText;
                GL.GetShaderInfoLog(shaderId, out statusText);
                GL.GetShader(shaderId, ShaderParameter.CompileStatus, out statusCode);
                if (statusCode != 1) {
                    throw new ApplicationException(statusText);
                }
            }
            this.id = shaderId;
        }

        public void Dispose() {
            if (this.Id >= 0) {
                GL.DeleteShader(this.Id);
            }
            this.id = -1;
        }
    }
}