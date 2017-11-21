using System;
using System.Collections.Generic;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Axon
{
    public class Game
    {
        public GameWindow window;
        int i = 0;

        public List<Model> Models;

        public Game(GameWindow windowInput)
        {
            Models = new List<Model>();
            
            Model model = new Model(@"./test.obj", @"./a.png"); 
            Models.Add(model);

            
            this.window = windowInput;

            window.Load += window_Load;
            window.RenderFrame += window_RenderFrame;
            window.UpdateFrame += window_UpdateFrame;
            window.Closing += window_Closing;

        }

        void window_Load(object sender, EventArgs e)
        {
             GL.ClearColor(Color.FromArgb(1,5,5,25));

            foreach(var model in Models)
            {
                model.Init();
            }
        }
        
        void window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        
        void window_RenderFrame(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            foreach(var model in Models)
            {
                model.Draw();
            }

            window.SwapBuffers();
        }
        
        void window_UpdateFrame(object sender, FrameEventArgs e)
        {
            i++;
            GL.ClearColor(Color.FromArgb(1,i%255,5,25));
        }
    }
}
