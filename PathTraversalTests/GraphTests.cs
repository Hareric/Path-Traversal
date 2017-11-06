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
        public void AddStartNodeTest()
        {
            Guid testID = Guid.NewGuid();
            Node testNode = new Node("test", testID, true);
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
        [ExpectedException(typeof(ArgumentException),
            "图中已包含重复ID节点")]
        public void AddRepeatNodeAndStartNodeTest()
        {
            Guid testID = Guid.NewGuid();
            Node testNode = new Node("test node", testID);
            Node testStartNode = new Node("test startnode", testID, true);
            Graph testGraph = new Graph();
            testGraph.AddNode(testNode);
            testGraph.AddNode(testStartNode);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "图中已包含重复ID节点")]
        public void AddRepeatStartNodeTest()
        {
            Guid testID = Guid.NewGuid();
            Node testNode = new Node("test", testID, true);
            Graph testGraph = new Graph();
            testGraph.AddNode(testNode);
            testGraph.AddNode(testNode);
        }

        [TestMethod()]
        public void AddNodeHugeTest()
        {
            Graph testGraph = new Graph();

            for (int i = 0; i < 10000; i++)
            {
                Guid testID = Guid.NewGuid();
                Node testNode = new Node(i.ToString(), testID);
                testGraph.AddNode(testNode);
                Assert.IsTrue(testGraph.NodeList[i].ID.Equals(testNode.ID));
            }

        }

        [TestMethod()]
        public void AddEdgeNodeToNodeTest()
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
        public void AddEdgeStartNodeToStartNodeTest()
        {
            Graph testGraph = new Graph();
            Guid AID = Guid.NewGuid();
            Node ANode = new Node("A", AID, true);
            testGraph.AddNode(ANode);
            Guid BID = Guid.NewGuid();
            Node BNode = new Node("B", BID, true);
            testGraph.AddNode(BNode);
            testGraph.AddEdge(AID, BID);
            Assert.AreEqual(testGraph.EdgeList[0].Source, AID);
            Assert.AreEqual(testGraph.EdgeList[0].Target, BID);
        }

        [TestMethod()]
        public void AddEdgeNodeToStartNodeTest()
        {
            Graph testGraph = new Graph();
            Guid AID = Guid.NewGuid();
            Node ANode = new Node("A", AID);
            testGraph.AddNode(ANode);
            Guid BID = Guid.NewGuid();
            Node BNode = new Node("B", BID, true);
            testGraph.AddNode(BNode);
            testGraph.AddEdge(AID, BID);
            Assert.AreEqual(testGraph.EdgeList[0].Source, AID);
            Assert.AreEqual(testGraph.EdgeList[0].Target, BID);
        }

        [TestMethod()]
        public void AddEdgeStartNodeToNodeTest()
        {
            Graph testGraph = new Graph();
            Guid AID = Guid.NewGuid();
            Node ANode = new Node("A", AID, true);
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
        public void AddEdgeHugeTest()
        {
            Graph testGraph = new Graph();
            for (int i = 0; i < 4000; i++)
            {
                Guid AID = Guid.NewGuid();
                Node ANode = new Node("A_" + i.ToString(), AID);
                testGraph.AddNode(ANode);
                Guid BID = Guid.NewGuid();
                Node BNode = new Node("B_" + i.ToString(), BID);
                testGraph.AddNode(BNode);
                testGraph.AddEdge(AID, BID);
                Assert.AreEqual(testGraph.EdgeList[i].Source, AID);
                Assert.AreEqual(testGraph.EdgeList[i].Target, BID);
            }
        }

        [TestMethod()]
        public void GraphTest()
        {
            Graph testGraph = new Graph();
            Assert.AreEqual(testGraph.EdgeList.Count, 0);
            Assert.AreEqual(testGraph.NodeList.Count, 0);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "无法获取图中不存在的节点之间的路径")]
        public void GetAllPathBetweenTwoNodeNullStartTest()
        {
            Graph testGraph = new Graph();

            // 添加A、B节点
            Guid AID = Guid.NewGuid();
            Node ANode = new Node("A", AID);
            testGraph.AddNode(ANode);
            Guid BID = Guid.NewGuid();
            Node BNode = new Node("B", BID);
            testGraph.AddNode(BNode);
            testGraph.GetAllPathBetweenTwoNode(Guid.NewGuid(), BID);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "无法获取图中不存在的节点之间的路径")]
        public void GetAllPathBetweenTwoNodeNullEndTest()
        {
            Graph testGraph = new Graph();

            // 添加A、B节点
            Guid AID = Guid.NewGuid();
            Node ANode = new Node("A", AID);
            testGraph.AddNode(ANode);
            Guid BID = Guid.NewGuid();
            Node BNode = new Node("B", BID);
            testGraph.AddNode(BNode);
            testGraph.GetAllPathBetweenTwoNode(BID, Guid.NewGuid());
        }

        /// <summary>
        /// 在一个包含环的图中进行测试
        /// </summary>
        [TestMethod()]
        public void GetAllPathBetweenTwoNodeStartInCycleGraphTest()
        {
            Graph testGraph = new Graph();

            // 添加A、B、C、D四个节点
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
            // 添加 A->B B->C C->A A->D 4条边 其中节点ABC之间存在环状结构
            testGraph.AddEdge(AID, BID);
            testGraph.AddEdge(BID, CID);
            testGraph.AddEdge(CID, AID);
            testGraph.AddEdge(AID, DID);
            // 获得 节点A 到 节点C 所有路径A
            List<List<Guid>> correctResult = new List<List<Guid>>
            {
                new List<Guid> { AID, DID }
            };
            List<List<Guid>> testResult = testGraph.GetAllPathBetweenTwoNode(AID, DID);
            Assert.IsTrue(IsSameList(testResult, correctResult));
        }
        
        [TestMethod()]
        public void GetAllPathBetweenTwoNodeEndInCycleGraphTest()
        {
            Graph testGraph = new Graph();

            // 添加A、B、C、D四个节点
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
            // 添加 A->B B->D D->C C->B 4条边 其中节点BDC之间存在环状结构
            testGraph.AddEdge(AID, BID);
            testGraph.AddEdge(BID, DID);
            testGraph.AddEdge(DID, CID);
            testGraph.AddEdge(CID, BID);
            // 获得 节点A 到 节点D 所有路径
            List<List<Guid>> correctResult = new List<List<Guid>>
            {
                new List<Guid> { AID, BID, DID }
            };
            List<List<Guid>> testResult = testGraph.GetAllPathBetweenTwoNode(AID, DID);
            Assert.IsTrue(IsSameList(testResult, correctResult));
        }

        [TestMethod()]
        public void GetAllPathBetweenTwoNodeNoPathTest()
        {
            Graph testGraph = new Graph();

            // 添加A、B、C、D四个节点
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

            // 添加 A->B A->C 边
            testGraph.AddEdge(AID, BID);
            testGraph.AddEdge(AID, CID);
            // 获得 节点A 到 节点D 所有路径
            List<List<Guid>> testResult = testGraph.GetAllPathBetweenTwoNode(AID, DID);
            Assert.AreEqual(testResult.Count, 0);
        }
        [TestMethod()]
        public void GetAllPathBetweenTwoNodeOnePathTest()
        {
            Graph testGraph = new Graph();

            // 添加A、B、C、D 四个节点
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

            // 添加 A->B B->D A->C 边
            testGraph.AddEdge(AID, BID);
            testGraph.AddEdge(BID, DID);
            testGraph.AddEdge(AID, CID);
            // 获得 节点A 到 节点D 所有路径
            List<List<Guid>> correctResult = new List<List<Guid>>
                                                { new List<Guid> { AID, BID, DID } };
            List<List<Guid>> testResult = testGraph.GetAllPathBetweenTwoNode(AID, DID);
            Assert.IsTrue(IsSameList(testResult, correctResult));
        }

        [TestMethod()]
        public void GetAllPathBetweenTwoNodeManyPathTest()
        {
            Graph testGraph = new Graph();

            // 添加A、B、C、D 四个节点
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

            // 添加 A->B B->D A->C C->D边
            testGraph.AddEdge(AID, BID);
            testGraph.AddEdge(BID, DID);
            testGraph.AddEdge(AID, CID);
            testGraph.AddEdge(CID, DID);
            // 获得 节点A 到 节点D 所有路径
            List<List<Guid>> correctResult = new List<List<Guid>>
                                                { new List<Guid> { AID, BID, DID },
                                                    new List<Guid> { AID, CID, DID }};
            List<List<Guid>> testResult = testGraph.GetAllPathBetweenTwoNode(AID, DID);
            Assert.IsTrue(IsSameList(testResult, correctResult));
        }

        [TestMethod()]
        public void GetAllPathBetweenTwoNodeSameNodeTest()
        {
            Graph testGraph = new Graph();

            // 添加A、B、C点
            Guid AID = Guid.NewGuid();
            Node ANode = new Node("A", AID);
            testGraph.AddNode(ANode);
            Guid BID = Guid.NewGuid();
            Node BNode = new Node("B", BID);
            testGraph.AddNode(BNode);
            Guid CID = Guid.NewGuid();
            Node CNode = new Node("C", CID);
            testGraph.AddNode(CNode);

            // 添加 A->B B->C C->A 边 
            testGraph.AddEdge(AID, BID);
            testGraph.AddEdge(BID, CID);
            testGraph.AddEdge(CID, AID);

            List<List<Guid>> correctResult = new List<List<Guid>>
                                                { new List<Guid> { AID } };
            List<List<Guid>> testResult = testGraph.GetAllPathBetweenTwoNode(AID, AID);
            Assert.IsTrue(IsSameList(correctResult, testResult));
        }

        [TestMethod()]
        public void GetAllPathBetweenTwoNodeIsolatedStartTest()
        {
            Graph testGraph = new Graph();

            // 添加A、B、C、D点
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

            // 添加 A->B B->C C->A 边 
            testGraph.AddEdge(AID, BID);
            testGraph.AddEdge(BID, CID);
            testGraph.AddEdge(CID, AID);
            // 获得 节点D 到 节点A 所有路径
            List<List<Guid>> testResult = testGraph.GetAllPathBetweenTwoNode(DID, AID);
            Assert.AreEqual(testResult.Count, 0);
        }

        [TestMethod()]
        public void GetAllPathBetweenTwoNodeIsolatedEndTest()
        {
            Graph testGraph = new Graph();

            // 添加A、B、C、D点
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

            // 添加 A->B B->C C->A 边 
            testGraph.AddEdge(AID, BID);
            testGraph.AddEdge(BID, CID);
            testGraph.AddEdge(CID, AID);
            // 获得 节点D 到 节点A 所有路径
            List<List<Guid>> testResult = testGraph.GetAllPathBetweenTwoNode(AID, DID);
            Assert.AreEqual(testResult.Count, 0);
        }

        [TestMethod()]
        public void GetAllPathBetweenTwoNodeHugeTest()
        {
            int testNum = 11;  // 完全图节点个数
            Graph testGraph = new Graph();
            int realPathNum = CalPathNumInCompleteGraph(testNum);  // 完全图中任意2点的路径个数相同
            for (int i = 0; i < testNum; i++)
            {
                Guid testNodeID = Guid.NewGuid();
                Node testNode = new Node(i.ToString(), testNodeID);
                testGraph.AddNode(testNode);
            }
            // 添加边 构建完全图
            for (int i = 0; i < testNum; i++)
            {
                for (int j = 0; j < testNum; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    testGraph.AddEdge(testGraph.NodeList[i].ID, testGraph.NodeList[j].ID);
                }
            }
            List<List<Guid>> testResult = testGraph.GetAllPathBetweenTwoNode(testGraph.NodeList[0].ID, testGraph.NodeList[1].ID);
            Assert.AreEqual(testResult.Count, realPathNum);
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
            Assert.IsTrue(IsSameList(testResult, correctResult));
        }

        [TestMethod()]
        public void GetAllPathFromStartNodeAsTargetTest()
        {
            Graph testGraph = new Graph();

            // 添加A、B、C、D四个节点 其中A、B、D为起始节点
            Guid AID = Guid.NewGuid();
            Node AStartNode = new Node("A", AID, true);
            testGraph.AddNode(AStartNode);
            Guid BID = Guid.NewGuid();
            Node BStartNode = new Node("B", BID, true);
            testGraph.AddNode(BStartNode);
            Guid CID = Guid.NewGuid();
            Node CNode = new Node("C", CID);
            testGraph.AddNode(CNode);
            Guid DID = Guid.NewGuid();
            Node DStartNode = new Node("D", DID, true);
            testGraph.AddNode(DStartNode);
            // 添加 A->B B->C C->D 三条边
            testGraph.AddEdge(AID, BID);
            testGraph.AddEdge(BID, CID);
            testGraph.AddEdge(CID, DID);
            // 获得 所有起始节点 到 节点C 所有路径
            List<List<Guid>> correctResult = new List<List<Guid>>
            {
                new List<Guid> { AID, BID, CID, DID},
                new List<Guid> { BID, CID, DID },
                new List<Guid> {DID}
            };
            List<List<Guid>> testResult = testGraph.GetAllPathFromStartNode(DID);
            Assert.IsTrue(IsSameList(testResult, correctResult));
        }

        [TestMethod()]
        public void GetAllPathFromStartNode2StartNodeInSamePathTest()
        {
            Graph testGraph = new Graph();

            // 添加A、B、C三个节点 其中A、B为起始节点
            Guid AID = Guid.NewGuid();
            Node AStartNode = new Node("A", AID, true);
            testGraph.AddNode(AStartNode);
            Guid BID = Guid.NewGuid();
            Node BStartNode = new Node("B", BID, true);
            testGraph.AddNode(BStartNode);
            Guid CID = Guid.NewGuid();
            Node CNode = new Node("C", CID);
            testGraph.AddNode(CNode);
            Guid DID = Guid.NewGuid();
            Node DNode = new Node("D", DID);
            testGraph.AddNode(DNode);
            // 添加 A->B B->C C->D 三条边
            testGraph.AddEdge(AID, BID);
            testGraph.AddEdge(BID, CID);
            testGraph.AddEdge(CID, DID);
            // 获得 所有起始节点 到 节点C 所有路径
            List<List<Guid>> correctResult = new List<List<Guid>>
            {
                new List<Guid> { AID, BID, CID, DID},
                new List<Guid> { BID, CID, DID }
            };
            List<List<Guid>> testResult = testGraph.GetAllPathFromStartNode(DID);
            Assert.IsTrue(IsSameList(testResult, correctResult));
        }

        [TestMethod()]
        public void GetAllPathFromStartNodeNoStartNodeTest()
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
            // 添加 A->B B->C A->C 三条边
            testGraph.AddEdge(AID, BID);
            testGraph.AddEdge(BID, CID);
            testGraph.AddEdge(AID, CID);
            // 获得 所有起始节点 到 节点C 所有路径
            List<List<Guid>> testResult = testGraph.GetAllPathFromStartNode(CID);
            Assert.AreEqual(testResult.Count, 0);
        }

        [TestMethod()]
        public void GetAllPathFromStartNodeOneStartNodeNoPathTest()
        {
            Graph testGraph = new Graph();

            // 添加A、B、C三个节点 其中A为起始节点
            Guid AID = Guid.NewGuid();
            Node AStartNode = new Node("A", AID, true);
            testGraph.AddNode(AStartNode);
            Guid BID = Guid.NewGuid();
            Node BNode = new Node("B", BID);
            testGraph.AddNode(BNode);
            Guid CID = Guid.NewGuid();
            Node CNode = new Node("C", CID);
            testGraph.AddNode(CNode);
            // 添加 A->B 边
            testGraph.AddEdge(AID, BID);
            // 获得 所有起始节点 到 节点C 所有路径
            List<List<Guid>> testResult = testGraph.GetAllPathFromStartNode(CID);
            Assert.AreEqual(testResult.Count, 0);
        }

        [TestMethod()]
        public void GetAllPathFromStartNodeOneStartNodeOnePathTest()
        {
            Graph testGraph = new Graph();

            // 添加A、B、C三个节点 其中A为起始节点
            Guid AID = Guid.NewGuid();
            Node AStartNode = new Node("A", AID, true);
            testGraph.AddNode(AStartNode);
            Guid BID = Guid.NewGuid();
            Node BNode = new Node("B", BID);
            testGraph.AddNode(BNode);
            Guid CID = Guid.NewGuid();
            Node CNode = new Node("C", CID);
            testGraph.AddNode(CNode);
            // 添加 A->B B->C 边
            testGraph.AddEdge(AID, BID);
            testGraph.AddEdge(BID, CID);
            // 获得 所有起始节点 到 节点C 所有路径
            List<List<Guid>> correctResult = new List<List<Guid>> {
            new List < Guid > { AID, BID, CID} };
            List <List<Guid>> testResult = testGraph.GetAllPathFromStartNode(CID);
            Assert.IsTrue(IsSameList(testResult, correctResult));
        }

        [TestMethod()]
        public void GetAllPathFromStartNodeOneStartNodeManyPathTest()
        {
            Graph testGraph = new Graph();

            // 添加A、B、C、D三个节点 其中A为起始节点
            Guid AID = Guid.NewGuid();
            Node AStartNode = new Node("A", AID, true);
            testGraph.AddNode(AStartNode);
            Guid BID = Guid.NewGuid();
            Node BNode = new Node("B", BID);
            testGraph.AddNode(BNode);
            Guid CID = Guid.NewGuid();
            Node CNode = new Node("C", CID);
            testGraph.AddNode(CNode);
            Guid DID = Guid.NewGuid();
            Node DNode = new Node("D", DID);
            testGraph.AddNode(DNode);
            // 添加 A->B B->D A->C C->D 边
            testGraph.AddEdge(AID, BID);
            testGraph.AddEdge(BID, DID);
            testGraph.AddEdge(AID, CID);
            testGraph.AddEdge(CID, DID);
            // 获得 所有起始节点 到 节点C 所有路径
            List<List<Guid>> correctResult = new List<List<Guid>> {
            new List < Guid > { AID, BID, DID},
            new List < Guid > { AID, CID, DID}};
            List<List<Guid>> testResult = testGraph.GetAllPathFromStartNode(DID);
            Assert.IsTrue(IsSameList(testResult, correctResult));
        }

        [TestMethod()]
        public void GetAllPathFromStartNodeManyStartNodeOnePathTest()
        {
            Graph testGraph = new Graph();

            // 添加A、B、C三个节点 其中A C为起始节点
            Guid AID = Guid.NewGuid();
            Node AStartNode = new Node("A", AID, true);
            testGraph.AddNode(AStartNode);
            Guid BID = Guid.NewGuid();
            Node BNode = new Node("B", BID);
            testGraph.AddNode(BNode);
            Guid CID = Guid.NewGuid();
            Node CNode = new Node("C", CID, true);
            testGraph.AddNode(CNode);

            // 添加 A->B 边
            testGraph.AddEdge(AID, BID);

            // 获得 所有起始节点 到 节点B 所有路径
            List<List<Guid>> correctResult = new List<List<Guid>> {
            new List < Guid > { AID, BID}};
            List<List<Guid>> testResult = testGraph.GetAllPathFromStartNode(BID);
            Assert.IsTrue(IsSameList(testResult, correctResult));
        }

        [TestMethod()]
        public void GetAllPathFromStartNodeManyStartNodeManyPathTest()
        {
            Graph testGraph = new Graph();

            // 添加A、B、C三个节点 其中A C为起始节点
            Guid AID = Guid.NewGuid();
            Node AStartNode = new Node("A", AID, true);
            testGraph.AddNode(AStartNode);
            Guid BID = Guid.NewGuid();
            Node BNode = new Node("B", BID);
            testGraph.AddNode(BNode);
            Guid CID = Guid.NewGuid();
            Node CNode = new Node("C", CID, true);
            testGraph.AddNode(CNode);

            // 添加 A->B C->B边
            testGraph.AddEdge(AID, BID);
            testGraph.AddEdge(CID, BID);

            // 获得 所有起始节点 到 节点B 所有路径
            List<List<Guid>> correctResult = new List<List<Guid>> {
            new List < Guid > { AID, BID},
            new List < Guid > { CID, BID}};
            List<List<Guid>> testResult = testGraph.GetAllPathFromStartNode(BID);
            Assert.IsTrue(IsSameList(testResult, correctResult));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "无法获取图中不存在的节点之间的路径")]
        public void GetAllPathFromStartNodeNullTest()
        {
            Graph testGraph = new Graph();

            // 添加A、B、C三个节点 其中A、B为起始节点
            Guid AID = Guid.NewGuid();
            Node ANode = new Node("A", AID, true);
            testGraph.AddNode(ANode);
            Guid BID = Guid.NewGuid();
            Node BNode = new Node("B", BID, true);
            testGraph.AddNode(BNode);
            // 添加 A->B 边
            testGraph.AddEdge(AID, BID);
            // 获得 所有起始节点 到 节点C 所有路径
            List<List<Guid>> testResult = testGraph.GetAllPathFromStartNode(Guid.NewGuid());

        }

        [TestMethod()]
        public void GetAllPathFromStartNodeHugeTest()
        {
            int testNodeNum = 11;  // 完全图节点个数
            int testStartNodeNum = 2;  // 作为起始节点的个数
            int realPathNum = testStartNodeNum * CalPathNumInCompleteGraph(testNodeNum);
            if (testNodeNum == testStartNodeNum)
            // 若所有节点均为起始节点，测试时将使用起始节点作为目的节点
            {
                realPathNum -= CalPathNumInCompleteGraph(testNodeNum);
                realPathNum += 1;
            }
            Graph testGraph = new Graph();
            for (int i = 0; i < testNodeNum; i++)
            {
                Node testNode;
                Guid testNodeID = Guid.NewGuid();
                if (i < testStartNodeNum)
                {
                    testNode = new Node(i.ToString(), testNodeID, true);
                }
                else
                {
                    testNode = new Node(i.ToString(), testNodeID);
                }
                testGraph.AddNode(testNode);
            }
            // 添加边 构建完全图
            for (int i = 0; i < testNodeNum; i++)
            {
                for (int j = 0; j < testNodeNum; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    testGraph.AddEdge(testGraph.NodeList[i].ID, testGraph.NodeList[j].ID);
                }
            }
            List<List<Guid>> testResult = testGraph.GetAllPathFromStartNode(testGraph.NodeList[testNodeNum - 1].ID);
            Assert.AreEqual(testResult.Count, realPathNum);
        }




        /// <summary>
        /// 判断两个二维列表的值是否相同（元素的值和顺序是否完全相同）
        /// </summary>
        /// <param name="AList"></param>
        /// <param name="BList"></param>
        /// <returns></returns>
        bool IsSameList(List<List<Guid>> AList, List<List<Guid>> BList)
        {
            if (AList.Count != BList.Count)
            {
                return false;
            }

            for (int i = 0; i < AList.Count; i++)
            {
                if (AList[i].Count != BList[i].Count)
                {
                    return false;
                }
                for (int j = 0; j < AList[i].Count; j++)
                {
                    if (AList[i][j] != BList[i][j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 求阶乘
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Fact(int n)
        {
            if (n == 1 || n == 0)
                return 1;
            else
                return n * Fact(n - 1);
        }

        /// <summary>
        /// 计算完全图中 任意两点之间的路径的个数
        /// </summary>
        /// <param name="nodeNum">节点个数</param>
        /// <returns></returns>
        public int CalPathNumInCompleteGraph(int nodeNum)
        {

            int a = Fact(nodeNum - 2);
            double b = 0;
            for (int i = 0; i <= nodeNum - 2; i++)
            {
                b += 1.0 / Fact(i);
            }

            return (int)(a * b);

        }


    }
}