#version 130

out vec4 FragColor;

in vec3 pos;
in vec3 norm;
in vec2 tex;
in vec4 col;

uniform sampler2D tex1;

void main()
{
    //FragColor = vec4(tex,0,1.0);
    FragColor = texture(tex1,tex);
}