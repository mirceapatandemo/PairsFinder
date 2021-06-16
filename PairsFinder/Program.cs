using System;
using System.Collections.Generic;
using System.Linq;

namespace PairsFinder
{
    class Program
    {
        static void Main()
        {
            //var values = new int[] {};   
            //var values = new[] {7};
            //var values = new[] {1, 7, 6};
            var values = new[] {10, 5, 2, 7, 7, 49};
            //var values = new[] {10, 5, 2, 5, 2, 7, 7, 49};
            //var values = new[] { 10, 5, 2, 4, 3, 7, 7, 49 };

            var pairs = Finder.GetPairs(values);
            Print(pairs);
        }

        static void Print(IReadOnlyList<(int Value1, int Value2)> pairs)
        {
            if(!pairs.Any())
                Console.WriteLine("No Pairs found\n");

            foreach (var pair in pairs)
                Console.WriteLine($"({pair.Value1},{pair.Value2})\n");

            Console.ReadLine();
        }
    }

    public class Finder
    {
        public static IReadOnlyList<(int Value1, int Value2)> GetPairs(IList<int> values)
        {
            var allPairs = new List<(int Value1, int Value2)>();
            var distinctSearchValues = values.Distinct();

            foreach (var searchValue in distinctSearchValues)
            {
                var pairs= GetPairsFor(values.ToList(), searchValue).ToList();
                allPairs.AddRange(pairs);
            }

            return allPairs.Distinct().ToList();
        }

        private static IEnumerable<(int Value1, int Value2)> GetPairsFor(IEnumerable<int> values, int searchValue)
        {
            var map = new HashSet<int>();

            foreach (var value in values)
            {
                if (map.Contains(searchValue - value))
                {
                    yield return BuildPair(searchValue - value, value);
                }

                map.Add(value);
            }
        }

        private static (int Value1, int Value2) BuildPair(int value1, int value2) =>
            value1 < value2 ? 
                (value1, value2) : 
                (value2, value1);
                
    }
}
