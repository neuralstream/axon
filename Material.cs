using System;

namespace Axon
{
    public class Material
    {

        public Texture Texture;
        public Shader Shader;
        public Material(Shader Shader, String TextureFilePath)
        {
            this.Shader = Shader;
            Texture = new Texture(TextureFilePath);
        }
    }
}