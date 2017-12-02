using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Axon
{
    public class Screen
    {
        public float X1;
        public float Y1;
        public float X2;
        public float Y2;
        public Shader Shader;

        private float[] VBO;
        private int[] EBO;
        
        private int VAOid, VBOid, EBOid;
        
        public Screen(float X1, float Y1, float X2, float Y2, Texture Texture)
        {
            this.X1 = X1;
            this.Y1 = Y1;
            this.X2 = X2;
            this.Y2 = Y2;
            this.Shader = new Shader("Screen");

            buildMesh();
        }

        private void buildMesh()
        {

            this.VBO = new float[]
            {
                this.X1, this.Y1, 0.0f,
                this.X1, this.Y2, 0.0f,
                this.X2, this.Y2, 0.0f,
                this.X2, this.Y1, 0.0f
            };

            this.EBO = new int[]
            {
                0,1,2,
                2,3,0
            };

            VAOid = GL.GenVertexArray();
            VBOid = GL.GenBuffer();
            EBOid = GL.GenBuffer();

            GL.BindVertexArray(VAOid);
            
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBOid);
            GL.BufferData(BufferTarget.ArrayBuffer, VBO.Length * sizeof(float), VBO, BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBOid);
            GL.BufferData(BufferTarget.ElementArrayBuffer, EBO.Length * sizeof(int), EBO, BufferUsageHint.StaticDraw);

            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, sizeof(float)*3, 0);
            
            GL.BindVertexArray(0);
        }

        public void Update()
        {
            GL.BindVertexArray(VAOid);
            GL.UseProgram(Shader.Program);
            GL.DrawElements(PrimitiveType.Triangles,EBO.Length, DrawElementsType.UnsignedInt, 0);
        }
    }
}