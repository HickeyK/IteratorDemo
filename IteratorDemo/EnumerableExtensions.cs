using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorDemo
{
    public static class EnumerableExtensions
    {
        //public IPainter FindCheapest<T, TKey>(this IEnumerable<T> painters, Func<T, TKey>)

        //public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
        //    where T : class
        //    where TKey : IComparable<TKey>  =>
        //        sequence.Aggregate((T)null, (best, curr) =>
        //            best == null ||
        //            criterion(curr).CompareTo(criterion(best)) < 0 ?
        //            curr : best);


        public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
            where T : class
            where TKey : IComparable<TKey> =>
            sequence
                .Select(obj => Tuple.Create(obj, criterion(obj)))
                .Aggregate((Tuple<T,TKey>)null, 
                (best, curr) => best == null || curr.Item2.CompareTo(best.Item2) < 0 ? curr : best)
                .Item1;


    }
}
