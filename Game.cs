using System;
using System.Collections.Generic;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Axon
{
    public class Game
    {
        public GameWindow window;
       
        public List<Scene> Scenes;
        public List<Screen> Screens;

        public Game(GameWindow windowInput)
        {
            Scenes = new List<Scene>();
            Screens = new List<Screen>();

            this.window = windowInput;

            window.Load += window_Load;
            window.RenderFrame += window_RenderFrame;
            window.UpdateFrame += window_UpdateFrame;
            window.Closing += window_Closing;

        }

        void window_Load(object sender, EventArgs e)
        {
             GL.ClearColor(Color.FromArgb(1,120,192,237));
             GL.Enable(EnableCap.DepthTest);
        }
        
        void window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        
        void window_RenderFrame(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            foreach(Scene scene in Scenes)
            {
               // scene.Update();
            }
            foreach(Screen screen in Screens)
            {
                screen.Update();
            }

            window.SwapBuffers();
            window.Title = "FPS: " + ((int)(1/window.RenderTime)).ToString();
        }
        
        void window_UpdateFrame(object sender, FrameEventArgs e)
        {
        }
    }
}
