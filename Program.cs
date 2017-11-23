using System;
using OpenTK;
using OpenTK.Graphics;

namespace Axon
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWindow window = new GameWindow(800,600,new GraphicsMode(0,0,0,8),"AXON");

            Game game = new Game(window);

            window.Run(1/120);
        }
    }
}
