using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TileGamePuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            var tiles = new string[16];
            for (var i = 0; i < 16; i++)
            {
                if (i < 15)
                {
                    tiles[i] = (i + 1).ToString();
                }
                else
                {
                    tiles[i] = "";
                }
            }

            PrintGameGrid(tiles);
            Console.ReadLine();
        }

        public static void PrintGameGrid(string[] list )
        {
            Console.WriteLine("╔═════════════════════════════════╗");
            Console.WriteLine("║ ╔═════╗ ╔═════╗ ╔═════╗ ╔═════╗ ║");
            Console.WriteLine("║ ║ {0,2}  ║ ║ {1,2}  ║ ║ {2,2}  ║ ║ {3,2}  ║ ║", list[0], list[1], list[2], list[3]);
            Console.WriteLine("║ ╚═════╝ ╚═════╝ ╚═════╝ ╚═════╝ ║");
            Console.WriteLine("║ ╔═════╗ ╔═════╗ ╔═════╗ ╔═════╗ ║");
            Console.WriteLine("║ ║ {0,2}  ║ ║ {1,2}  ║ ║ {2,2}  ║ ║ {3,2}  ║ ║", list[4], list[5], list[6], list[7]);
            Console.WriteLine("║ ╚═════╝ ╚═════╝ ╚═════╝ ╚═════╝ ║");
            Console.WriteLine("║ ╔═════╗ ╔═════╗ ╔═════╗ ╔═════╗ ║");
            Console.WriteLine("║ ║ {0,2}  ║ ║ {1,2}  ║ ║ {2,2}  ║ ║ {3,2}  ║ ║", list[8], list[9], list[10], list[11]);
            Console.WriteLine("║ ╚═════╝ ╚═════╝ ╚═════╝ ╚═════╝ ║");
            Console.WriteLine("║ ╔═════╗ ╔═════╗ ╔═════╗ ╔═════╗ ║");
            Console.WriteLine("║ ║ {0,2}  ║ ║ {1,2}  ║ ║ {2,2}  ║ ║ {3,2}  ║ ║", list[12], list[13], list[14], list[15]);
            Console.WriteLine("║ ╚═════╝ ╚═════╝ ╚═════╝ ╚═════╝ ║");
            Console.WriteLine("╚═════════════════════════════════╝");
        }
    }
}
