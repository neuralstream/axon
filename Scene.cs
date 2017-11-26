using System;
using System.Collections.Generic;

namespace Axon
{
    public class Scene
    {
          public List<Camera> Cameras;
          public List<Model> Entities;

        public Scene()
        {
            Cameras = new List<Camera>();
            Entities = new List<Model>();
        }

        public void Draw()
        {
            foreach(var entity in Entities)
            {
                entity.Draw();
            }
        }
    }
}