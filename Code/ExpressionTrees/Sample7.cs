using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ObjectsAsTrees.Data;

namespace ExpressionTrees
{
    public static partial class Samples
    {
        public static void Sample7()
        {
            var dictionary = new Dictionary<string, object>
                {
                    { "Id", 1 },
                    { "Name", "Spencer Group"}
                };

            IList<Func<Customer, bool>> list = CreateEqualExpressions<Customer>(dictionary).ToList();
            
            foreach (var item in list)
            {
                
            }
        }

        private static IEnumerable<Func<T, bool>> CreateEqualExpressions<T>(IDictionary<string, object> dictionary)
        {
            foreach (var item in dictionary)
            {
                yield return CreateEqualExpression<T>(item.Key, item.Value);
            }
        }

        private static Func<T, bool> CreateEqualExpression<T>(string propertyName, object value)
        {
            //Creates x => x.PropertyName == value

            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, propertyName);
            var constant = Expression.Constant(value);
            var equals = Expression.Equal(property, constant);

            return Expression.Lambda<Func<T, bool>>(equals, parameter).Compile();
        }
    }
}
