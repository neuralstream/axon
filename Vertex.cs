using System;
using OpenTK;

namespace Axon
{
    public class Vertex
    {
        public Vector3 Position;
        public Vector3 Normal;
        public Vector2 TexCord;

        public Vertex(Vector3 Position, Vector3 Normal, Vector2 TexCord)
        {
            if((Position == null ) || (Normal == null) || (TexCord == null))
            {
                throw new Exception("Unable to create vertex");
            }
            else
            {
                this.Position = Position;
                this.Normal = Normal;
                this.TexCord = TexCord;
            }
        }
        public int GetSize()
        {
            return sizeof(float)*8;
        }
    }
}