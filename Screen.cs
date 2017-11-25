using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Axon
{
    public class Screen
    {
        public int Width;
        public int Height;
        public int X;
        public int Y;
        public Shader Shader;
        public GameWindow Window;
        public Screen(int Width, int Height, int X, int Y, GameWindow Window)
        {
            this.Width = Width;
            this.Height = Height;
            this.X = X;
            this.Y = Y;
            this.Window = Window;

            this.Shader = new Shader("Screen");
        }

        public void Draw()
        {
            float[] vertices = 
            {
               -1.0f,  1.0f, 0.0f,

                1.0f,  1.0f, 0.0f,

                1.0f, -1.0f, 0.0f,

               -1.0f, 1.0f, 0.0f
            };

            int[] indices =
            {
                0,1,2,
                2,3,0
            };

            int VAO = GL.GenVertexArray();
            int VBO = GL.GenBuffer();
            int EBO = GL.GenBuffer();

            GL.BindVertexArray(VAO);
            
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(int), indices, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, sizeof(float)*3, 0);
            GL.EnableVertexAttribArray(0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);

            GL.UseProgram(this.Shader.Program);
            GL.BindVertexArray(VAO);

            GL.DrawElements(PrimitiveType.Triangles,indices.Length, DrawElementsType.UnsignedInt,0);
        }
    }
}