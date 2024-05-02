﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LeesAlgorithm
{

    class Example
    {
        public class Node
        {

            public int x;
            public int y;
            public int distance;
            
            public Node( int x, int y, int distance )
            {
                
                this.x = x;
                this.y = y;
                this.distance = distance;
                
            }

        }

        public static int[] row = { -1, 0, 0, 1 };
        public static int[] column = { 0, -1, 1, 0 };

        private static bool IsValid( int[][] matrix, bool[][] visited, int row, int col )
        {
            return ( row >= 0 ) && ( row < 10 ) && ( col >= 0 ) && ( col < 10 ) && matrix[row][col] == 1 && !visited[row][col];
        }
        
        private static void LeeAlgorithm( int[][] matrix, int i, int j, int x, int y )
        {
            bool[][] visited = new bool[10][];

            visited[0] = new bool[10];
            visited[1] = new bool[10];
            visited[2] = new bool[10];
            visited[3] = new bool[10];
            visited[4] = new bool[10];
            visited[5] = new bool[10];
            visited[6] = new bool[10];
            visited[7] = new bool[10];
            visited[8] = new bool[10];
            visited[9] = new bool[10];

            Queue<Node> queue = new Queue<Node>();
            visited[i][j] = true;
            queue.Enqueue( new Node( i, j, 0 ) );
            int minimumDistance = int.MaxValue;

            while ( queue.Count > 0 )
            {
                Node node = queue.Dequeue();

                i = node.x;
                j = node.y;
                int dist = node.distance;

                if ( i == x && j == y )
                {
                    minimumDistance = dist;
                    break;
                }

                for( int k = 0; k < 4; k++ ) {

                    if( IsValid( matrix, visited, i + row[k], j + column[k] ) )
                    {
                        visited[i + row[k]][j + column[k]] = true;
                        queue.Enqueue(new Node( i + row[k], j + column[k], dist + 1 ));
                    }

                }
            }

            if (minimumDistance != int.MaxValue)
            {
                Debug.WriteLine( "The shortest path from source to destination has length: " + minimumDistance );
            }
            else
            {
                Debug.WriteLine( "Destination can't be reached from the given source" );
            }
        }

        public static void Main( String[] args )
        {
            
            int[][] mat = new int[10][];

            mat[0] = new int[10] { 1, 1, 1, 1, 1, 0, 0, 1, 1, 1 };
            mat[1] = new int[10] { 0, 1, 1, 1, 1, 1, 0, 1, 0, 1 };
            mat[2] = new int[10] { 0, 0, 1, 0, 1, 1, 1, 0, 0, 1 };
            
            mat[3] = new int[10] { 1, 1, 1, 1, 1, 0, 0, 1, 1, 1 };
            mat[4] = new int[10] { 1, 1, 1, 1, 1, 0, 0, 1, 1, 1 };
            mat[5] = new int[10] { 1, 1, 1, 1, 1, 0, 0, 1, 1, 1 };
            mat[6] = new int[10] { 1, 1, 1, 1, 1, 0, 0, 1, 1, 1 };
            mat[7] = new int[10] { 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 };
            mat[8] = new int[10] { 1, 1, 1, 1, 1, 0, 0, 1, 1, 1 };
            mat[9] = new int[10] { 0, 0, 1, 0, 0, 1, 1, 0, 0, 1 };

            LeeAlgorithm(mat, 0, 0, 6, 4 );
        }
    }
}
