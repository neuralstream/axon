using System;
using OpenTK;
using OpenTK.Graphics;

namespace Axon
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWindow window = new GameWindow(800,600,new GraphicsMode(0,24,8,8),"AXON");

            Game game = new Game(window);
            InitGame(game);

            window.Run();
        }
        static void InitGame(Game Game)
        {
            // Create scene
            Scene Scene1 = new Scene();
            Game.Scenes.Add(Scene1);

            // Create entities
            Scene1.Entities.Add(createBackground());
            Scene1.Entities.Add(createSword());
            Entity Camera = createCamera(Scene1);
            Scene1.Cameras.Add(Camera);

            // Create screens
            Screen Screen1 = new Screen(-1,-1, 1, 0, ((Camera)Camera.Elements[0]).Texture);
            Screen Screen2 = new Screen(-1, 0, 1, 1, ((Camera)Camera.Elements[0]).Texture);
            Game.Screens.Add(Screen1);
            Game.Screens.Add(Screen2);
        }

        static Entity createBackground()
        {
            Entity Background = new Entity();
            Mesh BackgroundMesh = new Mesh(@"./resources/background.obj");
            Shader ShaderBasic = new Shader("Basic");
            Material BackgroundMaterial = new Material(ShaderBasic, @"./resources/background.png");
            Model BackgroundModel = new Model(BackgroundMesh, BackgroundMaterial, Background.Transformation); 
            Background.Elements.Add(BackgroundModel);
            Background.Move(new Vector3(0,0,0.5f));

            return Background;
        }

        static Entity createSword()
        {
            Entity Sword = new Entity();
            Mesh SwordMesh = new Mesh(@"./resources/sword2.obj");
            Shader ShaderBasicLight = new Shader("BasicLight");
            Material SwordMaterial = new Material(ShaderBasicLight, @"./resources/sword.png");
            Model SwordModel = new Model(SwordMesh, SwordMaterial, Sword.Transformation); 
            Sword.Elements.Add(SwordModel);
            Sword.Scale(new Vector3(0.15f,0.15f,0.15f));
            Sword.Move(new Vector3(0,-0.25f,0)); 

            return Sword;
        }

        static Entity createCamera(Scene Scene)
        {
            Entity Camera = new Entity();
            Camera Camera1 = new Camera(Scene);
            Camera.Elements.Add(Camera1);

            return Camera;
        }
        
    }
}
