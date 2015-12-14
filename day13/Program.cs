using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace day13
{
    class Program
    {
        static void Main(string[] args)
        {
            var seatingRelationships = File.ReadAllLines("input.txt").Select(SeatingRelationship.FromString).ToArray();
            var guests               = seatingRelationships.SelectMany( c => new[] {c.Person1, c.Person2} ).Distinct().ToArray();

            int maxHappinessChange = int.MinValue;
            FindMaxHappinessChange(seatingRelationships, null, null, guests, 0, ref maxHappinessChange);
            Console.WriteLine("Part 1 - Solution: " + maxHappinessChange);

            // Part 2 - add myself
            const string me = "Alexis";
            var newSeatingRelationships = seatingRelationships.Union(guests.SelectMany(g => new[] { 
                new SeatingRelationship( me, g, 0 ),
                new SeatingRelationship( g, me, 0 ) })).ToArray();
            var newGuests = guests.Union(new[] { me }).ToArray();
            int maxHappinessChange2 = int.MinValue;
            FindMaxHappinessChange(newSeatingRelationships, null, null, newGuests, 0, ref maxHappinessChange2);
            Console.WriteLine("Part 2 - Solution: " + maxHappinessChange2);

            Console.ReadKey();
        }

        private static void FindMaxHappinessChange(SeatingRelationship[] seatingRelationships, string firstGuest, string currentGuest, string[] remainingGuests, int currentHappinessChange, ref int maxHappinessChange)
        {
            if ( remainingGuests.Length == 0 )
            {
                currentHappinessChange += HappinessChange(seatingRelationships, currentGuest, firstGuest);
                if (currentHappinessChange > maxHappinessChange)
                    maxHappinessChange = currentHappinessChange;
            }
            else
                foreach (var nextGuest in remainingGuests)
                {
                    var happinessChange = String.IsNullOrEmpty(currentGuest) ? 0 : HappinessChange(seatingRelationships, currentGuest, nextGuest);
                    FindMaxHappinessChange(seatingRelationships, firstGuest ?? nextGuest, nextGuest, remainingGuests.Where(g => g != nextGuest).ToArray(), currentHappinessChange + happinessChange, ref maxHappinessChange);
                }
        }

        private static int HappinessChange(SeatingRelationship[] seatingRelationships, string person1, string person2)
        {
            return seatingRelationships.Sum(p => p.Match(person1, person2) ? p.HappinessChange : 0);
        }
    }
}
