using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace day10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part 1 - Solution: " + LookAndSay("3113322113", 40) );
            Console.WriteLine("Part 2 - Solution: " + LookAndSay("3113322113", 50) );
            Console.ReadKey();
        }

        private static int LookAndSay(string input, int iterationCount)
        {
            var iterationInput = input;
            for (var iter = 0; iter < iterationCount; iter++)
            {
                var context = new LookAndSayBuilder();
                iterationInput.ToList().ForEach(c => context.AddCharacter(c));
                // feeds back to next iteration
                iterationInput = context.GetResult();
            }

            return iterationInput.Length;
        }
    }


    internal sealed class LookAndSayBuilder
    {
        private char _current;
        private int _count;
        private StringBuilder _result;

        public LookAndSayBuilder()
        {
            _current = '\0';
            _count   = 0;
            _result = new StringBuilder();
        }

        public void AddCharacter(char c)
        {
            if (c != _current)
                AppendToResult();
            _current = c;
            _count++;
        }

        public string GetResult()
        {
            AppendToResult();
            return _result.ToString();
        }

        private void AppendToResult()
        {
            if (_count == 0) return;

            _result.Append(_count).Append(_current);
            _count = 0;
        }
    }
}
