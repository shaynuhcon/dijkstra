/*
 * Name: Shayna Conner
 * Class/Assignment: MTH354 Final Project
 * Algorithm: Dijkstra's algorithm
 * Date: 11/27/2018
 */

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