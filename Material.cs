using System;

namespace Axon
{
    public class Material
    {

        //public Texture Texture;
        public Shader Shader;
        public Material(Shader Shader)
        {
            this.Shader = Shader;
            // this.Texture = Texture;
            //Texture = new Texture(TextureFilePath);
        }
    }
}