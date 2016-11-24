#version 330 core
  
layout (location = 0) in vec3 position;
layout (location = 1) in vec2 inTextureCoordinates;

out vec2 TexCoord;

void main() {
    gl_Position = vec4(position, 1.0);
    TexCoord = vec2(inTextureCoordinates.x, 1.0f - inTextureCoordinates.y);
}