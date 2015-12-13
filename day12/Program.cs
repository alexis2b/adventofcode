using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;


namespace day12
{
    class Program
    {
        static void Main(string[] args)
        {
            var input   = File.ReadAllText("input.txt");
            var result1 = SumAllNumberProperties(input);
            Console.WriteLine( "Part 1 - Solution: " + result1 );

            var input2 = CleanRedObjects(input);
            var result2 = SumAllNumberProperties(input2);
            Console.WriteLine("Part 2 - Solution: " + result2 );

            Console.ReadKey();
        }

        private static int SumAllNumberProperties(string input)
        {
            var sum = 0;
            var matches = Regex.Matches(input, @"(-?\d+)");
            foreach (Match match in matches)
                sum += int.Parse(match.Value);
            return sum;
        }

        private static string CleanRedObjects(string input)
        {
            var pos = 0;
            while ((pos = input.IndexOf("red")) >= 0)
            {
                var prefix = input.Substring(0, pos);
                var suffix = input.Substring(pos + 3);

                if (IsInArray(prefix))
                    input = prefix + "RED" + suffix;
                else
                    input = RemoveObjectFromEnd(prefix) + RemoveObjectFromBeginning(suffix);
            }
            return input;
        }

        private static bool IsInArray(string prefix)
        {
            var blocks = Regex.Replace( prefix, @"[^{}\[\]]", String.Empty );
            var parentBlocks = blocks;

            while (( blocks = parentBlocks.Replace("{}", String.Empty).Replace("[]", String.Empty) ) != parentBlocks)
                parentBlocks = blocks;

            return blocks[blocks.Length - 1] == '[';
        }

        private static string RemoveObjectFromEnd(string input)
        {
            var objectDepth = 0;
            var arrayDepth = 0;

            for (var i = input.Length - 1; i > 0; i--)
            {
                switch (input[i])
                {
                    case '{':
                        if (arrayDepth == 0 && objectDepth == 0)
                            return input.Substring(0, i);
                        else
                            objectDepth--;
                        break;

                    case '}': objectDepth++; break;
                    case '[': arrayDepth--; break;
                    case ']': arrayDepth++; break;
                }
            }

            return input;
        }

        private static string RemoveObjectFromBeginning(string input)
        {
            var objectDepth = 0;
            var arrayDepth = 0;

            for (var i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '}':
                        if (arrayDepth == 0 && objectDepth == 0)
                            return input.Substring(i+1);
                        else
                            objectDepth--;
                        break;

                    case '{': objectDepth++; break;
                    case ']': arrayDepth--; break;
                    case '[': arrayDepth++; break;
                }
            }

            return input;
        }
    }
}
