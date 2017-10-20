using System;


namespace PathTraversal
{
    // 有向图的一条边的起点ID和终点ID
    public class Edge 
    {
        public Guid source { get; set; }
        public Guid target { get; set; }

        public Edge(Guid source, Guid target) 
        {
            this.source = source;
            this.target = target;
        }
    }
}
