using System.Collections.Generic;
using NUnit.Framework;
using project;

namespace Tests
{
    public class UnitTestPathInGraphToString
    {
        static List<(List<List<int>> source, string path)> data = new List<(List<List<int>> source, string path)> {
            (source:new List<List<int>> { new List<int> { 1, 4 }, new List<int> { 0,4,2,3}, new List<int>{1,3},
            new List<int>{1,4,2},new List<int>{3,0,2} }, path : "0 1 4 2 3")
        };

        [Test, TestCaseSource(nameof(data))]
        public void TestPath((List<List<int>> source, string path) testData)
        {
            var graph = new Graph(testData.source);
            var path = graph.Path();
            Assert.AreEqual(testData.path, path);
        }

    }
}