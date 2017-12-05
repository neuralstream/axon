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
        public int Texture;
        public Shader Shader;

        private float[] vertices;
        private int[] indices;
        
        private int VAO, VBO, EBO;

        public Screen(float X1, float Y1, float X2, float Y2, int Texture)
        {
            this.X1 = X1;
            this.Y1 = Y1;
            this.X2 = X2;
            this.Y2 = Y2;
            this.Texture = Texture;
            this.Shader = new Shader("Screen");

            buildMesh();
        }

        private void buildMesh()
        {

            this.vertices = new float[]
            {
                this.X1, this.Y1, 0.0f,
                0.0f, 0.0f, 
                this.X1, this.Y2, 0.0f,
                0.0f, 1.0f, 
                this.X2, this.Y2, 0.0f,
                1.0f, 1.0f, 
                this.X2, this.Y1, 0.0f,
                1.0f, 0.0f
            };

            this.indices = new int[]
            {
                0,1,2,
                2,3,0
            };

            VAO = GL.GenVertexArray();
            VBO = GL.GenBuffer();
            EBO = GL.GenBuffer();

            GL.BindVertexArray(VAO);
            
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(int), indices, BufferUsageHint.StaticDraw);

            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, sizeof(float)*5, 0);
            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(2, 2, VertexAttribPointerType.Float, false, sizeof(float)*5, sizeof(float)*3);

            GL.BindVertexArray(0);
        }

        public void Update()
        {
            // przełączny się na buffor głowny
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
            // wyłączamy ocene głębi
            GL.Disable(EnableCap.DepthTest);

            // wybieramy shader screenu
            GL.UseProgram(Shader.Program);
            // rysujemy screen
            GL.BindVertexArray(VAO);

            // wrzucamu texturę do samplera
            int textureUniform = GL.GetUniformLocation(Shader.Program, "screenTex");
            GL.Uniform1(textureUniform,0);
            
            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, Texture);
            
            GL.DrawElements(PrimitiveType.Triangles,indices.Length, DrawElementsType.UnsignedInt, 0);
        }
    }
}