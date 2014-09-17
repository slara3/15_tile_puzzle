using System;

namespace TileGamePuzzle
{
    class Program
    {
        public static int Rows = 4;
        public static int Columns = 4;
        public static int ShuffleCount = 500;
        public static string[,] TileStrings = new string[Rows, Columns];
        public static Tile BlankTile = new Tile();

        static void Main()
        {
            InitializeTileValues();
            ScramblePuzzle();

            while (true)
            {
                Console.Clear();
                PrintGameGrid();
                var cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Q)
                {
                    return;
                }
                if (cki.Key == ConsoleKey.C)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                if (cki.Key == ConsoleKey.R)
                {
                    Console.ResetColor();
                }
                if (cki.Key == ConsoleKey.S)
                {
                    SolvePuzzle();
                }

                MoveTile(cki.Key);

                if (!IsAWinner()) continue;
                
                Console.Clear();
                PrintGameGrid();
                Console.WriteLine("You are a winner!");
                Console.ReadLine();
                return;
            }
        }

        private static void SolvePuzzle()
        {
            var tile1 = new Tile();

            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    if (TileStrings[i, j] != "1") continue;

                    tile1.X = i;
                    tile1.Y = j;
                }
            }
        }

        private static bool IsAWinner()
        {
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    if ((i == (Rows - 1)) && (j == (Columns - 1))) continue;
                    if (TileStrings[i, j] != ((Rows * i) + (j + 1)).ToString())
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static void ScramblePuzzle()
        {
            var rand = new Random();
            for (var i = 0; i < ShuffleCount; i++)
            {
                var key = GetRandomDirection(rand.Next());
                MoveTile(key);
            }
        }

        private static ConsoleKey GetRandomDirection(int randomValue)
        {
            var key = new ConsoleKey();
            var direction = randomValue % 4;
            switch (direction)
            {
                case 0:
                    key = ConsoleKey.LeftArrow;
                    break;
                case 1:
                    key = ConsoleKey.RightArrow;
                    break;
                case 2:
                    key = ConsoleKey.UpArrow;
                    break;
                case 3:
                    key = ConsoleKey.DownArrow;
                    break;
            }
            return key;
        }

        private static void MoveTile(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    if ((BlankTile.Y + 1) <= (Columns - 1))
                    {
                        TileStrings[BlankTile.X, BlankTile.Y] = TileStrings[BlankTile.X, BlankTile.Y + 1];
                        TileStrings[BlankTile.X, BlankTile.Y + 1] = "";
                        BlankTile.Y++;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if ((BlankTile.Y - 1) >= 0)
                    {
                        TileStrings[BlankTile.X, BlankTile.Y] = TileStrings[BlankTile.X, BlankTile.Y - 1];
                        TileStrings[BlankTile.X, BlankTile.Y - 1] = "";
                        BlankTile.Y--;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if ((BlankTile.X + 1) <= (Rows - 1))
                    {
                        TileStrings[BlankTile.X, BlankTile.Y] = TileStrings[BlankTile.X + 1, BlankTile.Y];
                        TileStrings[BlankTile.X + 1, BlankTile.Y] = "";
                        BlankTile.X++;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if ((BlankTile.X - 1) >= 0)
                    {
                        TileStrings[BlankTile.X, BlankTile.Y] = TileStrings[BlankTile.X - 1, BlankTile.Y];
                        TileStrings[BlankTile.X - 1, BlankTile.Y] = "";
                        BlankTile.X--;
                    }
                    break;
            }
        }

        private static void InitializeTileValues()
        {
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    TileStrings[i, j] = ((Rows * i) + (j + 1)).ToString();
                }
            }
            TileStrings[BlankTile.X = 3, BlankTile.Y = 3] = "";
        }

        public static void PrintGameGrid()
        {
            Console.WriteLine("Use arrow keys to move TileStrings.");
            Console.WriteLine("Enter 'Q' to quit.\n");

            Console.WriteLine("╔═════════════════════════════════╗");
            Console.WriteLine("║ ╔═════╗ ╔═════╗ ╔═════╗ ╔═════╗ ║");
            Console.WriteLine("║ ║ {0,2}  ║ ║ {1,2}  ║ ║ {2,2}  ║ ║ {3,2}  ║ ║", TileStrings[0,0], TileStrings[0,1], TileStrings[0,2], TileStrings[0,3]);
            Console.WriteLine("║ ╚═════╝ ╚═════╝ ╚═════╝ ╚═════╝ ║");
            Console.WriteLine("║ ╔═════╗ ╔═════╗ ╔═════╗ ╔═════╗ ║");
            Console.WriteLine("║ ║ {0,2}  ║ ║ {1,2}  ║ ║ {2,2}  ║ ║ {3,2}  ║ ║", TileStrings[1,0], TileStrings[1,1], TileStrings[1,2], TileStrings[1,3]);
            Console.WriteLine("║ ╚═════╝ ╚═════╝ ╚═════╝ ╚═════╝ ║");
            Console.WriteLine("║ ╔═════╗ ╔═════╗ ╔═════╗ ╔═════╗ ║");
            Console.WriteLine("║ ║ {0,2}  ║ ║ {1,2}  ║ ║ {2,2}  ║ ║ {3,2}  ║ ║", TileStrings[2,0], TileStrings[2,1], TileStrings[2,2], TileStrings[2,3]);
            Console.WriteLine("║ ╚═════╝ ╚═════╝ ╚═════╝ ╚═════╝ ║");
            Console.WriteLine("║ ╔═════╗ ╔═════╗ ╔═════╗ ╔═════╗ ║");
            Console.WriteLine("║ ║ {0,2}  ║ ║ {1,2}  ║ ║ {2,2}  ║ ║ {3,2}  ║ ║", TileStrings[3,0], TileStrings[3,1], TileStrings[3,2], TileStrings[3,3]);
            Console.WriteLine("║ ╚═════╝ ╚═════╝ ╚═════╝ ╚═════╝ ║");
            Console.WriteLine("╚═════════════════════════════════╝");
        }
    }
}
