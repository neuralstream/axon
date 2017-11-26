using System;
using System.Collections.Generic;

namespace Axon
{
    public class Entity
    {
        public Entity Parent;
        public List<Entity> Children;
        //public string[] Tags;
        public List<Element> Elements;
        public Transformation Transformation;
        public Entity()
        {
            Parent = new Entity();
            Children = new List<Entity>();
            Elements = new List<Element>();
            Transformation = new Transformation();
        }
    }
}