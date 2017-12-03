#version 130

in vec2 tex;
uniform sampler2D screenTex;

out vec4 FragColor;

void main()
{
    FragColor = texture(screenTex,tex);
}