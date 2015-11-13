using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpressionTrees
{
    public static class Extensions2
    {
        public static IEnumerable<T> ApplyWheres<T>(this IEnumerable<T> collection,
            IList<Func<T, bool>> wheres)
        {
            foreach (var where in wheres)
            {
                collection = collection.Where(where);
            }

            return collection;
        }

        public static IEnumerable<T> ApplyWheresAsAggregate<T>(this IEnumerable<T> collection,
            IList<Func<T, bool>> wheres)
        {
            return wheres.Aggregate(collection, (current, @where) => current.Where(@where));
        }

        public static void Test()
        {
            var collection = new int[] { 1, 2, 3, 4, 5 };

            Func<int, bool> action1 = x => x > 3;
            Func<int, bool> action2 = x => x < 5;

            var actions = new List<Func<int, bool>>
            {
                action1,
                action2
            };

          var results=  collection.ApplyWheres(actions);
        }
    }
}
