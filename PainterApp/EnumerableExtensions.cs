using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PainterApp
{
    public  static class EnumerableExtensions
    {
        //public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
        //    where T : class
        //    where TKey : IComparable<TKey> =>
        //    sequence.Aggregate((T)null, (best, cur) =>
        //       best == null ||
        //       criterion(cur).CompareTo(criterion(best)) < 0
        //           ? cur
        //           : best);

        public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
            where T : class
            where TKey : IComparable<TKey> =>
            sequence.Select(obj => Tuple.Create(obj, criterion(obj)))
                .Aggregate((Tuple<T, TKey>)null,
                    (best, cur) => best == null || cur.Item2.CompareTo(best.Item2) < 0 ? cur : best)
                .Item1;

    }
}
