using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;

namespace day16
{
    class Program
    {
        private static readonly Regex AuntSueEx = new Regex(@"Sue (\d+):( (\w+): (\d+),?)+", RegexOptions.Compiled);
        private static readonly Dictionary<string,int> _fingerprint = new Dictionary<string,int> {
                { "children",    3 },
                { "cats",        7 },
                { "samoyeds",    2 },
                { "pomeranians", 3 },
                { "akitas",      0 },
                { "vizslas",     0 },
                { "goldfish",    5 },
                { "trees",       3 },
                { "cars",        2 },
                { "perfumes",    1 } };

        static void Main(string[] args)
        {
            var auntSues = File.ReadAllLines("input.txt").Select(ParseAuntSue).ToArray();
            foreach (var auntSue in auntSues)
                if (Matches(auntSue.Item2, _fingerprint))
                    Console.WriteLine("Part 1 - Aunt Sue #{0} matches the fingerprint", auntSue.Item1);

            // Part 2
            foreach (var auntSue in auntSues)
                if (MatchesPart2(auntSue.Item2, _fingerprint))
                    Console.WriteLine("Part 2 - Aunt Sue #{0} matches the fingerprint", auntSue.Item1);

            Console.ReadKey();
        }

        private static Tuple<int, Dictionary<string, int>> ParseAuntSue(string auntSueStr)
        {
            var match = AuntSueEx.Match(auntSueStr);
            Debug.Assert(match.Success);

            var auntSueId = int.Parse( match.Groups[1].Value );
            var auntSueProps = new Dictionary<string,int>();
            var propCount = match.Groups[2].Captures.Count;
            for (var i = 0; i < propCount; i++)
            {
                var propName = match.Groups[3].Captures[i].Value;
                var propValue = int.Parse(match.Groups[4].Captures[i].Value);
                auntSueProps[propName] = propValue;
            }

            return Tuple.Create( auntSueId, auntSueProps );
        }

        private static bool Matches(Dictionary<string, int> props, Dictionary<string, int> fingerprint)
        {
            return props.All(kvp => fingerprint[kvp.Key] == kvp.Value);
        }

        private static bool MatchesPart2(Dictionary<string, int> props, Dictionary<string, int> fingerprint)
        {
            return props.All(kvp => {
                switch(kvp.Key)
                {
                    case "cats":
                    case "trees":
                        return fingerprint[kvp.Key] < kvp.Value;

                    case "pomeranians":
                    case "goldfish":
                        return fingerprint[kvp.Key] > kvp.Value;

                    default:
                        return fingerprint[kvp.Key] == kvp.Value;
                }
            } );
        }
    }
}
