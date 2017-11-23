using System;
using System.IO;
using OpenTK.Graphics.OpenGL;

namespace Axon
{
    public class Model
    {
        public Mesh Mesh;
        public Material Material;

        int VAO;
        public Model(Mesh Mesh, Material Material)
        {
            this.Mesh = Mesh;
            this.Material = Material;

            this.Init();
        }

        private void Init()
        {
            VAO = GL.GenVertexArray();
            int VBO = GL.GenBuffer();
            int EBO = GL.GenBuffer();

            GL.BindVertexArray(VAO);
            
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, Mesh.VBO.Length * sizeof(float), Mesh.VBO,BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);
            GL.BufferData(BufferTarget.ElementArrayBuffer, Mesh.EBO.Length * sizeof(int), Mesh.EBO, BufferUsageHint.StaticDraw);

            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, sizeof(float)*8, 0);
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, sizeof(float)*8, sizeof(float)*3);
            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(2, 2, VertexAttribPointerType.Float, false, sizeof(float)*8, sizeof(float)*6);
            GL.BindVertexArray(0);

        }
        public void Draw()
        {
            GL.BindVertexArray(VAO);
            GL.UseProgram(Material.Shader.Program);

            GL.DrawArrays(PrimitiveType.Triangles,0,Mesh.EBO.Length);
        }
    }
}