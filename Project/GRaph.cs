using System;
using System.Collections.Generic;
using System.Text;

namespace project
{
    public class Graph
    {
        Vertex StartingPoint { get; set; } = new Vertex(0);
        int Count { get; set; }
        public Graph(List<List<int>> adjacencyList)
        {
            var arrayVertexes = new Vertex[adjacencyList.Count];
            for (int i = 0; i < adjacencyList.Count; i++)
            {
                Vertex v = arrayVertexes[i] == null ? new Vertex(i) : arrayVertexes[i];

                if (arrayVertexes[i] == null)
                {
                    arrayVertexes[i] = v;
                }
                if (v.Neighbours == null)
                {
                    v.Neighbours = new List<Vertex>();
                }
                for (int j = 0; j < adjacencyList[i].Count; j++)
                {
                    var innerVertex = arrayVertexes[adjacencyList[i][j]] == null ? new Vertex(adjacencyList[i][j]) : arrayVertexes[adjacencyList[i][j]];
                    if (arrayVertexes[adjacencyList[i][j]] == null)
                    {
                        arrayVertexes[adjacencyList[i][j]] = innerVertex;
                    }
                    v.Neighbours.Add(innerVertex);
                }
                if (i == 0)
                {
                    StartingPoint = v;
                }
            }
            Count = adjacencyList.Count;
        }
        public Vertex CreateBreadthFirstTree()
        {
            var arrayVertexes = new Vertex[Count];
            Vertex result = null;

            var queue = new Queue<Vertex>();
            queue.Enqueue(StartingPoint);
            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                vertex.Color = Color.Black;
                Vertex vertexParent = GetOrCreateVertex(arrayVertexes, vertex.Index);
                if (vertex.Neighbours != null)
                {
                    vertexParent.Neighbours = new List<Vertex>();
                    Helper.CycleInNeighbour(vertex, queue, n => n.Color == Color.White,
                        neighbour => AddNeighbour(arrayVertexes, neighbour, vertexParent));
                }
                if (result == null)
                {
                    result = vertexParent;
                }
            }
            CleanVertex();
            return result;
        }

        private void AddNeighbour(Vertex[] arrayVertexes, Vertex neighbour, Vertex vertexParent)
        {
            Vertex vertexInner = GetOrCreateVertex(arrayVertexes, neighbour.Index);
            vertexParent.Neighbours.Add(vertexInner);
            neighbour.Color = Color.Grey;
        }

        private static Vertex GetOrCreateVertex(Vertex[] arrayVertexes, int index)
        {
            Vertex vertexResult = null;
            if (arrayVertexes[index] == null)
            {
                vertexResult = new Vertex(index);
                arrayVertexes[index] = vertexResult;
            }
            else
            {
                vertexResult = arrayVertexes[index];
            }

            return vertexResult;
        }

        public bool BreadthFirstSearch(int value)
        {
            var queue = new Queue<Vertex>();
            queue.Enqueue(StartingPoint);
            while (queue.Count != 0)
            {
                var vertex = queue.Dequeue();
                if (vertex.Index == value)
                {
                    CleanVertex();
                    return true;
                }
                vertex.Color = Color.Black;
                Helper.CycleInNeighbour(vertex, queue, v => v.Color == Color.White, v => v.Color = Color.Grey);
            }
            CleanVertex();
            return false;
        }

        private void CleanVertex()
        {
            var queue = new Queue<Vertex>();
            queue.Enqueue(StartingPoint);

            while (queue.Count != 0)
            {
                var vertex = queue.Dequeue();
                Helper.CycleInNeighbour(vertex, queue, v => v.Color != Color.White, v => v.Color = Color.White);
            }
        }


    }
}