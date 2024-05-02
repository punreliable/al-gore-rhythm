﻿using System;

namespace KrushkalsAlgorithm
{
    class Example
    {

        class Edge
        {
            public int source;
            public int Dest;
            public int Weight;

        }

        class Graph
        {
            public int NumberOfVertices;
            public int NumberOfEdges;
            public int Edge[] edges;
        }

        class Subset
        {
            public int Parent;
            public int Rank;

        }

        private static int Find(Subset[] subsets, int i)
        {

            if (subsets[i].Parent != i)
            {
                subsets[i].Parent = Find(subsets, subsets[i].Parent);
            }

            return subsets[i].Parent;
            
        }

        public static void Union(Subset[] subsets, int x, int y)
        {
            int xroot = Find(subsets, x);
            int yroot = Find(subsets, y);

            if (subsets[xroot].Rank < subsets[yroot].Rank)
            {
                subsets[xroot].Parent = yroot;
            }
            else if ( subsets[xroot].Rank > subsets[yroot].Rank)
            {
                subsets[yroot].Parent = yroot;
            }
            else
            {
                subsets[yroot].Parent = xroot;
                subsets[xroot].Rank++;
            }

        }

        public static void KrushkalsAlgorith(Graph graph)
        {
            Edge[] result = new Edge[graph.NumberOfVertices];
            int nodeIndex = 0;
            int edgeIndex = 0;

            Array.Sort(graph.edges, delegate (Edge a, Edge b ) )
            {
                return a.Weight.CompareTo(b.Weight);
            }

            Subset[] subsets = new Subset[graph.NumberOfVertices];

            for ( int i = 0; i < graph.NumberOfVertices; i++ )
            {
                subsets[i].Parent = i;
                subsets[i].Rank = 0;
            }

            while (edgeIndex < graph.NumberOfVertices - 1)
            {

                Edge nextEdge = graph.edges[nodeIndex++];
                int x = Find(subsets, nextEdge.Src);
                int y = Find(subsets, nextEdge.Dest);

                if (x != y)
                {

                    result[edgeIndex++] = nextEdge;
                    Union(subsets, x, y);
                    
                }

            }


        }

    }
    
}