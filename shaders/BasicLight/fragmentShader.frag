#version 140

out vec4 FragColor;

in vec3 pos;
in vec3 nor;
in vec2 tex;
in vec4 col;

in vec3 FragPos;

uniform sampler2D tex1;

void main()
{
    vec3 lightColor = vec3(1,1,1);
    vec3 lightPos = vec3(0.25,0.25,-0.25);

    float ambientStrength = 0.2;
    vec3 ambient = ambientStrength * lightColor;

    vec3 n = normalize(nor);
    vec3 lightDir = normalize(lightPos - FragPos);  
    float diff = max(dot(n, lightDir), 0.0);
    vec3 diffuse = diff * lightColor;

    vec3 result = (ambient + diffuse) * texture(tex1,tex).xyz;
    FragColor = vec4(result, 1.0);
}