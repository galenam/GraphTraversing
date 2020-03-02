using System;
using System.Collections.Generic;
using System.Text;

namespace project
{
    public class Helper
    {
        public static void CycleInNeighbour(Vertex vertex, Queue<Vertex> queue, Predicate<Vertex> predicate, Action<Vertex> action)
        {
            if (vertex == null || vertex.Neighbours == null)
            {
                return;
            }
            for (int i = 0; i < vertex.Neighbours.Count; i++)
            {
                var vertexNeighbour = vertex.Neighbours[i];
                if (predicate(vertexNeighbour))
                {
                    action(vertexNeighbour);
                    queue.Enqueue(vertexNeighbour);
                }
            }

        }

    }
}