using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace day09
{
    internal sealed class Distance
    {
        private static readonly Regex DistanceEx = new Regex(@"(?<from>\w+) to (?<to>\w+) = (?<distance>\d+)");

        private readonly string _from;
        private readonly string _to;
        private readonly int _distance;

        private Distance(string from, string to, int distance)
        {
            _from = from;
            _to = to;
            _distance = distance;
        }

        public string From { get { return _from; } }
        public string To { get { return _to; } }
        public int Value { get { return _distance; } }

        public static Distance FromString(string distanceString)
        {
            var distanceMatch = DistanceEx.Match(distanceString);
            Debug.Assert(distanceMatch.Success);
            return new Distance( distanceMatch.Groups["from"].Value, distanceMatch.Groups["to"].Value, int.Parse( distanceMatch.Groups["distance"].Value) );
        }
    }
}
