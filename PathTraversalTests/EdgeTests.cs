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
    public class EdgeTests
    {
        [TestMethod()]
        public void EdgeTest()
        {
            Guid sourceID = Guid.NewGuid();
            Guid targetID = Guid.NewGuid();
            Edge testEdge = new Edge(sourceID, targetID);
            Assert.AreEqual(sourceID, testEdge.Source);
            Assert.AreEqual(targetID, testEdge.Target);
        }
    }
}