using System;
using OpenTK;

namespace Axon
{
    public class Transformation 
    {   public Vector3 Scale
        {
            get
            {
                return this.scale;
            }
            set
            {
                this.scale = value;
                this.update();
            }
        }

        public Vector3 Position
        {
            get
            {
                return this.scale;
            }
            set
            {
                this.scale = value;
                this.update();
            }

        }
        public Vector3 Rotation
        {
            get
            {
                return this.scale;
            }
            set
            {
                this.scale = value;
                this.update();
            }    
        }
        
        private Vector3 scale;
        private Vector3 translation;
        private Vector3 rotation;

        private Matrix4 scaleMatrix;
        private Matrix4 translationMatrix;
        private Matrix4 rotationXMatrix;
        private Matrix4 rotationYMatrix;
        private Matrix4 rotationZMatrix;

        public Matrix4 Matrix;

        public Transformation()
        {
            this.translation = new Vector3(0,0,0);
            this.scale = new Vector3(1,1,1);
            this.rotation = new Vector3(0,1,0);

            this.update();
        }

        public Transformation(Vector3 Scale, Vector3 Position, Vector3 Rotation)
        {
            this.scale = Scale;
            this.translation = Position;
            this.rotation = Rotation;

            this.update();
        }
        private void update()
        {
            this.scaleMatrix = Matrix4.CreateScale(this.scale);
            this.translationMatrix = Matrix4.CreateTranslation(this.translation);
            this.rotationXMatrix = Matrix4.CreateRotationX(this.rotation.X);
            this.rotationYMatrix = Matrix4.CreateRotationY(this.rotation.Y);
            this.rotationZMatrix = Matrix4.CreateRotationZ(this.rotation.Z);

            Matrix = Matrix4.Identity;

            Matrix = Matrix4.Mult(scaleMatrix, Matrix);
            Matrix = Matrix4.Mult(rotationXMatrix, Matrix);
            Matrix = Matrix4.Mult(rotationYMatrix, Matrix);
            Matrix = Matrix4.Mult(rotationZMatrix, Matrix);
            Matrix = Matrix4.Mult(translationMatrix, Matrix);
        }
    }
}