using System;
using System.IO;
using OpenTK.Graphics.OpenGL;

namespace Axon
{
    public class Model
    {
        public Mesh Mesh;
        public Texture Texture;
int VAO; int program;
        public Model(string MeshFilePath, string TextureFilePath)
        {
            Mesh = new Mesh(MeshFilePath);
            //Texture = new Texture(TextureFilePath);
        }

        public void Init()
        {
            string vertexShaderSource = File.ReadAllText(@"./shaders/vertexShader.vert");
            string fragmentShaderSource = File.ReadAllText(@"./shaders/fragmentShader.frag");


            int vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, vertexShaderSource);
            GL.CompileShader(vertexShader);
            Console.WriteLine(GL.GetShaderInfoLog(vertexShader));

            int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, fragmentShaderSource);
            GL.CompileShader(fragmentShader);
            Console.WriteLine(GL.GetShaderInfoLog(fragmentShader));

            program = GL.CreateProgram();
            GL.AttachShader(program, vertexShader);
            GL.AttachShader(program, fragmentShader);

            GL.LinkProgram(program);

            GL.DetachShader(program, vertexShader);
            GL.DetachShader(program, fragmentShader);
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);

            VAO = GL.GenVertexArray();
            int VBO = GL.GenBuffer();
            int EBO = GL.GenBuffer();

            GL.BindVertexArray(VAO);
            
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, Mesh.GetVBO().Length * sizeof(float), Mesh.GetVBO(),BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);
            GL.BufferData(BufferTarget.ElementArrayBuffer, Mesh.GetEBO().Length * sizeof(int), Mesh.GetEBO(), BufferUsageHint.StaticDraw);

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
            GL.UseProgram(program);

            GL.DrawArrays(PrimitiveType.Triangles,0,Mesh.GetEBO().Length);
        }
    }
}