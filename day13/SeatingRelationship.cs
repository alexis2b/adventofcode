using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace day13
{
    internal sealed class SeatingRelationship
    {
        private static readonly Regex SeatingRelationshipEx = new Regex(@"(?<person1>\w+) would (?<gainOrLose>gain|lose) (?<units>\d+) happiness units by sitting next to (?<person2>\w+)\.", RegexOptions.Compiled);
        private readonly string _person1;
        private readonly string _person2;
        private readonly int    _happinessChange;

        public SeatingRelationship(string person1, string person2, int happinessChange)
        {
            _person1         = person1;
            _person2         = person2;
            _happinessChange = happinessChange;
        }

        public string Person1         { get { return _person1;         } }
        public string Person2         { get { return _person2;         } }
        public int    HappinessChange { get { return _happinessChange; } }

        public static SeatingRelationship FromString(string seatingRelationshipString)
        {
            var match = SeatingRelationshipEx.Match( seatingRelationshipString );
            Debug.Assert(match.Success);

            return new SeatingRelationship(
                match.Groups["person1"].Value,
                match.Groups["person2"].Value,
                ( match.Groups["gainOrLose"].Value == "gain" ? 1 : -1 ) * int.Parse( match.Groups["units"].Value ) );

        }

        public bool Match(string aPerson, string anotherPerson)
        {
            return (aPerson == _person1 || aPerson == _person2) && (anotherPerson == _person2 || anotherPerson == _person1);
        }
    }
}
