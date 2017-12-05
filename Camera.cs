using System;
using OpenTK.Graphics.OpenGL;

namespace Axon
{
    public class Camera : Element
    {
        public int Texture;
        public Scene Scene;
        private int FBO;
        private int RBO;

        public Camera(Scene Scene)
        {
            this.Scene = Scene;
            this.InitBuffers();
        }

        private void InitBuffers()
        {
            FBO = GL.GenFramebuffer();
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, FBO);

            Texture = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, Texture);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, 800, 600, 0, PixelFormat.Rgb, PixelType.Byte, IntPtr.Zero);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)All.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)All.Linear);
            GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, FramebufferAttachment.ColorAttachment0, TextureTarget.Texture2D, Texture, 0);  
            GL.BindTexture(TextureTarget.Texture2D, 0);

            RBO = GL.GenRenderbuffer();
            GL.BindRenderbuffer(RenderbufferTarget.Renderbuffer, RBO);
            GL.RenderbufferStorage(RenderbufferTarget.Renderbuffer, RenderbufferStorage.Depth24Stencil8,800,600);
            GL.FramebufferRenderbuffer(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthStencilAttachment, RenderbufferTarget.Renderbuffer,RBO);
            GL.BindRenderbuffer(RenderbufferTarget.Renderbuffer, 0);

            GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
        }

        override public void Update()
        {
            // ustawinie bufora kamery - do ktorego renderujemy scene
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, this.FBO);
            // włączamy ocene głebi obiektów
            GL.Enable(EnableCap.DepthTest);
            // czyscimy bufory kamery
            GL.ClearColor(0.5f, 0.5f, 0.5f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //renderujemy scene
             foreach(Entity entity in Scene.Entities)
            {
                foreach (Element element in entity.Elements)
                {
                   if(element.GetType() != typeof(Camera))
                   {
                       element.Update();
                   }
                }
            }

           // GL.Disable(EnableCap.DepthTest);
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
        }
    }
}