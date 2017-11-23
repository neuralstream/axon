using System;
using System.IO;

using OpenTK.Graphics.OpenGL;

namespace Axon
{
    public class Shader
    {
        public string Name;
        public int Program;

        public Shader(string Name)
        {

            this.Name = Name;

            string vertexShaderSource = File.ReadAllText(@"./shaders/" + this.Name + "/vertexShader.vert");
            string fragmentShaderSource = File.ReadAllText(@"./shaders/" + this.Name + "/fragmentShader.frag");

            int vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, vertexShaderSource);
            GL.CompileShader(vertexShader);
            Console.WriteLine(GL.GetShaderInfoLog(vertexShader));

            int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, fragmentShaderSource);
            GL.CompileShader(fragmentShader);
            Console.WriteLine(GL.GetShaderInfoLog(fragmentShader));

            Program = GL.CreateProgram();
            GL.AttachShader(Program, vertexShader);
            GL.AttachShader(Program, fragmentShader);

            GL.BindAttribLocation(Program,0,"position");
            GL.BindAttribLocation(Program,1,"normal");
            GL.BindAttribLocation(Program,2,"texCord");

            GL.LinkProgram(Program);

            GL.DetachShader(Program, vertexShader);
            GL.DetachShader(Program, fragmentShader);
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);
        }
    }
}