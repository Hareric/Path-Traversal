using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace PathTraversal.Tests
{
    [TestClass()]
    public class FindPathTests
    {
        [TestMethod()]
        public void GetAllPathTest()
        {
            Graph testGraph = new Graph();
            Guid AID = testGraph.AddNode("A");
            Guid BID = testGraph.AddNode("B");
            Guid CID = testGraph.AddNode("C");
            testGraph.AddEdge(AID, BID);
            testGraph.AddEdge(BID, CID);
            testGraph.AddEdge(AID, CID);
            List<List<Guid>> testResult = new List<List<Guid>>
            {
                new List<Guid> { AID, BID, CID },
                new List<Guid> { AID, CID }
            };
            FindPath fp = new FindPath
            {
                Graph = testGraph
            };
            List<List<Guid>> realResult = fp.GetAllPathFromAToB(AID, CID);

            if (testResult.Count == realResult.Count)
            {
                for (int i = 0; i < testResult.Count; i++)
                {
                    for (int j = 0; j < testResult[i].Count; j++)
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