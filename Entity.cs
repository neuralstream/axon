using System;
using System.Collections.Generic;
using OpenTK;

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
            this.Parent = new Entity();
            this.Children = new List<Entity>();
            this.Elements = new List<Element>();
            this.Transformation = new Transformation();
        }

        public void Update()
        {
            this.updateChildren();
            this.updateElements();
        }
        public void Scale(Vector3 Factor)
        {
            this.Transformation.Scale = Vector3.Multiply(this.Transformation.Scale, Factor);
        }
        public void Move(Vector3 Distance)
        {
            this.Transformation.Position = Vector3.Add(this.Transformation.Position, Distance);
        }
        public void Rotate(Vector3 Angle)
        {
            this.Transformation.Rotation = Vector3.Add(this.Transformation.Rotation, Angle);
        }

        private void updateChildren()
        {
            foreach(Entity child in Children)
            {
                child.Update();
            }
        }
        private void updateElements()
        {
            foreach (Element element in Elements)
            {
                element.Update();
            }
        }
    }
}