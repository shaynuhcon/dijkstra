using System;
using System.Collections.Generic;
using System.Linq;
using Dijkstra.Models;

namespace Dijkstra
{
    public class DijkstraAlgorithm
    {
        public void Run(int[,] graph, int start, int end, int numberOfVertices)
        {
            // Initialize vertices and edges
            GetVertices(start, numberOfVertices);
            GetEdges(graph, numberOfVertices);

            // Initialize list of vertices whose shortest distance has not been found (also known as T in textbook algorithm)
            _unfound = _vertices.Where(x => x.ShortestDistanceFound == false).ToList();

            // Source vertex which will change throughout execution
            var source = _vertices.First(x => x.Number == start);

            // End vertex (also known as z in textbook algorithm) 
            var endVertex = _vertices.First(x => x.Number == end);

            // Execute while end vertex is still in unfound vertices 
            while (_unfound.Contains(endVertex))
            {
                // Find all vertices adjacent to current vertex 
                var vertices = _edges.Where(x => x.VertexOne.Number == source.Number).Select(x => x.VertexTwo).ToList();
                var adjacentVertices = _vertices.Where(x => vertices.Any(y => y.Number == x.Number) && x.ShortestDistanceFound == false).ToList();

                // Get minimum L(v)
                var minimum = GetMinimum(source, adjacentVertices);
                _unfound.Remove(minimum);

                // Change to minimum vertex
                source = minimum;
            }

            PrintResults(endVertex);
        }

        ////////////////////// Private methods used in execution of above public method //////////////////////

        private Vertex GetMinimum(Vertex current, List<Vertex> adjacentVertices)
        {
            // Find distances for all adjacent vertices
            foreach (var secondVertex in adjacentVertices)
            {
                // Get edge weight 
                var weight = _edges.First(x => x.VertexOne.Number == current.Number && x.VertexTwo.Number == secondVertex.Number).Weight;

                // Get length 
                var length = Math.Min(secondVertex.Distance, current.Distance + weight);

                // Distance has been updated so change parent vertex
                if (length != secondVertex.Distance) secondVertex.Parent = current;

                // Assign length to distance of vertex
                secondVertex.Distance = length;
            }

            // Pick minimum of updated distances and set shortest distance found to true for that vertex
            var minimum = _vertices.Where(x => x.ShortestDistanceFound == false && x.Distance != int.MaxValue).OrderBy(x => x.Distance).First();
            minimum.ShortestDistanceFound = true;

            return minimum;
        }

        private void PrintResults(Vertex endVertex)
        {
            Console.WriteLine("Length of shortest path: " + endVertex.Distance);

            var path = new List<int>();

            var hasParent = true;
            while (hasParent)
            {
                if (endVertex.Parent != null)
                {
                    path.Add(endVertex.Number);
                    endVertex = endVertex.Parent;
                }
                else
                {
                    path.Add(endVertex.Number);
                    hasParent = false;
                }
            }

            path.Reverse();

            Console.Write("Shortest path is: ");
            foreach (var vertex in path)
            {
                Console.Write(vertex + " ");
            }

            Console.WriteLine();
        }

        private void GetVertices(int start, int numberOfVertices)
        {
            // Initialize vertices and assign to global _vertices variable
            // Set all vertices except for start to max value (infinity) and shortest distance found to true
            for (int i = 0; i < numberOfVertices; ++i)
            {
                if (i == start)
                {
                    _vertices.Add(new Vertex
                    {
                        Number = i,
                        Distance = 0,
                        ShortestDistanceFound = true
                    });
                }
                else
                {
                    _vertices.Add(new Vertex
                    {
                        Number = i,
                        Distance = int.MaxValue,
                        ShortestDistanceFound = false
                    });
                }
            }
        }

        private void GetEdges(int[,] graph, int numberOfVertices)
        {
            // Initialize edges and assign to global _edges variable
            // Assigns matrix weight values to Edge object
            for (int i = 0; i < numberOfVertices; i++)
            {
                for (int j = 0; j < numberOfVertices; j++)
                {
                    // If an edge weight exists
                    if (graph[i, j] != 0)
                    {
                        // Add edge using vertex and weight values
                        _edges.Add(new Edge
                        {
                            VertexOne = new Vertex
                            {
                                Number = i
                            },
                            VertexTwo = new Vertex
                            {
                                Number = j
                            },
                            Weight = graph[i, j]
                        });
                    }
                }
            }
        }

        ////////////////////// Global variables //////////////////////

        private readonly List<Vertex> _vertices = new List<Vertex>();

        private readonly List<Edge> _edges = new List<Edge>();

        private List<Vertex> _unfound = new List<Vertex>();
    }
}