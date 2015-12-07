using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace day07
{
    class Program
    {
        private static readonly Regex ConnectionEx = new Regex(@"(([a-z0-9]+) )*(NOT|AND|OR|RSHIFT|LSHIFT)*( ([a-z0-9]+))* ?-> ([a-z]+)"); 


        static void Main(string[] args)
        {
            var circuitBuilder = new CircuitBuilder();

            using (var inputReader = new StreamReader("input.txt"))
            {
                while (!inputReader.EndOfStream)
                {
                    var connectionString = inputReader.ReadLine();
                    var connectionMatch = ConnectionEx.Match(connectionString);
                    Debug.Assert(connectionMatch.Success);

                    var term1 = connectionMatch.Groups[2].Value;
                    var ops   = connectionMatch.Groups[3].Value;
                    var term2 = connectionMatch.Groups[5].Value;
                    var name  = connectionMatch.Groups[6].Value;

                    circuitBuilder.AddConnection(name, ops, term1, term2);
                }
            }

            var circuit = circuitBuilder.GetCircuit();
            DumpGateValues(circuit);
            var wireA1 = circuit["a"].Value;
            Console.WriteLine("Part 1 - solution: " + wireA1);

            // Part 2
            circuitBuilder.Override("b", wireA1);
            circuitBuilder.ResetWires();
            circuit = circuitBuilder.GetCircuit();
            DumpGateValues(circuit);
            var wireA2 = circuit["a"].Value;
            Console.WriteLine("Part 2 - solution: " + wireA2);

            Console.ReadKey();
        }

        private static void DumpGateValues(IDictionary<string, IGate> circuit)
        {
            var orderedGateNames = circuit.Keys.ToList();
            orderedGateNames.Sort();
            foreach (var gateName in orderedGateNames)
            {
                Debug.WriteLine("{0,-2} -> {1,5}", gateName, circuit[gateName].Value);
            }
        }
    }
}
