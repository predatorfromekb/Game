using System.Linq;
using Game.Model;
using NUnit.Framework;

namespace Model.Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var graph = Graph.MakeGraph(
                0, 1,
                2, 3,
                4, 5
            );
            
            Assert.AreEqual(graph.Length, 6);
            Assert.AreEqual(graph.Edges.Count(), 3);

            graph.AddNode();
            Assert.AreEqual(graph.Length, 7);
        }
    }
}