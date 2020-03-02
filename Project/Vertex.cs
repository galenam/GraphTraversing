using System.Collections.Generic;

namespace project
{
    public class Vertex
    {
        public Color Color { get; set; }
        public int Index { get; set; }
        public List<Vertex> Neighbours { get; set; }
        public Vertex(int index)
        {
            Index = index;
            Color = Color.White;
        }

        public Vertex(int index, List<Vertex> neighbours)
        {
            Index = index;
            Color = Color.White;
            Neighbours = neighbours;
        }
    }
}
