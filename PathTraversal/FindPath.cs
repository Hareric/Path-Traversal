using System;
using System.Collections.Generic;
using System.Linq;

namespace PathTraversal
{
    public class FindPath
    {
        public Graph graph { set; get; }
        public List<List<Guid>> pathList = new List<List<Guid>>();
        List<Guid> onePath = new List<Guid>();
        public Stack<Guid> st = new Stack<Guid>();



        /// <summary>
        /// 返回 所有顶点到指定节点的所有路径（使用id表示节点）
        /// </summary>
        /// <param name="endNodeName">指定节点名</param>
        /// <returns></returns>
        public List<List<Guid>> getAllPathFromVertex(string endNodeName)
        {
            Guid endNodeID = Node.nodeNameID[endNodeName];
            List<List<Guid>> ret = new List<List<Guid>>();
            //List<int> Result = listA.Concat(listB).ToList<int>();
            for (int i = 0; i < graph.nodeList.Count; i++)
            {
                if (graph.nodeList[i].isVertex)
                {
                    ret = ret.Concat(getAllPathFromAToB(graph.nodeList[i].ID, endNodeID)).ToList<List<Guid>>();
                }

            }
            return ret;
        }

        /// <summary>
        /// 返回 所有顶点到指定节点的所有路径（使用id表示节点）
        /// </summary>
        /// <param name="endID">指定节点ID</param>
        /// <returns></returns>
        public List<List<Guid>> getAllPathFromVertex(Guid endNodeID)
        {
            List<List<Guid>> ret = new List<List<Guid>>();
            //List<int> Result = listA.Concat(listB).ToList<int>();
            for (int i=0; i<graph.nodeList.Count; i++)
            {
                if (graph.nodeList[i].isVertex)
                {
                    ret = ret.Concat(getAllPathFromAToB(graph.nodeList[i].ID, endNodeID)).ToList<List<Guid>>();
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
        public List<List<Guid>> getAllPathFromAToB(Guid startID,  Guid endID)
        {
            findPath(ref startID, ref endID);
            List<List<Guid>> ret = this.pathList.ToList();
            
            this.pathList.Clear();
            this.onePath.Clear();
            this.st.Clear();
            return ret;
        }

        /// <summary>
        /// 遍历查找指定两个节点之间的所有路径
        /// </summary>
        /// <param name="startID"></param>
        /// <param name="endID"></param>
        private void findPath(ref Guid startID, ref Guid endID)
        {
            if (st.Count == 0)
            {
                st.Push(startID);
                onePath.Add(startID);
                findPath(ref startID, ref endID);
            }
            else if (st.Peek() == endID)
            {
                pathList.Add(onePath.ToList<Guid>());
                return;
            }
            else if (st.Peek() == startID)
            {
                return;
            }
            Edge e;
            for (int i=0; i<this.graph.edgeList.Count; i++)
            {
                e = this.graph.edgeList[i];
                if (e.source == st.Peek())
                {
                    if (st.Contains(e.target))
                    {
                        continue;
                    }
                    else
                    {
                        st.Push(e.target);
                        onePath.Add(e.target);
                        findPath(ref startID, ref endID);
                        st.Pop();
                        onePath.RemoveAt(onePath.Count - 1);
                    }
                }
            }
            
        }



    }
}
