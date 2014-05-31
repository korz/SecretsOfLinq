using System;
using System.Linq.Expressions;

namespace ExpressionTrees
{
    public static partial class Samples
    {
        public static void Sample2()
        {
            //Full Expression
            // (15 + 3) * (10 + 5)

            ConstantExpression leftLeftOperand = Expression.Constant(15);
            ConstantExpression leftRightOperand = Expression.Constant(3);
            BinaryExpression leftAddExpression = Expression.Add(leftLeftOperand, leftRightOperand);

            ConstantExpression rightLeftOperand = Expression.Constant(10);
            ConstantExpression rightRightOperand = Expression.Constant(5);
            BinaryExpression rightAddExpression = Expression.Add(rightLeftOperand, rightRightOperand);

            BinaryExpression multiplyExpression = Expression.Multiply(leftAddExpression, rightAddExpression);

            Func<int> func = Expression.Lambda<Func<int>>(multiplyExpression).Compile();

            Console.WriteLine(func());
            Console.ReadLine();
        }
    }

    public static class Extensions
    {
        public static string EvaluateExpression(this BinaryExpression expression)
        {
            return Expression.Lambda<Func<int>>(expression).Compile().Invoke().ToString();
        }
    }
}
