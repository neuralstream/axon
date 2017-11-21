namespace Axon
{
    public class Face
    {
        public int[] indices;
        public int VertexIndex1;
        public int VertexIndex2;
        public int VertexIndex3;
        
        public Face(int VertexIndex1, int VertexIndex2, int VertexIndex3)
        {
            this.VertexIndex1 = VertexIndex1;
            this.VertexIndex2 = VertexIndex2;
            this.VertexIndex3 = VertexIndex3;
        }

    }
}