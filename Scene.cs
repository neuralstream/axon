using System;
using System.Collections.Generic;

namespace Axon
{
    public class Scene
    {
          public List<Camera> Cameras;
          public List<Model> Models;

        public Scene()
        {
            Cameras = new List<Camera>();
            Models = new List<Model>();
        }

        public void Draw()
        {
            foreach(var model in Models)
            {
                model.Draw();
            }
        }
    }
}