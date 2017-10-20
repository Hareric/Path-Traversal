using Microsoft.VisualStudio.TestTools.UnitTesting;
using PathTraversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PathTraversal.Tests
{
    [TestClass()]
    public class GraphTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "图中不包含该源点")]
        public void AddEdgeSourceNullTest()
        {
            Graph testGraph = new Graph();
            Guid AID = testGraph.AddNode("A");
            testGraph.AddEdge(Guid.NewGuid(), AID);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "图中不包含该终点")]
        public void AddEdgeTargetNullTest()
        {
            Graph testGraph = new Graph();
            Guid AID = testGraph.AddNode("A");
            testGraph.AddEdge( AID, Guid.NewGuid());
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "不能添加源点和终点相同的边")]
        public void AddEdgeSameSourceAndTargetTest()
        {
            Graph testGraph = new Graph();
            Guid AID = testGraph.AddNode("A");
            testGraph.AddEdge(AID, AID);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "不能添加重复的边")]
        public void AddEdgeRepeatTest()
        {
            Graph testGraph = new Graph();
            Guid AID = testGraph.AddNode("A");
            Guid BID = testGraph.AddNode("B");
            testGraph.AddEdge(AID, BID);
            testGraph.AddEdge(AID, BID);
        }


    }
}