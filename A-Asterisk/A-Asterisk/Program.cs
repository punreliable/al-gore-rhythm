using System;
using System.Collections.Generic;
using System.Linq;

namespace AAsterisk
{
    class Example
    {
        class Location
        {
            public int x;
            public int y;
            public int Score1;
            public int Score2;
            public int Score3;
            public Location Parent;
            

        }

        static void Main(string[] args)
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

            foreach( var line in map )
            {
                Console.WriteLine(line);
            }

            Location current = null;
            Location start = new Location { x = 1, y = 1 };
            Location target = new Location { x = 16, y = 6 };
            List<Location> openList = new List<Location>();
            List<Location> closedList = new List<Location>();
        }

    }
        
}

