using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace PathTraversal.Tests
{
    [TestClass()]
    public class FindPathTests
    {
        [TestMethod()]
        public void getAllPathTest()
        {
            Graph testGraph = new Graph();
            testGraph.addNode("A");
            testGraph.addNode("B");
            testGraph.addNode("C");
            testGraph.addEdge("A", "B");
            testGraph.addEdge("B", "C");
            testGraph.addEdge("A", "C");
            Guid AID = Node.nodeNameID["A"], BID = Node.nodeNameID["B"], CID = Node.nodeNameID["C"];
            List<List<Guid>> testResult = new List<List<Guid>>
            {
                new List<Guid> { AID, BID, CID },
                new List<Guid> { AID, CID }
            };
            FindPath fp = new FindPath();
            fp.graph = testGraph;
            List<List<Guid>>  realResult = fp.getAllPathFromAToB(AID, CID);

            if (testResult.Count == realResult.Count)
            {
                for (int i=0; i<testResult.Count; i++)
                {
                    for (int j=0; j<testResult[i].Count; j++)
                    {
                        if (testResult[i][j] != realResult[i][j])
                        {
                            Assert.Fail();
                        }
                    }
                }
            }
            else
            {
                Assert.Fail();
            }
        }

       
    }
}