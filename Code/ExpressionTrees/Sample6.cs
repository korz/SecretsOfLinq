using System;
using System.Linq.Expressions;

namespace ExpressionTrees
{
    public static partial class Samples
    {
        public static void Sample6()
        {
            Expression<Func<int, int, bool>> expression = GetAreTypesEqualExpression(5, 10);

            Func<int, int, bool> func = expression.Compile();

            Console.WriteLine("Expression: {0}", Evaluator(expression, 5, 10));
            Console.WriteLine("      Func: {0}", Evaluator(func, 5, 10));
            Console.ReadLine();
        }

        private static Expression<Func<T1, T2, bool>> GetAreTypesEqualExpression<T1, T2>(T1 a, T2 b)
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
            return Expression.Lambda<Func<T1, T2, bool>>(areParametersTypesEqual, aParameter, bParameter);
        }

        private static bool Evaluator<T1, T2>(Expression<Func<T1, T2, bool>> expression, T1 a, T2 b)
        {
            return expression.Compile()(a, b);
        }

        private static bool Evaluator<T1, T2>(Func<T1, T2, bool> func, T1 a, T2 b)
        {
            return func(a, b);
        }
    }
}
