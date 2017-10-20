using System;
using System.Collections.Generic;


namespace PathTraversal
{
    public class Graph
    {
        public List<Node> nodeList { set; get; }  // 节点列表
        public List<Edge> edgeList { set; get; } // 边列表

        public Graph() 
        {
            this.nodeList = new List<Node>();
            this.edgeList = new List<Edge>();
        }

        public string IDToName(Guid ID)
        {
            return Node.nodeIdNode[ID].name;
        }

        /// <summary>
        /// 将ID列表转化为节点名列表
        /// </summary>
        /// <param name="IDList"></param>
        /// <returns></returns>
        public List<List<string>> IDToName(List<List<Guid>> IDList)
        {
            List<List<string>> ret = new List<List<string>>();

            for (int i = 0; i < IDList.Count; i++)
            {
                List<string> tmp = new List<string>();
                for (int j = 0; j < IDList[i].Count; j++)
                {
                    tmp.Add(Node.nodeIdNode[IDList[i][j]].name);
                }
                ret.Add(tmp);

            }
            return ret;
        }



        /// <summary>
        /// 给图插入新节点
        /// </summary>
        /// <param name="name">节点名</param>
        public void addNode(string name)
        {
            if (isContain(name))
            {
                throw new ArgumentException("插入了重复节点！");
            }
            Node n = new Node(name);
            this.nodeList.Add(n);
        }

        /// <summary>
        /// 给图插入新顶点
        /// </summary>
        /// <param name="name">顶点名</param>
        public void addVertex(string name)
        {
            if (isContain(name))
            {
                throw new ArgumentException("插入了重复顶点！");
            }
            Node n = new Node(name, true);
            this.nodeList.Add(n);
        }

        /// <summary>
        /// 根据节点名 插入边
        /// </summary>
        /// <param name="nodeSourceName">起点节点名</param>
        /// <param name="nodeTargetName">终点节点名</param>
        public void addEdge(string nodeSourceName, string nodeTargetName)
        {
            addEdge(Node.nodeNameID[nodeSourceName], Node.nodeNameID[nodeTargetName]);
        }

        /// <summary>
        /// 根据节点ID 插入边
        /// </summary>
        /// <param name="nodeSourceID"></param>
        /// <param name="nodeTargetID"></param>
        public void addEdge(Guid nodeSourceID, Guid nodeTargetID)
        {
            Edge e = new Edge(nodeSourceID, nodeTargetID);
            this.edgeList.Add(e);
        }
      
        /// <summary>
        /// 判断插入的节点名是否重复
        /// </summary>
        /// <param name="name">节点名</param>
        /// <returns></returns>
        public bool isContain(string name)
        {
            if (Node.nodeNameID.ContainsKey(name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
