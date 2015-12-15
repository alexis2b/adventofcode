using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace day15
{
    class Program
    {
        static void Main(string[] args)
        {
            var ingredients = File.ReadAllLines("input.txt").Select( Ingredient.FromString ).ToArray();

            var quantities = new int[ingredients.Length];
            var best = 0;
            var bestLight = 0;
            while( true )
            {
                for(int i = 0; i < ingredients.Length-1; i++ )
                {
                     quantities[i]++;
                    if ( quantities[i] > 100 )
                        quantities[i] = 0;
                    else
                        break;
                }

                var quantityApplied = quantities.Take(  ingredients.Length-1 ).Sum();
                if ( quantityApplied == 0 )
                    break;
                if ( quantityApplied > 100 )
                    continue;

                quantities[ ingredients.Length-1 ] = 100 - quantityApplied;

                // compute the result
                var capacity = 0;
                var durability = 0;
                var flavor = 0;
                var texture = 0;
                var calories = 0;
                for(int i = 0; i < ingredients.Length; i++)
                {
                    capacity += quantities[i] * ingredients[i].Capacity;
                    durability += quantities[i] * ingredients[i].Durability;
                    flavor += quantities[i] * ingredients[i].Flavor;
                    texture += quantities[i] * ingredients[i].Texture;
                    calories += quantities[i] * ingredients[i].Calories;
                }

                var total = Math.Max(0, capacity) * Math.Max(0, durability) * Math.Max(0, flavor) * Math.Max(0, texture);
                if ( total > best )
                    best = total;
                if (calories == 500 && total > bestLight)
                    bestLight = total;
            }
            Console.WriteLine("Part 1 - Solution: " + best);
            Console.WriteLine("Part 2 - Solution: " + bestLight);

            Console.ReadKey();
        }
    }
}
