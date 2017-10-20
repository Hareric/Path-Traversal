using System;
using System.Collections.Generic;

namespace PathTraversal
{
    public class Node 
    {
        public static Dictionary<Guid, Node> IdNodeDict = new Dictionary<Guid, Node>();  // 节点ID：节点
        public Guid ID { get; set; }  // 节点ID
        public string Name { get; set; }  // 节点的值
        public bool IsStartNode { get; set; }  // 该节点是否为起始点

        public Node(string name, bool isStartNode = false)
        {
            this.ID = Guid.NewGuid();
            this.IsStartNode = isStartNode;
            this.Name = name;
            Node.IdNodeDict.Add(this.ID, this);
        }

       
    }
    
}
