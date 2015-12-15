using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;


namespace day15
{
    internal sealed class Ingredient
    {
        private static readonly Regex IngredientEx = new Regex(@"(?<name>\w+): capacity (?<capacity>-?\d+), durability (?<durability>-?\d+), flavor (?<flavor>-?\d+), texture (?<texture>-?\d+), calories (?<calories>-?\d+)", RegexOptions.Compiled); 

        private readonly string _name;
        private readonly int    _capacity;
        private readonly int    _durability;
        private readonly int    _flavor;
        private readonly int    _texture;
        private readonly int    _calories;

        public Ingredient(string name, int capacity, int durability, int flavor, int texture, int calories)
        {
            _name = name;
            _capacity = capacity;
            _durability = durability;
            _flavor = flavor;
            _texture = texture;
            _calories = calories;
        }

        public int Capacity { get { return _capacity; } }
        public int Durability { get { return _durability; } }
        public int Flavor { get { return _flavor; } }
        public int Texture { get { return _texture; } }
        public int Calories { get { return _calories; } }

        public static Ingredient FromString(string ingredientString)
        {
            var match = IngredientEx.Match(ingredientString);
            Debug.Assert(match.Success);

            return new Ingredient(
                match.Groups["name"].Value,
                int.Parse(match.Groups["capacity"].Value),
                int.Parse(match.Groups["durability"].Value),
                int.Parse(match.Groups["flavor"].Value),
                int.Parse(match.Groups["texture"].Value),
                int.Parse(match.Groups["calories"].Value)
                );
        }
    }
}
