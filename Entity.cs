using System;
using System.Collections.Generic;
using OpenTK;

namespace Axon
{
    public class Entity
    {
        public String Name;
        public List<String> Tags;
        public Entity Parent;
        public List<Entity> Children;
        //public string[] Tags;
        public Transformation Transformation;
        public List<Element> Elements;

        public Entity()
        {   
            this.Name = String.Empty;
            this.Tags = new List<String>();

            this.Parent = null;
            this.Children = new List<Entity>();
            
            this.Transformation = new Transformation();
            this.Elements = new List<Element>();
        }
        public Entity(String Name)
        {
            this.Name = Name;
            this.Tags = new List<String>();

            this.Parent = null;
            this.Children = new List<Entity>();
            
            this.Transformation = new Transformation();
            this.Elements = new List<Element>();
        }
        public Entity(Entity Parent)
        {
            this.Name = String.Empty;
            this.Tags = new List<String>();

            this.Parent = Parent;
            this.Children = new List<Entity>();
            
            this.Transformation = new Transformation();
            this.Elements = new List<Element>();
        }
        public Entity(String Name,Entity Parent)
        {
            this.Name = Name;
            this.Tags = new List<String>();

            this.Parent = Parent;
            this.Children = new List<Entity>();

            this.Transformation = new Transformation(); 
            this.Elements = new List<Element>();
        }

        public void Update()
        {
            //TODO: Recurential multiplication parent transformation
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