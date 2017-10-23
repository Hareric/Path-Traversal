using System;


namespace PathTraversal
{
    // 有向图的一条边的起点ID和终点ID
    public class Edge 
    {
        public Guid Source { get; set; }
        public Guid Target { get; set; }

        public Edge(Guid source, Guid target) 
        {
            this.Source = source;
            this.Target = target;
        }
    }
}
