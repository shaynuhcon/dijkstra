namespace Dijkstra.Models
{
    /*
     * Object to hold vertex properties
     */
    public class Vertex
    {
        public int Number { get; set; }

        // Calculated distance from source
        public int Distance { get; set; }

        // If a shortest distance from source was found
        public bool ShortestDistanceFound { get; set; }

        // The previous vertex that "labeled" this vertex
        public Vertex Parent { get; set; }
    }
}