using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathTraversal
{
    class Test
    {
        static void Main()
        {
            Graph testGraph = new Graph();
            // 插入顶点
            testGraph.addVertex("A"); testGraph.addVertex("B");
            testGraph.addVertex("C"); testGraph.addVertex("D");
            // 插入节点
            testGraph.addNode("E"); testGraph.addNode("F");
            testGraph.addNode("G"); testGraph.addNode("H");
            testGraph.addNode("I"); testGraph.addNode("J");
            testGraph.addNode("K"); testGraph.addNode("L");
            // 插入边
            testGraph.addEdge("A", "E"); testGraph.addEdge("A", "F");
            testGraph.addEdge("B", "F"); testGraph.addEdge("C", "G");
            testGraph.addEdge("D", "H"); testGraph.addEdge("E", "K");
            testGraph.addEdge("E", "J"); testGraph.addEdge("F", "J");
            testGraph.addEdge("G", "I"); testGraph.addEdge("H", "I");
            testGraph.addEdge("J", "K"); testGraph.addEdge("G", "I");
            testGraph.addEdge("K", "L"); testGraph.addEdge("I", "L");

            FindPath fp = new FindPath();
            fp.graph = testGraph;
            List<List<Guid>> realResult = fp.getAllPathFromVertex("L");
            List<List<string>> realResultName = testGraph.IDToName(realResult);



            for (int i = 0; i < realResultName.Count; i++)
            {
                for (int j = 0; j < realResultName[i].Count; j++)
                {
                    Console.Write(realResultName[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();

        }
    }
}
