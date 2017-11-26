using System;
using System.Collections.Generic;

namespace Axon
{
    public class Scene
    {
          public List<Camera> Cameras;
          public List<Entity> Entities;

        public Scene()
        {
            Cameras = new List<Camera>();
            Entities = new List<Entity>();
        }

        public void Update()
        {
            foreach(var entity in Entities)
            {
                entity.Update();
            }
        }
    }
}