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
            Entity Background = new Entity();
            Mesh BackgroundMesh = new Mesh(@"./resources/background.obj");
            Shader ShaderBasic = new Shader("Basic");
            Material BackgroundMaterial = new Material(ShaderBasic, @"./resources/background.png");
            Model BackgroundModel = new Model(BackgroundMesh, BackgroundMaterial, Background.Transformation); 
            Background.Elements.Add(BackgroundModel);
            Background.Move(new Vector3(0,0,0.5f));

            Entity Sword = new Entity();
            Mesh SwordMesh = new Mesh(@"./resources/sword2.obj");
            Shader ShaderBasicLight = new Shader("BasicLight");
            Material SwordMaterial = new Material(ShaderBasicLight, @"./resources/sword.png");
            Model SwordModel = new Model(SwordMesh, SwordMaterial, Sword.Transformation); 
            Sword.Elements.Add(SwordModel);
            Sword.Scale(new Vector3(0.15f,0.15f,0.15f));
            Sword.Move(new Vector3(0,-0.25f,0)); 
                      
            Scene scene = new Scene();
            scene.Entities.Add(Sword);
            scene.Entities.Add(Background);
            Game.Scenes.Add(scene);
        }
        
    }
}
