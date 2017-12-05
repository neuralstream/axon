using System;
using System.Collections.Generic;

namespace Axon
{
    public class Scene
    {
          public List<Entity> Cameras;
          public List<Entity> Entities;
          public List<Light> Lights;

        public Scene()
        {
            Cameras = new List<Entity>();
            Entities = new List<Entity>();
            Lights = new List<Light>();
        }

        public void Update()
        {
            foreach(Entity entity in Entities)
            {
                foreach (Element element in entity.Elements)
                {
                   if(element.GetType() == typeof(Camera))
                   {
                       element.Update();
                   }
                }
            }
        }
    }
}