using System;
using System.Collections.Generic;
using System.Linq;

namespace AStarAlgorithm
{
    class Example
    {
        class Location
        {
            public int X;
            public int Y;
            public int Score1;
            public int Score2;
            public int Score3;
            public Location Parent;


        }

        static void Main( string[] args )
        {
            string[] map = new string[]
            {
                "+----------------+",
                "|A               |",
                "|XXXXXX          |",
                "|            XXXX|",
                "|                |",
                "|XXXXXX     XXXXX|",
                "|               B|",
                "+----------------+"
            };

            Console.ForegroundColor = ConsoleColor.DarkCyan;

            foreach (var line in map)
            {
                Console.WriteLine(line);
            }

            Location current = null;
            Location start = new Location { X = 1, Y = 1 };
            Location target = new Location { X = 16, Y = 6 };
            List<Location> openList = new List<Location>();
            List<Location> closedList = new List<Location>();
            int spot = 0;
            
            openList.Add(start);

            while ( openList.Count > 0 )
            {
                int min = openList.Min(l => l.Score1);
                current = openList.First(l => l.Score1 == min );
                closedList.Add(current);
                Console.SetCursorPosition(current.X,current.Y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write('.');
                Console.SetCursorPosition(current.X,current.Y);
                
                System.Threading.Thread.Sleep(1000);
                
                openList.Remove(current);
                if ( closedList.FirstOrDefault( l => l.X == target.X &&
                                                l.Y == target.Y) != null )
                {
                    break;
                }

                List<Location> adjacentSquares = GetMovableAdjacentSpots(current.X, current.Y, map);
                
                spot++;

                foreach ( Location adjacentSquare in adjacentSquares )
                {
                    if ( closedList.FirstOrDefault( l => l.X == adjacentSquare.X &&
                                                         l.Y == adjacentSquare.Y) != null )
                    {
                        continue;
                    }
                    
                    if ( openList.FirstOrDefault( l =>
                            l.X == adjacentSquare.X && 
                            l.Y == adjacentSquare.Y ) == null ) 
                    {
                        adjacentSquare.Score2 = spot;
                        adjacentSquare.Score3 = ComputeSpotHeuristic( adjacentSquare.X, adjacentSquare.Y, target.X, target.Y );
                        adjacentSquare.Score1 = adjacentSquare.Score2 + adjacentSquare.Score3;
                        adjacentSquare.Parent = current;
                        openList.Insert(0, adjacentSquare);
                        
                    } else {
                        if ( spot + adjacentSquare.Score3 < adjacentSquare.Score1 ) {
                            adjacentSquare.Score2 = spot;
                            adjacentSquare.Score1 = adjacentSquare.Score2 + adjacentSquare.Score3;
                            adjacentSquare.Parent = current;
                        }
                    }
                }

                while ( current != null )
                {
                    Console.SetCursorPosition(current.X, current.Y);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write('o');
                    Console.SetCursorPosition(current.X, current.Y);
                    current = current.Parent;
                    
                    System.Threading.Thread.Sleep(1000);
                    
                }

                Console.ReadLine();
                
                static List<Location> GetMovableAdjacentSpots( int x, int y, string[] map )
                {
                    List<Location> proposedLocations = new List<Location>()
                    {
                        new Location { X = x, Y = y - 1 },
                        new Location { X = x, Y = y + 1 },
                        new Location { X = x - 1, Y = y },
                        new Location { X = x + 1, Y = y }
                    };

                    return proposedLocations.Where( l => map[l.Y][l.X] == ' ' || 
                                                                map[l.Y][l.X] == 'B' ).ToList();
                }

                static int ComputeSpotHeuristic( int x, int y, int targetX, int targetY )
                {
                    return Math.Abs(targetX - x) + Math.Abs(targetY - y);
                }
            }
        }

    }

}