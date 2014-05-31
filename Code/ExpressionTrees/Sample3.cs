using System;
using System.Linq.Expressions;

namespace ExpressionTrees
{
    public static partial class Samples
    {
        public static void Sample3()
        {
            //Are Types Equal?

            Console.WriteLine(AreTypesEqual(5, 10));
            Console.WriteLine(AreTypesEqual(5, 5m));
        }

        private static bool AreTypesEqual<T1, T2>(T1 a, T2 b)
        {
            //Parameter Expressions
            var aParameter = Expression.Parameter(typeof(T1), "a");
            var bParameter = Expression.Parameter(typeof(T2), "b");

            //Parameter Type Expressions
            var aParameterType = Expression.Constant(aParameter.Type);
            var bParameterType = Expression.Constant(bParameter.Type);

            //Equal Expression
            var areParametersTypesEqual = Expression.Equal(aParameterType, bParameterType);

            //Create Func
            var func = Expression.Lambda<Func<T1, T2, bool>>(areParametersTypesEqual, aParameter, bParameter).Compile();

            return func(a, b);
        }
    }
}
