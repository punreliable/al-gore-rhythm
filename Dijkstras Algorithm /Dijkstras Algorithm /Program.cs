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
            
        }
        
        return minIndex;

    }
    
}

// See https://aka.ms/new-console-template for more information

