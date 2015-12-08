using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace day08
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var inputReader = new StreamReader("input.txt"))
            {
                int diffSize1 = 0;
                int diffSize2 = 0;

                while (!inputReader.EndOfStream)
                {
                    var escapedText = inputReader.ReadLine().Trim();
                    var escapedTextLength = escapedText.Length;
                    var memoryTextWithQuotes = Regex.Unescape( escapedText );
                    var memoryTextLength = memoryTextWithQuotes.Length - 2;
                    var reEscapedTextWithoutQuotes = Regex.Escape(escapedText);
                    var nonEscapedQuotesCount = reEscapedTextWithoutQuotes.Count(c => c == '"'); // quotes are not re-escaped, so " should be seen as \" (2 characters)
                    var reEscapedTextLength = reEscapedTextWithoutQuotes.Length + nonEscapedQuotesCount + 2;

                    diffSize1 += (escapedTextLength - memoryTextLength);
                    diffSize2 += (reEscapedTextLength - escapedTextLength);

                    Debug.WriteLine("{0} <- {1} -> {2} ({3} vs {4} vs {5})", reEscapedTextWithoutQuotes, escapedText, memoryTextWithQuotes, reEscapedTextLength, escapedText.Length, escapedTextLength);
                }

                Console.WriteLine("Part 1 - Solution: " + diffSize1);
                Console.WriteLine("Part 2 - Solution: " + diffSize2);
            }

            Console.ReadKey();
        }
    }
}
