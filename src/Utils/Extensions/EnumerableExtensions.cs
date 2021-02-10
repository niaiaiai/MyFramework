using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils.Extensions
{
    public static class EnumerableExtensions
    {
        public static decimal RoundSum<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector, int decimals)
            => Math.Round(source.Sum(selector), decimals, MidpointRounding.AwayFromZero);
    }
}
