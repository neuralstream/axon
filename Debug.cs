using System;

namespace Axon
{
    public class Debug
    {
        public Debug()
        {

        }

        public static void VBO(float[] VBO)
        {
                for(var i = 0; i < VBO.Length; i++)
                {
                    if(i%8 == 0) 
                    {
                        Console.WriteLine("VERTEX ["+i/8+"]");
                        Console.WriteLine("POS: " + VBO[i].ToString() + " ; " + VBO[i+1].ToString() + " ; " + VBO[i+2].ToString());
                        Console.WriteLine("NOR: " + VBO[i+3].ToString() + " ; " + VBO[i+4].ToString() + " ; " + VBO[i+5].ToString());
                        Console.WriteLine("TEX: " + VBO[i+6].ToString() + " ; " + VBO[i+7].ToString());
                    }
                }
        }
    }
}