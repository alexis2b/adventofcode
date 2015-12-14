using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace day14
{
    class Program
    {
        static void Main(string[] args)
        {
            var reindeers = File.ReadAllLines("input.txt").Select(Reindeer.FromString).ToArray();
            Console.WriteLine("Part 1 - Solution: " + reindeers.Select(r => r.GetDistanceAfter(2503)).Max());

            // Part 2
            var points = new Dictionary<string, int>(reindeers.Length);
            reindeers.ToList().ForEach(r => points[r.Name] = 0);

            for (var t = 1; t <= 2503; t++)
            {
                var maxDistance = reindeers.Select(r => r.GetDistanceAfter(t)).Max();
                reindeers.Where(r => r.GetDistanceAfter(t) == maxDistance).ToList().ForEach(r => points[r.Name]++);
            }
            Console.WriteLine("Part 2 - Solution: " + points.Values.Max());

            Console.ReadKey();
        }
    }
}
