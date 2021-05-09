using System;
using System.Collections.Generic;
using System.Linq;

namespace IPZLabsVarCinema
{
    public static class EnumerableExtensions
    {
        private static readonly Random _random = new Random();

        public static T GetRandomElement<T>(this IEnumerable<T> source) => source.ElementAt(_random.Next(source.Count()));
    }
}
