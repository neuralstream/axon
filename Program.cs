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

            InitGame(game);

            window.Run(1/120);
        }
        static void InitGame(Game Game)
        {
            Mesh mesh = new Mesh(@"./cube.obj");
            Shader shader = new Shader("Basic");
            Material material = new Material(shader);
            Model model = new Model(mesh, material); 
            model.Scale(new Vector3(0.5f,0.5f,0.5f));
            model.Move(new Vector3(0,0,0.5f));
            
            Scene scene = new Scene();
            
            scene.Models.Add(model);
            Game.Scenes.Add(scene);
        }
        
    }
}
