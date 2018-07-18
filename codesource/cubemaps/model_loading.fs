#version 330 core
out vec4 FragColor;


in vec3 Position;
in vec3 Normal;
in vec2 TexCoords;
uniform vec3 cameraPos;
uniform sampler2D texture_diffuse1;
uniform samplerCube skybox;

void main()
{   
    vec3 norm = normalize(Normal);
    vec3 I = normalize(Position - cameraPos);
    vec3 lightDir = reflect(I, norm);
    vec3 lightColor = texture(skybox, lightDir).rgb;
    vec3 objectColor = texture(texture_diffuse1, TexCoords).rgb;

    float ambientStrength = 0.1;
    vec3 ambient = ambientStrength * lightColor;
        
    
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = diff * lightColor;
    
    float specularStrength = 0.5;
    vec3 viewDir = normalize(cameraPos - Position);
    vec3 reflectDir = reflect(-lightDir, norm);  
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32);
    vec3 specular = specularStrength * spec * lightColor;  
    vec3 result = (ambient + diffuse + specular) * objectColor;
    FragColor = vec4(result, 1.0);
    //FragColor = texture(texture_diffuse1, TexCoords);
 
}
