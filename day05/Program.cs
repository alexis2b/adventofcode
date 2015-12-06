using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace day05
{
    class Program
    {
        private static readonly char[] Vowels = "aeiou".ToArray();
        private static readonly string[] NaughtyStrings = new[] { "ab", "cd", "pq", "xy" };

        static void Main(string[] args)
        {
            int niceWordsCount = 0;

            // Part 1
            using (var inputReader = new StreamReader("input.txt"))
            {
                while (!inputReader.EndOfStream)
                    niceWordsCount += IsNiceWord(inputReader.ReadLine()) ? 1 : 0;
            }
            Console.WriteLine("Part 1 - solution = " + niceWordsCount);

            // Part 2
            niceWordsCount = 0;
            using (var inputReader = new StreamReader("input.txt"))
            {
                while (!inputReader.EndOfStream)
                    niceWordsCount += IsNiceWord2(inputReader.ReadLine()) ? 1 : 0;
            }
            Console.WriteLine("Part 2 - solution = " + niceWordsCount);


            Console.ReadKey();
        }

        private static bool IsNiceWord(string word)
        {
            return HasAtLeastThreeVowels(word) &&
                   HasAtLeastOneLetterTwiceInARow(word) &&
                   DoesNotContainNaughtyStrings(word);
        }

        private static bool HasAtLeastThreeVowels(string word)
        {
            return word.Count(c => Vowels.Contains(c) ) >= 3;
        }

        private static bool HasAtLeastOneLetterTwiceInARow(string word)
        {
            for (var i = 0; i < word.Length - 1; i++)
                if (word[i] == word[i + 1])
                    return true;

            return false;
        }

        private static bool DoesNotContainNaughtyStrings(string word)
        {
            foreach (var naughtyString in NaughtyStrings)
                if (word.Contains(naughtyString))
                    return false;

            return true;
        }

        private static bool IsNiceWord2(string word)
        {
            return HasAtLeastAPairOfCharactersWith1CharInBetween(word) && HasAtLeastTwoLettersRepeating(word);
        }

        private static bool HasAtLeastTwoLettersRepeating(string word)
        {
            for (var i = 0; i < word.Length - 3; i++)
            {
                var pair = "" + word[i] + word[i + 1];
                if (word.Substring(i + 2).Contains(pair))
                    return true;
            }
            return false;
        }

        private static bool HasAtLeastAPairOfCharactersWith1CharInBetween(string word)
        {
            for (var i = 0; i < word.Length - 2; i++)
                if (word[i] == word[i + 2])
                    return true;

            return false;
        }
    }
}
