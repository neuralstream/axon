using System;
using System.Drawing;

namespace Axon
{
    public class Texture
    {
        public Bitmap Bitmap;

        public Texture (string FilePath)
        {
            try 
            {
                Bitmap = new Bitmap(FilePath);
            }
            catch(Exception e)
            {
                Console.WriteLine("Unable to load texture: " + e.Message);
            }
        }
    }
}