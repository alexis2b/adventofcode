using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;


namespace day14
{
    internal sealed class Reindeer
    {
        private static readonly Regex ReindeerEx = new Regex(@"(?<name>\w+) can fly (?<speed>\d+) km/s for (?<flying>\d+) seconds, but then must rest for (?<resting>\d+) seconds\.", RegexOptions.Compiled);

        private readonly string _name;
        private readonly int    _speed;
        private readonly int    _flyingTime;
        private readonly int    _restingTime;

        private Reindeer(string name, int speed, int flyingTime, int restingTime)
        {
            _name        = name;
            _speed       = speed;
            _flyingTime  = flyingTime;
            _restingTime = restingTime;
        }

        public static Reindeer FromString(string reindeerString)
        {
            var match = ReindeerEx.Match(reindeerString);
            Debug.Assert(match.Success);

            return new Reindeer(match.Groups["name"].Value, int.Parse(match.Groups["speed"].Value), int.Parse(match.Groups["flying"].Value), int.Parse(match.Groups["resting"].Value));
        }

        public string Name { get { return _name; } }

        public int GetDistanceAfter(int seconds)
        {
           return
                (seconds / (_flyingTime + _restingTime)) * _flyingTime * _speed  // full segments
                + Math.Min(seconds % (_flyingTime + _restingTime), _flyingTime) * _speed; // last segment remainder
        }
    }
}
