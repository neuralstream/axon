using System;
using System.Collections.Generic;

namespace Axon
{
    public class Entity
    {
        public Entity Parent;
        public List<Entity> Children;
        //public string[] Tags;

        public Transformation Transformation;
        public Entity()
        {
            Parent = new Entity();
            Children = new List<Entity>();
            Transformation = new Transformation();
        }
    }
}