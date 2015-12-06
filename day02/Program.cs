using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace day02
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalSurface = 0;
            int totalRibbon  = 0;

            using (var inputReader = new StreamReader("input.txt"))
            {
                while (!inputReader.EndOfStream)
                {
                    var boxDimensions = inputReader.ReadLine().Split('x').Select(c => int.Parse(c)).ToArray();
                    var l = boxDimensions[0];
                    var w = boxDimensions[1];
                    var h = boxDimensions[2];
                    
                    // Part 1
                    var boxSurface = 2 * l * w + 2 * w * h + 2 * h * l;
                    var spareSurface = new[] { l * w, l * h, w * h }.Min();
                    totalSurface += boxSurface + spareSurface;

                    // Part 2
                    var ribbonLength = new[] { 2 * l + 2 * w, 2 * l + 2 * h, 2 * w + 2 * h }.Min();
                    var knotLength = l * w * h;
                    totalRibbon += ribbonLength + knotLength;
                }
                Console.WriteLine("Part 1 -> resulting surface = " + totalSurface);
                Console.WriteLine("Part 2 -> resulting length  = " + totalRibbon);
            }

            Console.ReadKey();
        }
    }
}
