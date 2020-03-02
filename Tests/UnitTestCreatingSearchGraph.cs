using System.Collections.Generic;
using NUnit.Framework;
using project;

namespace Tests
{
    public class UnitTestCreatingSearchGraph
    {
        static List<(List<List<int>> source, int value, bool result)> data = new List<(List<List<int>> source, int value, bool result)> {
            (source:new List<List<int>> { new List<int> { 1, 4 }, new List<int> { 0,4,2,3}, new List<int>{1,3},
            new List<int>{1,4,2},new List<int>{3,0,1} }, value:0, result:true),
            (source:new List<List<int>> { new List<int> { 1, 4 }, new List<int> { 0,4,2,3}, new List<int>{1,3},
            new List<int>{1,4,2},new List<int>{3,0,1} }, value:1, result:true),
            (source:new List<List<int>> { new List<int> { 1, 4 }, new List<int> { 0,4,2,3}, new List<int>{1,3},
            new List<int>{1,4,2},new List<int>{3,0,1} }, value:2, result:true),
            (source:new List<List<int>> { new List<int> { 1, 4 }, new List<int> { 0,4,2,3}, new List<int>{1,3},
            new List<int>{1,4,2},new List<int>{3,0,1} }, value:3, result:true),
            (source:new List<List<int>> { new List<int> { 1, 4 }, new List<int> { 0,4,2,3}, new List<int>{1,3},
            new List<int>{1,4,2},new List<int>{3,0,1} }, value:4, result:true),
            (source:new List<List<int>> { new List<int> { 1, 4 }, new List<int> { 0,4,2,3}, new List<int>{1,3},
            new List<int>{1,4,2},new List<int>{3,0,1} }, value:5, result:false),
            (source:new List<List<int>> { new List<int> { 1, 4 }, new List<int> { 0,4,2,3}, new List<int>{1,3},
            new List<int>{1,4,2},new List<int>{3,0,1} }, value:-1, result:false),
            (source:new List<List<int>> { new List<int> { 1, 4 }, new List<int> { 0,4,2,3}, new List<int>{1,3},
            new List<int>{1,4,2},new List<int>{3,0,1} }, value:int.MaxValue, result:false),
            (source:new List<List<int>> { new List<int> { 1, 4 }, new List<int> { 0,4,2,3}, new List<int>{1,3},
            new List<int>{1,4,2},new List<int>{3,0,1} }, value:int.MinValue, result:false),
        };

        [Test, TestCaseSource(nameof(data))]
        public void TestCreationSearch((List<List<int>> source, int value, bool result) testData)
        {
            var graph = new Graph(testData.source);
            var searched = graph.BreadthFirstSearch(testData.value);
            Assert.AreEqual(testData.result, searched);
        }

        [Test, TestCaseSource(nameof(data))]
        public void TestSearchCleanSearch((List<List<int>> source, int value, bool result) testData)
        {
            var graph = new Graph(testData.source);
            var searched = graph.BreadthFirstSearch(testData.value);
            Assert.AreEqual(testData.result, searched);
            // private Clean inside BreadthFirstSearch. Double search should work correct
            searched = graph.BreadthFirstSearch(testData.value);
            Assert.AreEqual(testData.result, searched);
        }
    }
}