using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

using OpenTK;

namespace Axon
{
    public class Mesh
    {
        public List<Vertex> Vertices;
        public List<Face> Faces;
        
        private List<Vector3> Positions;
        private List<Vector3> Normals;
        private List<Vector2> TexCords;
        private List<int[]> Indices;

        public Mesh(string FilePath)
        {
            Vertices = new List<Vertex>();
            Faces = new List<Face>();

            Positions = new List<Vector3>();
            Normals = new List<Vector3>();
            TexCords = new List<Vector2>();
            Indices = new List<int[]>();

            string line = "";
            string[] words = new string[]{};

            try
            {
                using (StreamReader streamReader = new StreamReader(FilePath))
                {
                    while((line = streamReader.ReadLine()) != null)
                    {
                        if(line.StartsWith("v "))
                        {
                            words = line.Split(" ");

                            Positions.Add(
                                new Vector3
                                (
                                    float.Parse(words[1], CultureInfo.InvariantCulture),
                                    float.Parse(words[2], CultureInfo.InvariantCulture),
                                    float.Parse(words[3], CultureInfo.InvariantCulture)
                                )
                            );
                        }
                        else if(line.StartsWith("vn "))
                        {
                            words = line.Split(" ");

                            Normals.Add(
                                new Vector3
                                (
                                    float.Parse(words[1], CultureInfo.InvariantCulture),
                                    float.Parse(words[2], CultureInfo.InvariantCulture),
                                    float.Parse(words[3], CultureInfo.InvariantCulture)
                                )
                            );
                        }
                        else if(line.StartsWith("vt "))
                        {
                            words = line.Split(" ");

                            TexCords.Add(
                                new Vector2
                                (
                                    float.Parse(words[1], CultureInfo.InvariantCulture),
                                    float.Parse(words[2], CultureInfo.InvariantCulture)
                                )
                            );
                        }
                        else if(line.StartsWith("f "))
                        {
                            words = line.Split(" ");
                            
                            var ver1 = words[1].Split("/");
                            var ver2 = words[2].Split("/");
                            var ver3 = words[3].Split("/");
                            
                            Faces.Add(
                                new Face
                                (
                                    int.Parse(ver1[0]),
                                    int.Parse(ver2[0]),
                                    int.Parse(ver3[0])
                                )
                            );      

                            Indices.Add(
                                new int[]{
                                    int.Parse(ver1[0]),
                                    int.Parse(ver1[1]),
                                    int.Parse(ver1[2])
                                }
                            );
                            Indices.Add(
                                new int[]{
                                    int.Parse(ver2[0]),
                                    int.Parse(ver2[1]),
                                    int.Parse(ver2[2])
                                }
                            );
                            Indices.Add(
                                new int[]{
                                    int.Parse(ver3[0]),
                                    int.Parse(ver3[1]),
                                    int.Parse(ver3[2])
                                }
                            );        
                        }

                        while(Vertices.Count != Positions.Count)
                        {
                            Vertices.Add(
                                new Vertex
                                (
                                    new Vector3(),
                                    new Vector3(),
                                    new Vector2()
                                )
                            );
                        }

                        foreach(var index in Indices)
                        {
                            Vertices[index[0]-1].Position = Positions[index[0]-1];
                            Vertices[index[0]-1].Normal = Normals[index[1]-1];
                            Vertices[index[0]-1].TexCord = TexCords[index[2]-1];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The OBJ file could not be read:");
                Console.WriteLine(e.Message);
            }   
        }

        public float[] GetVBO()
        {
            float[] VBO = new float[Vertices.Count*(3+3+2)];

            for(int i = 0; i < Vertices.Count; i++)
            {
                VBO[i*8+0] = Vertices[i].Position.X;
                VBO[i*8+1] = Vertices[i].Position.Y;
                VBO[i*8+2] = Vertices[i].Position.Z;

                VBO[i*8+3] = Vertices[i].Normal.X;
                VBO[i*8+4] = Vertices[i].Normal.Y;
                VBO[i*8+5] = Vertices[i].Normal.Z;

                VBO[i*8+6] = Vertices[i].TexCord.X;
                VBO[i*8+7] = Vertices[i].TexCord.Y;
            }

            return VBO;
        }
         public float[] GetEBO()
        {
            float[] EBO = new float[Faces.Count*3];
            
            for(int i = 0; i < Faces.Count; i++)
            {
                EBO[i*3+0] = Faces[i].VertexIndex1;
                EBO[i*3+1] = Faces[i].VertexIndex2;
                EBO[i*3+2] = Faces[i].VertexIndex3;
            }

            return EBO;
        }
    }
}