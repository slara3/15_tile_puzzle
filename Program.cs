using System;

namespace TileGamePuzzle
{
    public static class BlankTile
    {
        public static int X { get; set; }
        public static int Y { get; set; }
    }

    class Program
    {
        private static void Main()
        {
            var tiles = new string[4, 4];

            InitializeTileValues(tiles);
            RandomizeTiles(tiles);

            while (true)
            {
                Console.Clear();
                PrintGameGrid(tiles);
                var cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Q)
                {
                    return;
                }

                MoveTile(cki.Key, tiles);
                if (!IsAWinner(tiles))
                {
                    continue;
                }
                else
                {
                    Console.Clear();
                    PrintGameGrid(tiles);
                    Console.WriteLine("You are a winner!");
                    Console.ReadLine();
                    return;
                }
            }
        }

        private static bool IsAWinner(string[,] tiles)
        {
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    if (i == 3 && j == 3) continue;
                    if (tiles[i, j] != ((4*i) + (j + 1)).ToString())
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static void RandomizeTiles(string[,] tiles)
        {
            var rand = new Random();
            for (var i = 0; i < 100; i++)
            {
                switch (rand.Next()%4)
                {
                    case 0:
                        MoveTile(ConsoleKey.LeftArrow, tiles);
                        break;
                    case 1:
                        MoveTile(ConsoleKey.RightArrow, tiles);
                        break;
                    case 2:
                        MoveTile(ConsoleKey.UpArrow, tiles);
                        break;
                    case 3:
                        MoveTile(ConsoleKey.DownArrow, tiles);
                        break;
                }
            }
        }

        private static void MoveTile(ConsoleKey key, string[,] tiles)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    if ((BlankTile.Y + 1) <= 3)
                    {
                        tiles[BlankTile.X, BlankTile.Y] = tiles[BlankTile.X, BlankTile.Y + 1];
                        tiles[BlankTile.X, BlankTile.Y + 1] = "";
                        BlankTile.Y++;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if ((BlankTile.Y - 1) >= 0)
                    {
                        tiles[BlankTile.X, BlankTile.Y] = tiles[BlankTile.X, BlankTile.Y - 1];
                        tiles[BlankTile.X, BlankTile.Y - 1] = "";
                        BlankTile.Y--;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if ((BlankTile.X + 1) <= 3)
                    {
                        tiles[BlankTile.X, BlankTile.Y] = tiles[BlankTile.X + 1, BlankTile.Y];
                        tiles[BlankTile.X + 1, BlankTile.Y] = "";
                        BlankTile.X++;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if ((BlankTile.X - 1) >= 0)
                    {
                        tiles[BlankTile.X, BlankTile.Y] = tiles[BlankTile.X - 1, BlankTile.Y];
                        tiles[BlankTile.X - 1, BlankTile.Y] = "";
                        BlankTile.X--;
                    }
                    break;
            }
        }

        private static void InitializeTileValues(string[,] tiles)
        {
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    tiles[i, j] = ((4*i) + (j + 1)).ToString();
                }
            }
            tiles[BlankTile.X = 3, BlankTile.Y = 3] = "";
        }

        public static void PrintGameGrid(string[,] list )
        {
            Console.WriteLine("Use arrow keys to move tiles.");
            Console.WriteLine("Enter 'Q' to quit.\n");

            Console.WriteLine("╔═════════════════════════════════╗");
            Console.WriteLine("║ ╔═════╗ ╔═════╗ ╔═════╗ ╔═════╗ ║");
            Console.WriteLine("║ ║ {0,2}  ║ ║ {1,2}  ║ ║ {2,2}  ║ ║ {3,2}  ║ ║", list[0,0], list[0,1], list[0,2], list[0,3]);
            Console.WriteLine("║ ╚═════╝ ╚═════╝ ╚═════╝ ╚═════╝ ║");
            Console.WriteLine("║ ╔═════╗ ╔═════╗ ╔═════╗ ╔═════╗ ║");
            Console.WriteLine("║ ║ {0,2}  ║ ║ {1,2}  ║ ║ {2,2}  ║ ║ {3,2}  ║ ║", list[1,0], list[1,1], list[1,2], list[1,3]);
            Console.WriteLine("║ ╚═════╝ ╚═════╝ ╚═════╝ ╚═════╝ ║");
            Console.WriteLine("║ ╔═════╗ ╔═════╗ ╔═════╗ ╔═════╗ ║");
            Console.WriteLine("║ ║ {0,2}  ║ ║ {1,2}  ║ ║ {2,2}  ║ ║ {3,2}  ║ ║", list[2,0], list[2,1], list[2,2], list[2,3]);
            Console.WriteLine("║ ╚═════╝ ╚═════╝ ╚═════╝ ╚═════╝ ║");
            Console.WriteLine("║ ╔═════╗ ╔═════╗ ╔═════╗ ╔═════╗ ║");
            Console.WriteLine("║ ║ {0,2}  ║ ║ {1,2}  ║ ║ {2,2}  ║ ║ {3,2}  ║ ║", list[3,0], list[3,1], list[3,2], list[3,3]);
            Console.WriteLine("║ ╚═════╝ ╚═════╝ ╚═════╝ ╚═════╝ ║");
            Console.WriteLine("╚═════════════════════════════════╝");
        }
    }
}
