using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace day18
{
    class Program
    {
        private const char LightOn  = '#';
        private const char LightOff = '.';

        static void Main(string[] args)
        {
            var inputGrid = File.ReadAllLines("input.txt").ToArray();
            var h = inputGrid.Length;
            var w = inputGrid[0].Length;

            // create an array of integer (0,1) to represent the grid, with a border of 0 to avoid the boundaries problem
            var initialGrid = BuildInitialGrid(inputGrid, h, w);

            // Part 1
            var grid = initialGrid;
            var litCount = 0;
            for (var i = 0; i < 100; i++)
                grid = Evolve(grid, w, h, out litCount);
            Console.WriteLine("Part 1 - solution: " + litCount);

            // Part 2 - the four corners are always on
            grid = initialGrid;
            litCount = 0;
            for (var i = 0; i < 100; i++)
            {
                grid[1,1] = grid[w,1] = grid[w,h] = grid[1,h] = 1;
                grid = Evolve(grid, w, h, out litCount);
            }
            // fix the count for corners
            litCount += 4 - grid[1,1] - grid[w,1] - grid[w,h] - grid[1,h] ;

            Console.WriteLine("Part 2 - solution: " + litCount);

            Console.ReadKey();
        }

        private static int[,] BuildInitialGrid(string[] inputGrid, int h, int w)
        {
            var grid = new int[w + 2, h + 2];
            for (var r = 0; r < h; r++)
                for (var c = 0; c < w; c++)
                    if (inputGrid[r][c] == LightOn)
                        grid[c + 1, r + 1] = 1;
            return grid;
        }

        private static int[,] Evolve(int[,] grid, int h, int w, out int litCount)
        {
            var newGrid = new int[w + 2, h + 2];

            litCount = 0;
            for (var r = 1; r <= h; r++)
                for (var c = 1; c <= w; c++)
                {
                    var litNeighbours = grid[c - 1, r - 1] + grid[c, r - 1] + grid[c + 1, r - 1] + grid[c - 1, r] + grid[c + 1, r] + grid[c - 1, r + 1] + grid[c, r + 1] + grid[c + 1, r + 1];
                    litCount += newGrid[c,r] = ( litNeighbours == 3 ) || ( litNeighbours == 2 && grid[c,r] == 1) ? 1 : 0;
                }
            return newGrid;
        }
    }
}
