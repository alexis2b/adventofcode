using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace day09
{
    class Program
    {
        static void Main(string[] args)
        {
            var distances = File.ReadLines("input.txt").Select(l => Distance.FromString(l));
            var map = new Map(distances);

            int shortestTrip = int.MaxValue;
            FindShortestRoute( map, string.Empty, map.Cities.ToList(), 0, ref shortestTrip );
            Console.WriteLine("Part 1 - solution: " + shortestTrip);

            int longestTrip = 0;
            FindLongestRoute(map, string.Empty, map.Cities.ToList(), 0, ref longestTrip);
            Console.WriteLine("Part 2 - solution: " + longestTrip);

            Console.ReadKey();
        }

        private static void FindShortestRoute(Map map, string currentLocation, List<string> remainingCities, int currentTrip, ref int shortestTrip)
        {
            if (remainingCities.Count == 0)
                shortestTrip = currentTrip;
            else
                foreach (var nextCity in remainingCities)
                {
                    var distanceToNext = String.IsNullOrEmpty(currentLocation) ? 0 : map.DistanceBetween(currentLocation, nextCity);
                    if (currentTrip + distanceToNext < shortestTrip)
                        FindShortestRoute(map, nextCity, remainingCities.Where(c => c != nextCity).ToList(), currentTrip + distanceToNext, ref shortestTrip);
                }
        }

        private static void FindLongestRoute(Map map, string currentLocation, List<string> remainingCities, int currentTrip, ref int longestTrip)
        {
            if (remainingCities.Count == 0 && currentTrip > longestTrip)
                longestTrip = currentTrip;
            else
                foreach (var nextCity in remainingCities)
                {
                    var distanceToNext = String.IsNullOrEmpty(currentLocation) ? 0 : map.DistanceBetween(currentLocation, nextCity);
                    FindLongestRoute(map, nextCity, remainingCities.Where(c => c != nextCity).ToList(), currentTrip + distanceToNext, ref longestTrip);
                }
        }
    }
}
