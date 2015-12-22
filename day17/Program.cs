using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace day17
{
    class Program
    {
        private static int[]       _buckets;
        private static List<int[]> _permutations = new List<int[]>();

        static void Main(string[] args)
        {
            _buckets = File.ReadAllLines("input.txt").Select(int.Parse).OrderByDescending( b => b ).ToArray();

            FindPermutations(new int[]{}, 150);
            Console.WriteLine("Part 1 - Solution: " + _permutations.Count);

            var minPermutations = _permutations.Select(l => l.Length).Min();
            var numberOfMinPermutations = _permutations.Count(l => l.Length == minPermutations);

            Console.WriteLine("Part 2 - Solution: " + numberOfMinPermutations);

            Console.ReadKey();
        }

        private static void FindPermutations(int[] currentRoot, int target)
        {
            for(var i = 0; i < _buckets.Length; i++ )
            {
                if ( currentRoot.Contains( i ) )
                    continue;

                if (_buckets[i] == target)
                    PermutationFound(currentRoot.Union(new[] { i }).OrderBy(x => x).ToArray());
                if (_buckets[i] < target)
                    FindPermutations(currentRoot.Union(new[] { i }).ToArray(), target - _buckets[i]);
            }
        }

        private static void PermutationFound(int[] sortedPermutation)
        {
            foreach (var knownPermutation in _permutations)
            {
                if (knownPermutation.Length == sortedPermutation.Length)
                {
                    bool isEqual = true;
                    for (var i = 0; i < knownPermutation.Length; i++)
                    {
                        if (knownPermutation[i] != sortedPermutation[i])
                        {
                            isEqual = false;
                            break;
                        }
                    }
                    if (isEqual)
                        return;
                }
            }
            _permutations.Add(sortedPermutation);
        }
    }
}
