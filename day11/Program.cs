using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace day11
{
    class Program
    {
        static void Main(string[] args)
        {
            var nextPassword1 = GetNextSafePassword("hepxcrrq");
            var nextPassword2 = GetNextSafePassword(nextPassword1);

            Console.WriteLine("Part 1 - solution: " + nextPassword1 );
            Console.WriteLine("Part 2 - solution: " + nextPassword2 );

            Console.ReadKey();
        }

        private static string GetNextSafePassword(string current)
        {
            var password = current;
            while ( ! IsSafePassword( password = GetNextPassword( password ) ) )
                ;
            return password;
        }

        private static string GetNextPassword(string password)
        {
            var bytes = Encoding.ASCII.GetBytes(password);
            var pos   = 7;
            while (++bytes[pos--] > 'z')
                bytes[pos + 1] = (byte) 'a';

            return Encoding.ASCII.GetString(bytes);
        }

        private static bool IsSafePassword(string password)
        {
            return HasIncreasingStraightOfThreeLetters(password)
                && password.All(c => (c != 'i' && c != 'o' && c != 'l'))
                && HasTwoPairsOfLetters(password);
        }

        private static bool HasIncreasingStraightOfThreeLetters(string password)
        {
            for (var i = 0; i < password.Length - 2; i++)
                if (password[i] == password[i + 1] - 1 && password[i + 1] == password[i + 2] - 1)
                    return true;

            return false;
        }

        private static bool HasTwoPairsOfLetters(string password)
        {
            int pair = 0;
            for (var i = 0; i < password.Length - 1; i++)
            {
                if (password[i] != password[i + 1]) continue;

                pair++;
                i++;
            }
            return pair >= 2;
        }
    }
}
