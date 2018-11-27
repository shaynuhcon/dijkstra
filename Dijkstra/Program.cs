using System;

namespace Dijkstra
{
    class Program
    {
        public static void Main(string[] args)
        {
            /*
             * INSTRUCTIONS FOR USE:
             * Provide adjacency matrix as shown in example below for the int[,] graph variable.
             * Vertices will be in numerical format e.g. 0, 1, 2, 3 through n.
             *
             * Please also update the following variables: 
             * sourceVertex - int value for the desired starting vertex
             * endVertex - int value for the desired ending vertex
             * numberOfVertices - int value for the number of vertices in the graph
             *
             * Those variables will be passed to the dijkstra.Run() method and
             * the result will be printed to console.
             *
             * Logic was tested using problems 2b and 2c from homework five. 
             */

            var dijkstra = new DijkstraAlgorithm();

            // Adjacency matrix here
            int[,] graph =
            {
                {0,4,3,0,0,0,0,0},
                {4,0,2,5,0,0,0,0},
                {3,2,0,3,6,0,0,0},
                {0,5,3,0,1,5,0,0},
                {0,0,6,1,0,0,5,0},
                {0,0,0,5,0,0,2,7},
                {0,0,0,0,5,2,0,4},
                {0,0,0,0,0,7,4,0}
            };

            // Other variables here 
            int sourceVertex = 7;
            int endVertex = 2;
            int numberOfVertices = 8;

            dijkstra.Run(graph, sourceVertex, endVertex, numberOfVertices);

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}

