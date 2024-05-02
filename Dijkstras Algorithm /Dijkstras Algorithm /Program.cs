using System;

namespace DijkstrasAlgorithm
{
    class Example
    {
        private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            
            int min = int.MaxValue;
            int minIndex = 0;

            for( int i = 0; i < verticesCount; i++ )
            {
                if( !shortestPathTreeSet[i] && distance[i] <= min )
                {
                    minIndex = i;
                    min = distance[i];
                }

            }
            
            return minIndex;
            
        }

        public static void DijkstraAlgorithm(int[,] graph, int source, int verticesCount)
        {

            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for( int i = 0; i < verticesCount; i++ )
            {

                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;

            }

            distance[source] = 0;

            for( int count = 0; count < verticesCount; count++ )
            {

                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;

                for( int v = 0; v < verticesCount; v++ ) {

                    if ( 
                        !shortestPathTreeSet[v] && 
                         Convert.ToBoolean(graph[u,v]) &&
                         distance[u] != int.MaxValue && 
                         distance[u] + graph[u,v] < distance[v]
                        )
                    {

                        distance[v] = distance[u] + graph[u, v];

                    }

                }

            }

        }

        public static string Main()
        {
            int[, ] graph = new int[, ] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
            var source = 3;
            var verticesCount = 6;

            return "Hello World!";

        }

    }

}

// See https://aka.ms/new-console-template for more information

