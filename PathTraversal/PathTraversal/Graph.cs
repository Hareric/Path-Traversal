using System;
using System.Collections.Generic;


namespace PathTraversal
{
    public class Graph
    {
        public List<Node> NodeList { set; get; }  // 节点列表
        public List<Edge> EdgeList { set; get; } // 边列表

        public Graph()
        {
            this.NodeList = new List<Node>();
            this.EdgeList = new List<Edge>();
        }

        public string IDToName(Guid ID)
        {
            return Node.IdNodeDict[ID].Name;
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
                    tmp.Add(Node.IdNodeDict[IDList[i][j]].Name);
                }
                ret.Add(tmp);

            }
            return ret;
        }

        /// <summary>
        /// 给图插入新节点
        /// </summary>
        /// <param name="name">节点名</param>
        public Guid AddNode(string name)
        {
            Node n = new Node(name);
            this.NodeList.Add(n);
            return n.ID;
        }

        /// <summary>
        /// 给图插入新起始点
        /// </summary>
        /// <param name="name">顶点名</param>
        public Guid AddStartNode(string name)
        {
            Node n = new Node(name, true);
            this.NodeList.Add(n);
            return n.ID;
        }

        ///// <summary>
        ///// 根据节点名 插入边
        ///// </summary>
        ///// <param name="nodeSourceName">起点节点名</param>
        ///// <param name="nodeTargetName">终点节点名</param>
        //public void AddEdge(string nodeSourceName, string nodeTargetName)
        //{
        //    AddEdge(Node.nodeNameID[nodeSourceName], Node.nodeNameID[nodeTargetName]);
        //}

        /// <summary>
        /// 根据节点ID 插入边
        /// </summary>
        /// <param name="nodeSourceID"></param>
        /// <param name="nodeTargetID"></param>
        public void AddEdge(Guid nodeSourceID, Guid nodeTargetID)
        {
            if (!Node.IdNodeDict.ContainsKey(nodeSourceID))
            {
                throw new ArgumentException("图中不包含该源点");
            }
            if (!Node.IdNodeDict.ContainsKey(nodeTargetID))
            {
                throw new ArgumentException("图中不包含该终点");
            }
            if (nodeSourceID == nodeTargetID)
            {
                throw new ArgumentException("不能添加源点和终点相同的边");
            }
            Edge e = new Edge(nodeSourceID, nodeTargetID);
            if (IsContainEdge(e))
            {
                throw new ArgumentException("不能添加重复的边");
            }
            this.EdgeList.Add(e);
        }

        /// <summary>
        /// 判断是否添加重复的边
        /// </summary>
        /// <param name="edge"></param>
        /// <returns></returns>
        private bool IsContainEdge(Edge edge)
        {
            for (int i = 0; i < this.EdgeList.Count; i++)
            {
                if (EdgeList[i].Source == edge.Source && EdgeList[i].Target == edge.Target)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
