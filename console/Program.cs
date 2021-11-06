using System;
using bib;

namespace console
{
    class Program
    {
        private const string V = "*";
        private const string V1 = "*";

        static void Main(string[] args)
        {
            Game g = new Game(Level.Beginner);
            DisplayGrid(g.Grid);
            Console.ReadKey();
        }

        private static void DisplayGrid(int[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    //grid[i, j] = 0;
                   
                    Console.Write($"{grid[i, j],3}");
                }
                Console.WriteLine(" ");
            }
        }
    }
}
