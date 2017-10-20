using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathTraversal
{
    public class Node 
    {
        public static Dictionary<Guid, Node> nodeIdNode = new Dictionary<Guid, Node>();
        public static Dictionary<string, Guid> nodeNameID = new Dictionary<string, Guid>();
        public Guid ID { get; set; }  // 节点ID
        public string name { get; set; }  // 节点的值
        public bool isVertex { get; set; }  // 该节点是否为顶点

        public Node(string name, bool isVertex=false)
        {
            this.ID = Guid.NewGuid();
            this.isVertex = isVertex;
            this.name = name;
            Node.nodeIdNode.Add(this.ID, this);
            Node.nodeNameID.Add(this.name, this.ID);

        }

       
    }
    
}
