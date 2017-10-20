using System;
using System.Collections.Generic;
using System.Linq;

namespace PathTraversal
{
    public class FindPath
    {
        public Graph Graph { set; get; }
        private List<List<Guid>> PathList = new List<List<Guid>>();
        List<Guid> OnePath = new List<Guid>();
        private Stack<Guid> Stack = new Stack<Guid>();

        ///// <summary>
        ///// 返回 所有顶点到指定节点的所有路径（使用id表示节点）
        ///// </summary>
        ///// <param name="endNodeName">指定节点名</param>
        ///// <returns></returns>
        //public List<List<Guid>> GetAllPathFromVertex(string endNodeName)
        //{
        //    Guid endNodeID = Node.nodeNameID[endNodeName];
        //    List<List<Guid>> ret = new List<List<Guid>>();
        //    //List<int> Result = listA.Concat(listB).ToList<int>();
        //    for (int i = 0; i < Graph.NodeList.Count; i++)
        //    {
        //        if (Graph.NodeList[i].IsStartNode)
        //        {
        //            ret = ret.Concat(GetAllPathFromAToB(Graph.NodeList[i].ID, endNodeID)).ToList<List<Guid>>();
        //        }

        //    }
        //    return ret;
        //}

        /// <summary>
        /// 返回 所有顶点到指定节点的所有路径（使用id表示节点）
        /// </summary>
        /// <param name="endID">指定节点ID</param>
        /// <returns></returns>
        public List<List<Guid>> GetAllPathFromVertex(Guid endNodeID)
        {
            List<List<Guid>> ret = new List<List<Guid>>();
            //List<int> Result = listA.Concat(listB).ToList<int>();
            for (int i = 0; i < Graph.NodeList.Count; i++)
            {
                if (Graph.NodeList[i].IsStartNode)
                {
                    ret = ret.Concat(GetAllPathFromAToB(Graph.NodeList[i].ID, endNodeID)).ToList<List<Guid>>();
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
        public List<List<Guid>> GetAllPathFromAToB(Guid startID, Guid endID)
        {
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
            for (int i = 0; i < this.Graph.EdgeList.Count; i++)
            {
                e = this.Graph.EdgeList[i];
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
    }
}
