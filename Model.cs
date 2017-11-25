using System;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Axon
{
    public class Model
    {
        public Mesh Mesh;
        public Material Material;
        public Transformation Transformation;

        int VAO;
        public Model(Mesh Mesh, Material Material)
        {
            this.Mesh = Mesh;
            this.Material = Material;
            this.Transformation = new Transformation();
            
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
            int transform = GL.GetUniformLocation(Material.Shader.Program, "transform");
            GL.UniformMatrix4(transform, false, ref Transformation.Matrix);
            GL.DrawArrays(PrimitiveType.Triangles,0,Mesh.EBO.Length);
        }

        public void Scale(Vector3 Factor)
        {
            this.Transformation.Scale = Vector3.Multiply(this.Transformation.Scale, Factor);
        }
        public void Move(Vector3 Distance)
        {
            this.Transformation.Position = Vector3.Add(this.Transformation.Position, Distance);
        }
        public void Rotate(Vector3 Angle)
        {
            this.Transformation.Rotation = Vector3.Add(this.Transformation.Rotation, Angle);
        }
    }
}