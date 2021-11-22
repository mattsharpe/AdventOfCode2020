using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent2020.Solutions
{
    public class Day21
    {
        public IEnumerable<string> GetMatches(string input)
        {
            var regex = new Regex(@"(\w+)");

            foreach (Match match in regex.Matches(input))
            {
                yield return match.Value;
            }
        }

        private List<Food> ParseInput(string[] sample)
        {
            return sample.Select(line =>
            {
                var split = line.Split("(contains");
                return new Food
                {
                    Ingredients = new HashSet<string>(GetMatches(split[0])),
                    Allergens = new HashSet<string>(GetMatches(split[1])),
                };
            }).ToList();            
        }

        private Dictionary<string, HashSet<string>> PairIngredients(List<Food> foods)
        {         

            var allergens = foods.SelectMany(x => x.Allergens).ToHashSet();

            var map = new Dictionary<string, HashSet<string>>();
            
            //build a lookup of every allergen and it's potential ingredient
            //we need to look at the intersection of every food to find the 'common' ingredients for each allergen.
            foreach (var allergen in allergens)
            {
                
                var foodsWithAllergen = foods.Where(x => x.Allergens.Contains(allergen)).ToList();
                var combined = new HashSet<string>(foodsWithAllergen.First().Ingredients);
                foreach (var potential in foodsWithAllergen)
                {
                    combined.IntersectWith(potential.Ingredients);
                }

                map[allergen] = combined.ToHashSet();
            }

            // now we have a mapping of allergens and their potential ingredients.
            // any allergen that only has one potential ingredient is solved and means we can eliminate that ingredient as a possibility for other allergens
            while (map.Values.Any(x => x.Count > 1))
            {
                foreach (var allergen in allergens)
                {
                    var candidates = map[allergen];
                    if (candidates.Count != 1) continue;
                    foreach (var otherAllergen in allergens.Where(x => allergen != x))
                    {
                        map[otherAllergen].Remove(candidates.Single());
                    }
                }
            }
            return map;
        }

        public int CountSafeIngredients(string[] input)
        {
            var foods = ParseInput(input);
            var map = PairIngredients(foods);

            var ingredients = foods.SelectMany(x=>x.Ingredients);

            var iffy = map.Values.SelectMany(x => x).ToHashSet();
            return ingredients.Count(x => !iffy.Contains(x));
        }

        public string DangerousIngredientList(string[] input)
        {
            var foods = ParseInput(input);
            var map = PairIngredients(foods);

            var iffy = map.OrderBy(x=>x.Key).Select(x => x.Value.Single());

            return string.Join(",", iffy);

        }

    }

    public record Food
    {
        public HashSet<string> Ingredients { get; set; } = new();
        public HashSet<string> Allergens { get; set; } = new();

    }
}
