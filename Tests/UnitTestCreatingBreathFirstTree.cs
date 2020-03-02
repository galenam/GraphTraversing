using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using project;

namespace Tests
{
    public class UnitTestCreatingBreathFirstTree
    {
        static List<(List<List<int>> source, Vertex result)> data = new List<(List<List<int>> source, Vertex result)> {
            (source:new List<List<int>>
            {
                //0
                new List<int> { 1, 5,9},
                //1
                new List<int> { 0,2},
                //2
                new List<int>{1,3},
                //3
                new List<int>{4,2},
                //4
                new List<int>{3,7,9},
                //5
                new List<int>{0,6,7},
                //6
                new List<int>{5},
                //7
                new List<int>{5,8,4},
                //8
                new List<int>{7},
                //9
                new List<int>{0,4}
            },
            result: new Vertex(0){Neighbours =
                new List<Vertex>{new Vertex(1){Neighbours = new List<Vertex>{new Vertex(2){Neighbours = new List<Vertex>{new Vertex(3)}}}},
                new Vertex(5){Neighbours = new List<Vertex>{new Vertex(6), new Vertex(7){Neighbours = new List<Vertex>{new Vertex(8)}}}},
                new Vertex(9){Neighbours = new List<Vertex>{new Vertex(4)}}
                }}),
            (source:new List<List<int>>
            {
                new List<int> { 1, 4 },
                new List<int> { 0,4,2,3},
                new List<int>{1,3},
                new List<int>{1,4,2},
                new List<int>{3,0,1}
            },
            result:new Vertex(0) {Neighbours = new List<Vertex>{new Vertex(1) {Neighbours = new List<Vertex>{new Vertex(2), new Vertex(3)}},
            new Vertex(4)}}),
        };

        [Test, TestCaseSource(nameof(data))]
        public void TestCreationSearch((List<List<int>> source, Vertex result) testData)
        {
            var graph = new Graph(testData.source);
            Vertex tree = graph.CreateBreadthFirstTree();
            Assert.IsNotNull(tree);
            Assert.AreEqual(Compare(testData.result, tree), true);
        }

        private bool Compare(Vertex expected, Vertex actual)
        {
            var expectedPath = Path(expected);
            var actualPath = Path(actual);
            return String.Compare(expectedPath, actualPath, true) == 0;
        }

        private string Path(Vertex start)
        {
            var queue = new Queue<Vertex>();
            queue.Enqueue(start);
            var path = new StringBuilder();

            while (queue.Count != 0)
            {
                var vertex = queue.Dequeue();
                path.Append($"{vertex.Index} ");
                vertex.Color = Color.Black;
                Helper.CycleInNeighbour(vertex, queue, v => v.Color == Color.White, v => v.Color = Color.Grey);
            }

            return path.ToString().Trim();
        }

    }
}