#version 130

in vec3 position;
in vec2 texCord;

out vec2 tex;

void main()
{
    gl_Position = vec4(position.x, position.y, position.z, 1.0);
    tex = texCord;
}