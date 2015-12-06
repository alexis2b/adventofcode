using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace day06
{
    class Program
    {
        private static readonly Regex commandEx = new Regex( @"(.*) (\d+),(\d+) through (\d+),(\d+)" );
        private static readonly int[] Lights = new int[1000 * 1000];
        private static readonly int[] Lights2 = new int[1000 * 1000];

        static void Main(string[] args)
        {
            // Part 1
            using (var inputReader = new StreamReader("input.txt"))
            {
                while (!inputReader.EndOfStream)
                    ExecuteStringCommand(inputReader.ReadLine());

                Console.WriteLine("Part 1 - solution = " + Lights.Sum());
            }

            // Part 2
            using (var inputReader = new StreamReader("input.txt"))
            {
                while (!inputReader.EndOfStream)
                    ExecuteStringCommand2(inputReader.ReadLine());

                Console.WriteLine("Part 2 - solution = " + Lights2.Sum());
            }



            Console.ReadKey();
        }

        private static void ExecuteStringCommand(string commandString)
        {
            var command = commandEx.Match( commandString );
            if ( ! command.Success )
                return;

            Func<int,int> commanFunction;
            switch ( command.Groups[1].Value )
            {
                case "turn on": commanFunction = TurnOn; break;
                case "turn off": commanFunction = TurnOff; break;
                case "toggle": commanFunction = Toggle; break;
                default:
                    return;
            }
            var x1 = int.Parse( command.Groups[2].Value );
            var y1 = int.Parse( command.Groups[3].Value );
            var x2 = int.Parse( command.Groups[4].Value );
            var y2 = int.Parse( command.Groups[5].Value );

            for (var y = y1; y <= y2; y++)
                for (var x = x1; x <= x2; x++)
                    Lights[y * 1000 + x] = commanFunction(Lights[y * 1000 + x]); 
        }

        private static int TurnOn(int current)
        {
            return 1;
        }

        private static int TurnOff(int current)
        {
            return 0;
        }

        private static int Toggle(int current)
        {
            return 1 - current;
        }

        private static void ExecuteStringCommand2(string commandString)
        {
            var command = commandEx.Match(commandString);
            if (!command.Success)
                return;

            Func<int, int> commanFunction;
            switch (command.Groups[1].Value)
            {
                case "turn on": commanFunction = TurnOn2; break;
                case "turn off": commanFunction = TurnOff2; break;
                case "toggle": commanFunction = Toggle2; break;
                default:
                    return;
            }
            var x1 = int.Parse(command.Groups[2].Value);
            var y1 = int.Parse(command.Groups[3].Value);
            var x2 = int.Parse(command.Groups[4].Value);
            var y2 = int.Parse(command.Groups[5].Value);

            for (var y = y1; y <= y2; y++)
                for (var x = x1; x <= x2; x++)
                    Lights2[y * 1000 + x] = commanFunction(Lights2[y * 1000 + x]);
        }

        private static int TurnOn2(int current)
        {
            return current + 1;
        }

        private static int TurnOff2(int current)
        {
            return Math.Max( current - 1, 0 );
        }

        private static int Toggle2(int current)
        {
            return current + 2;
        }
    }
}
