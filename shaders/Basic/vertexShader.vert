#version 130

in vec3 position;
in vec3 normal;
in vec3 texCord;

uniform mat4 transform;
out vec4 nColor;

void main()
{
    gl_Position = transform * vec4(position.x, position.y, position.z, 1.0);
    nColor = vec4(normal,1.0);
}