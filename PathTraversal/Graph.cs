using System;
using System.Collections.Generic;
using System.Linq;

namespace PathTraversal
{
    public class Graph
    {
        public List<Node> NodeList { set; get; }  // 节点列表
        public List<Edge> EdgeList { set; get; } // 边列表

        private List<List<Guid>> PathList = new List<List<Guid>>();
        private List<Guid> OnePath = new List<Guid>();
        private Stack<Guid> Stack = new Stack<Guid>();

        public Graph()
        {
            this.NodeList = new List<Node>();
            this.EdgeList = new List<Edge>();
        }

        /// <summary>
        /// 给图插入新节点
        /// </summary>
        /// <param name="name">节点名</param>
        public void AddNode(Node node)
        {
            if (IsContainNode(node.ID))
            {
                throw new ArgumentException("图中已包含重复ID节点");
            }
            else
            {
                this.NodeList.Add(node);
            }
        }


        /// <summary>
        /// 根据节点ID 插入边
        /// </summary>
        /// <param name="nodeSourceID"></param>
        /// <param name="nodeTargetID"></param>
        public void AddEdge(Guid nodeSourceID, Guid nodeTargetID)
        {
            if (!IsContainNode(nodeSourceID))
            {
                throw new ArgumentException("图中不包含该源点");
            }
            if (!IsContainNode(nodeTargetID))
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

        /// <summary>
        /// 判断是否包含该节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private bool IsContainNode(Guid id)
        {
            for (int i = 0; i < this.NodeList.Count; i++)
            {
                if (id.Equals(this.NodeList[i].ID))
                {
                    return true;
                }
            }
            return false;
        }




        /// <summary>
        /// 返回 所有起始节点到指定节点的所有路径（使用id表示节点）
        /// </summary>
        /// <param name="endID">指定节点ID</param>
        /// <returns></returns>
        public List<List<Guid>> GetAllPathFromStartNode(Guid targetNodeID)
        {
            List<List<Guid>> ret = new List<List<Guid>>();
            //List<int> Result = listA.Concat(listB).ToList<int>();
            for (int i = 0; i < this.NodeList.Count; i++)
            {
                if (this.NodeList[i].IsStartNode)
                {
                    ret = ret.Concat(GetAllPathBetweenTwoNode(this.NodeList[i].ID, targetNodeID)).ToList<List<Guid>>();
                }

            }
            return ret;
        }


        /// <summary>
        /// 返回遍历指定两点之间的所有路径 并初始化（试用id表示节点）
        /// </summary>
        /// <param name="startID"></param>
        /// <param name="endID"></param>
        /// <returns></returns>
        public List<List<Guid>> GetAllPathBetweenTwoNode(Guid startID, Guid endID)
        {
            if (!this.IsContainNode(startID) || !this.IsContainNode(endID))
            {
                throw new ArgumentException("无法获取图中不存在的节点之间的路径");
            }
            DepthFirstTraversal(ref startID, ref endID);
            List<List<Guid>> ret = this.PathList.ToList();

            this.PathList.Clear();
            this.OnePath.Clear();
            this.Stack.Clear();
            return ret;
        }

        /// <summary>
        /// 使用深度优先遍历算法遍历查找指定两个节点之间的所有路径
        /// </summary>
        /// <param name="startID"></param>
        /// <param name="endID"></param>
        private void DepthFirstTraversal(ref Guid startID, ref Guid endID)
        {
            if (Stack.Count == 0)
            {
                Stack.Push(startID);
                OnePath.Add(startID);
                DepthFirstTraversal(ref startID, ref endID);
            }
            else if (Stack.Peek() == endID)
            {
                PathList.Add(OnePath.ToList<Guid>());
                return;
            }
            else if (Stack.Peek() == startID)
            {
                return;
            }
            Edge e;
            for (int i = 0; i < this.EdgeList.Count; i++)
            {
                e = this.EdgeList[i];
                if (e.Source == Stack.Peek())
                {
                    if (Stack.Contains(e.Target))
                    {
                        continue;
                    }
                    else
                    {
                        Stack.Push(e.Target);
                        OnePath.Add(e.Target);
                        DepthFirstTraversal(ref startID, ref endID);
                        Stack.Pop();
                        OnePath.RemoveAt(OnePath.Count - 1);
                    }
                }
            }

        }

        public static int fact(int n)
        {
            if (n == 1 || n == 0)
                return 1;
            else
                return n * fact(n - 1);
        }

        public static void Main(string[] args)
        {
            int nodeNum = 11;
            int a = fact(nodeNum - 2);
            Console.WriteLine(a);
            double b = 0;
            for (int i = 0; i <= nodeNum - 2; i++)
            {
                b += 1.0 / fact(i);
                Console.WriteLine(b);
            }
            Console.WriteLine((int)(a * b));
            Console.ReadKey();
        }


    }
}
