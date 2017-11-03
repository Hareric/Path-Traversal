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
    public class NodeTests
    {
        [TestMethod()]
        public void NodeTest()
        {
            Guid testID = Guid.NewGuid();
            string testName = "test";
            Node testNode = new Node("test", testID);
            Assert.AreEqual(testNode.Name, testName);
            Assert.AreEqual(testNode.ID, testID);
            Assert.IsFalse(testNode.IsStartNode);
        }

        [TestMethod()]
        public void StartNodeTest()
        {
            Guid testID = Guid.NewGuid();
            string testName = "test";
            Node testNode = new Node("test", testID, true);
            Assert.AreEqual(testNode.Name, testName);
            Assert.AreEqual(testNode.ID, testID);
            Assert.IsTrue(testNode.IsStartNode);
        }
    }
}