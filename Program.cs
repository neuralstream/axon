using System;
using OpenTK;
using OpenTK.Graphics;

namespace Axon
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWindow window = new GameWindow(600,600,new GraphicsMode(0,8,8,8),"AXON");

            Game game = new Game(window);
            InitGame(game);

            window.Run();
        }
        static void InitGame(Game Game)
        {
            Mesh mesh2 = new Mesh(@"./resources/background.obj");
            Shader shader2 = new Shader("Basic");
            Material material2 = new Material(shader2, @"./resources/background.png");
            Model background = new Model(mesh2, material2); 
            background.Move(new Vector3(0,0,0.5f));

            Mesh mesh = new Mesh(@"./resources/sword2.obj");
            Shader shader = new Shader("BasicLight");
            Material material = new Material(shader, @"./resources/sword.png");
            Model model = new Model(mesh, material); 
            model.Scale(new Vector3(0.15f,0.15f,0.15f));
            model.Move(new Vector3(0,-0.25f,0)); 

            Model model2 = new Model(mesh, material); 
            model2.Scale(new Vector3(0.10f,0.10f,0.10f));
            model2.Move(new Vector3(-0.5f,-0.5f,0)); 

            Model model3 = new Model(mesh, material); 
            model3.Scale(new Vector3(0.10f,0.10f,0.10f));
            model3.Move(new Vector3(0.5f,0.5f,0)); 
                      
            Scene scene = new Scene();

            scene.Entities.Add(model);
            scene.Entities.Add(model2);
            scene.Entities.Add(model3);
            scene.Entities.Add(background);
            Game.Scenes.Add(scene);
        }
        
    }
}
