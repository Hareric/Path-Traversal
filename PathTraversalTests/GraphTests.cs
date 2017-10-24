using PathTraversal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;



namespace PathTraversal.Tests
{
    [TestClass()]
    public class GraphTests
    {
        [TestMethod()]
        public void AddNodeTest()
        {
            Guid testID = Guid.NewGuid();
            Node testNode = new Node("test", testID);
            Graph testGraph = new Graph();
            testGraph.AddNode(testNode);
            Assert.IsTrue(testGraph.NodeList[0].ID.Equals(testNode.ID));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "图中已包含重复ID节点")]
        public void AddRepeatNodeTest()
        {
            Guid testID = Guid.NewGuid();
            Node testNode = new Node("test", testID);
            Graph testGraph = new Graph();
            testGraph.AddNode(testNode);
            testGraph.AddNode(testNode);

        }

        [TestMethod()]
        public void AddEdgeTest()
        {
            Graph testGraph = new Graph();
            Guid AID = Guid.NewGuid();
            Node ANode = new Node("A", AID);
            testGraph.AddNode(ANode);
            Guid BID = Guid.NewGuid();
            Node BNode = new Node("B", BID);
            testGraph.AddNode(BNode);
            testGraph.AddEdge(AID, BID);
            Assert.AreEqual(testGraph.EdgeList[0].Source, AID);
            Assert.AreEqual(testGraph.EdgeList[0].Target, BID);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "图中不包含该源点")]
        public void AddEdgeSourceNullTest()
        {
            Graph testGraph = new Graph();
            Guid AID = Guid.NewGuid();
            Node ANode = new Node("A", AID);
            testGraph.AddNode(ANode);
            testGraph.AddEdge(Guid.NewGuid(), AID);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "图中不包含该终点")]
        public void AddEdgeTargetNullTest()
        {
            Graph testGraph = new Graph();
            Guid AID = Guid.NewGuid();
            Node ANode = new Node("A", AID);
            testGraph.AddNode(ANode);
            testGraph.AddEdge(AID, Guid.NewGuid());
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "不能添加源点和终点相同的边")]
        public void AddEdgeSameSourceAndTargetTest()
        {
            Graph testGraph = new Graph();
            Guid AID = Guid.NewGuid();
            Node ANode = new Node("A", AID);
            testGraph.AddNode(ANode);
            testGraph.AddEdge(AID, AID);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "不能添加重复的边")]
        public void AddEdgeRepeatTest()
        {
            Graph testGraph = new Graph();
            Guid AID = Guid.NewGuid();
            Node ANode = new Node("A", AID);
            testGraph.AddNode(ANode);
            Guid BID = Guid.NewGuid();
            Node BNode = new Node("B", BID);
            testGraph.AddNode(BNode);
            testGraph.AddEdge(AID, BID);
            testGraph.AddEdge(AID, BID);
        }

        [TestMethod()]
        public void GetAllPathFromAToBTest()
        {
            Graph testGraph = new Graph();

            // 添加A、B、C三个节点
            Guid AID = Guid.NewGuid();
            Node ANode = new Node("A", AID);
            testGraph.AddNode(ANode);
            Guid BID = Guid.NewGuid();
            Node BNode = new Node("B", BID);
            testGraph.AddNode(BNode);
            Guid CID = Guid.NewGuid();
            Node CNode = new Node("C", CID);
            testGraph.AddNode(CNode);
            Guid DID = Guid.NewGuid();
            Node DNode = new Node("D", DID);
            testGraph.AddNode(DNode);
            // 添加 A->B B->C A->C 三条边
            testGraph.AddEdge(AID, BID);
            testGraph.AddEdge(BID, CID);
            testGraph.AddEdge(CID, AID);
            testGraph.AddEdge(AID, DID);
            testGraph.AddEdge(CID, DID);
            // 获得 节点A 到 节点C 所有路径A
            List<List<Guid>> correctResult = new List<List<Guid>>
            {
                new List<Guid> { AID, BID, CID , DID},
                new List<Guid> { AID, DID }
            };
            List<List<Guid>> testResult = testGraph.GetAllPathFromStartToEnd(AID, DID);
            Assert.AreEqual(testResult.Count, correctResult.Count);
            for (int i = 0; i < testResult.Count; i++)
            {
                for (int j = 0; j < testResult[i].Count; j++)
                {
                    if (testResult[i][j] != correctResult[i][j])
                    {
                        Assert.Fail();
                    }
                }
            }
        }

        [TestMethod()]
        public void GetAllPathFromStartNodeTest()
        {
            Graph testGraph = new Graph();

            // 添加A、B、C三个节点 其中A、B为起始节点
            Guid AID = Guid.NewGuid();
            Node ANode = new Node("A", AID, true);
            testGraph.AddNode(ANode);
            Guid BID = Guid.NewGuid();
            Node BNode = new Node("B", BID, true);
            testGraph.AddNode(BNode);
            Guid CID = Guid.NewGuid();
            Node CNode = new Node("C", CID);
            testGraph.AddNode(CNode);
            // 添加 A->B B->C A->C 三条边
            testGraph.AddEdge(AID, BID);
            testGraph.AddEdge(BID, CID);
            testGraph.AddEdge(AID, CID);
            // 获得 所有起始节点 到 节点C 所有路径
            List<List<Guid>> correctResult = new List<List<Guid>>
            {
                new List<Guid> { AID, BID, CID },
                new List<Guid> { AID, CID },
                new List<Guid> { BID, CID }
            };
            List<List<Guid>> testResult = testGraph.GetAllPathFromStartNode(CID);
            Assert.AreEqual(testResult.Count, correctResult.Count);
            for (int i = 0; i < testResult.Count; i++)
            {
                for (int j = 0; j < testResult[i].Count; j++)
                {
                    if (testResult[i][j] != correctResult[i][j])
                    {
                        Assert.Fail();
                    }
                }
            }
        }

       
    }
}