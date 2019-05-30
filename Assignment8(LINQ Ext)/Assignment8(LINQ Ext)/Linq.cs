using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment8_LINQ_Ext_
{
    /// <summary>
    /// Extension Method's class
    /// </summary>
    public static class Linq
    {
        public static IEnumerable<TResult> SelectExt<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null || selector == null)
            {
                throw new NullReferenceException();
            }
            foreach (var item in source)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TSource> WhereExt<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException();
            }

            var elements = source.Where(predicate);
            return elements;
        }

        public static IEnumerable<IGrouping<TKey, TSource>> GroupByExt<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null || keySelector == null)
            {
                //throw Exception;  ??CompileTime error
            }

            var elements = source.GroupBy(keySelector);
            return elements;
        }

        public static List<TSource> ToListExt<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
            {
                //throw Exception; ??
            }
            return new List<TSource>(source);
        }

        public static IOrderedEnumerable<TSource> OrderByExt<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null || keySelector == null)
            {
                //throw Exception;  ??CompileTime error
            }
            var elements = source.OrderBy(keySelector);
            return elements;
        }

        public static Dictionary<TKey, TSource> ToDictionaryExt<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null || keySelector == null)
            {
                //throw Exception;  ??CompileTime error
            }

            var elements = source.ToDictionary(keySelector);
            return elements;
        }

        static int MyCount<T>(this IEnumerable<T> sequence)
        {
            int count = 0;
            foreach(var item in sequence)
            {
                count++;
            }

            return 1;
        }
    }
}
