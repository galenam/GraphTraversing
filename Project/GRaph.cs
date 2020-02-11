using System;
using System.Collections.Generic;
using System.Text;

namespace project
{
    public class Graph
    {
        Vertex StartingPoint { get; set; }
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
        }

        public bool BreadthFirstSearch(int value)
        {
            if (StartingPoint == null)
            {
                return false;
            }

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
                for (int i = 0; i < vertex.Neighbours.Count; i++)
                {
                    var vertexNeighbour = vertex.Neighbours[i];
                    if (vertexNeighbour.Color == Color.White)
                    {
                        vertexNeighbour.Color = Color.Grey;
                        queue.Enqueue(vertexNeighbour);
                    }
                }
            }
            CleanVertex();
            return false;
        }

        private void CleanVertex()
        {
            if (StartingPoint == null)
            {
                return;
            }

            StartingPoint.Color = Color.White;
            var queue = new Queue<Vertex>();
            queue.Enqueue(StartingPoint);
            while (queue.Count != 0)
            {
                var vertex = queue.Dequeue();
                for (int i = 0; i < vertex.Neighbours.Count; i++)
                {
                    var vertexNeighbour = vertex.Neighbours[i];
                    if (vertexNeighbour.Color != Color.White)
                    {
                        vertexNeighbour.Color = Color.White;
                        queue.Enqueue(vertexNeighbour);
                    }
                }
            }
        }
        // todo : commit, refactonig, 
        public string Path()
        {
            if (StartingPoint == null)
            {
                return string.Empty;
            }

            var queue = new Queue<Vertex>();
            queue.Enqueue(StartingPoint);
            var path = new StringBuilder();
            while (queue.Count != 0)
            {
                var vertex = queue.Dequeue();
                path.Append($"{vertex.Index} ");
                vertex.Color = Color.Black;
                for (int i = 0; i < vertex.Neighbours.Count; i++)
                {
                    var vertexNeighbour = vertex.Neighbours[i];
                    if (vertexNeighbour.Color == Color.White)
                    {
                        vertexNeighbour.Color = Color.Grey;
                        queue.Enqueue(vertexNeighbour);
                    }
                }
            }

            return path.ToString().Trim();
        }
    }
}
