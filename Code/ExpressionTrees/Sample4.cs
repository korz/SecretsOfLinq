using System;
using System.Linq.Expressions;
using ObjectsAsTrees.Data;

namespace ExpressionTrees
{
    public static partial class Samples
    {
        public static void Sample4()
        {
            //Decompile Existing Expression

            Expression<Func<int, bool>> expression = x => x < 5;
            Func<int, bool> func = x => x < 5;
            
            Func<Customer, object> customerFunc = x => x.Name;
            //"Name"

            ParameterExpression parameter =  expression.Parameters[0];
            BinaryExpression operation = (BinaryExpression)expression.Body;
            ParameterExpression left = (ParameterExpression)operation.Left;
            ConstantExpression right = (ConstantExpression) operation.Right;

            Console.WriteLine("Decompiled:\r\n{0} => {1} {2} {3}", parameter.Name, left.Name, operation.NodeType, right.Value);
            Console.ReadLine();
        }
    }
}
