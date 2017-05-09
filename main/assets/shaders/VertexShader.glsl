#version 330 core
  
in vec4 vertex;

uniform mat4 projection;
uniform mat4 model;

out vec2 TexCoord;

void main() {
    gl_Position = projection * model * vec4(vertex.xy, 0.0, 1.0);
    TexCoord = vec2(vertex.zw);
}