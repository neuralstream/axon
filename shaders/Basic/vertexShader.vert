#version 130

in vec3 position;
in vec3 normal;
in vec2 texCord;

uniform mat4 transform;

out vec3 pos;
out vec3 nor;
out vec2 tex;
out vec4 col;

void main()
{
    gl_Position = transform * vec4(position.x, position.y, position.z, 1.0);
    
    pos = position;
    nor = normal;
    tex = texCord;
    col = vec4(1.0,1.0,0.0,1.0);
}