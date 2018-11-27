namespace Dijkstra.Models
{
    /*
     * Model to hold edge weight and the
     * vertices that the edge is incident on
     */
    public class Edge
    {
        public Vertex VertexOne { get; set; }

        public Vertex VertexTwo { get; set; }

        public int Weight { get; set; }
    }
}