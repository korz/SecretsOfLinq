using System;
using System.Linq.Expressions;

namespace ExpressionTrees
{
    public static partial class Samples
    {
        public static void Sample1()
        {
            //Left Expression
            // (15 + 3) * (10 + 5)

            ConstantExpression leftOperand = Expression.Constant(15);
            ConstantExpression rightOperand = Expression.Constant(3);
            BinaryExpression addExpression = Expression.Add(leftOperand, rightOperand);

            Console.WriteLine("{0} = {1}", addExpression, addExpression.EvaluateExpression());
            Console.ReadLine();
        }
    }
}
