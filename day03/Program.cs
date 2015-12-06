using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace day03
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentHouse = new House(0, 0);
            var houses       = new HashSet<House>( new[] { currentHouse } );

            string orders;
            using (var inputReader = new StreamReader("input.txt"))
                orders = inputReader.ReadToEnd();

            // Part 1
            foreach (var order in orders)
            {
                currentHouse = GetNextHouse(currentHouse, order);
                houses.Add(currentHouse);
            }
            Console.WriteLine("Part 1 - Number of houses visited: " + houses.Count);


            // Part 2
            var currentHouses = new House[] { new House(0, 0), new House(0, 0) };  // Santa, Robo-Santa
            houses = new HashSet<House>( currentHouses );
            var player = 0;
            foreach (var order in orders)
            {
                currentHouses[player] = GetNextHouse(currentHouses[player], order);
                houses.Add(currentHouses[player]);
                player = 1 - player;
            }
            Console.WriteLine("Part 2 - Number of houses visited: " + houses.Count);

            Console.ReadKey();
        }

        private static House GetNextHouse(House currentHouse, char order)
        {
            switch (order)
            {
                case '>': return new House(currentHouse.X + 1, currentHouse.Y);
                case '<': return new House(currentHouse.X - 1, currentHouse.Y);
                case '^': return new House(currentHouse.X, currentHouse.Y + 1);
                case 'v': return new House(currentHouse.X, currentHouse.Y - 1);
                default: return currentHouse;
            }
        }
    }
}
