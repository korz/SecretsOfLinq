using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Data;

namespace ExpressionTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            Left_Side_Expression_Tree();
            //Full_Expression_Tree();
            //Type_Comparison_Expression_Tree();
            //Decompile_Expression();
            //Is_Date_Within_Range();
            //Difference_Between_Expression_And_Func();
            //Create_Func_Filters_From_Dictionary();

            Console.ReadLine();
        }

        #region Sample 1
        public static void Left_Side_Expression_Tree()
        {
            //Left Expression
            // (15 + 3)

            ConstantExpression leftOperand = Expression.Constant(15);
            ConstantExpression rightOperand = Expression.Constant(3);
            BinaryExpression addExpression = Expression.Add(leftOperand, rightOperand);

            Console.WriteLine("{0} = {1}", addExpression, addExpression.EvaluateExpression());
        }

        public static void Full_Expression_Tree()
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
        }
        #endregion

        #region Sample 2
        private static Func<Customer, dynamic> _converter = x => new { Id = x.Id, Name = x.Name };

        public static void Type_Comparison_Expression_Tree()
        {
            //Are Types Equal?
            var repository = new FakeCustomerRepository();

            var customer = repository.GetCustomer(1);

            var dynamicCustomer = _converter(customer);

            Console.WriteLine(AreTypesEqual(customer,dynamicCustomer));
        }

        private static bool AreTypesEqual<T1, T2>(T1 a, T2 b)
        {
            //   (a,b) => a.GetType() == b.GetType();

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
        #endregion

        #region Sample 3
        public static void Decompile_Expression()
        {
            //Decompile Existing Expression

            Expression<Func<int, bool>> expression = x => x < 5;
            Func<int, bool> func = x => x < 5;

            Func<Customer, object> customerFunc = x => x.Name;
            //"Name"

            ParameterExpression parameter = expression.Parameters[0];
            BinaryExpression operation = (BinaryExpression)expression.Body;
            ParameterExpression left = (ParameterExpression)operation.Left;
            ConstantExpression right = (ConstantExpression)operation.Right;

            Console.WriteLine("Decompiled:\r\n{0} => {1} {2} {3}", parameter.Name, left.Name, operation.NodeType, right.Value);
        }
        #endregion

        #region Sample 4
        public static void Is_Date_Within_Range()
        {
            var isDateWithinRangeFunc = CreateIsDateWithinRangeFunc();

            var rangeFromDate = new DateTime(2014, 1, 1);
            var rangeThruDate = new DateTime(2014, 12, 31);

            Console.WriteLine(isDateWithinRangeFunc(new DateTime(2014, 7, 6), rangeFromDate, rangeThruDate));
            Console.WriteLine(isDateWithinRangeFunc(new DateTime(2015, 1, 1), rangeFromDate, rangeThruDate));
        }

        private static Func<DateTime, DateTime, DateTime, bool> CreateIsDateWithinRangeFunc()
        {
            //      (date, from, thru) => (date >= from) && (date <= thru) 
            var dateParameter = Expression.Parameter(typeof(DateTime), "date");
            var fromDateParameter = Expression.Parameter(typeof(DateTime), "fromDate");
            var thruDateParameter = Expression.Parameter(typeof(DateTime), "thruDate");

            var greaterExpression = Expression.GreaterThanOrEqual(dateParameter, fromDateParameter);
            var lesserExpression = Expression.LessThanOrEqual(dateParameter, thruDateParameter);

            var andExpression = Expression.And(greaterExpression, lesserExpression);

            return Expression.Lambda<Func<DateTime, DateTime, DateTime, bool>>(andExpression, dateParameter, fromDateParameter, thruDateParameter).Compile();
        }
        #endregion

        #region Sample 5
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

        public static void Difference_Between_Expression_And_Func()
        {
            Expression<Func<int, int, bool>> expression = GetAreTypesEqualExpression(5, 10);

            Func<int, int, bool> func = expression.Compile();

            Console.WriteLine("Expression: {0}", Evaluator(expression, 5, 10));
            Console.WriteLine("      Func: {0}", Evaluator(func, 5, 10));
            Console.ReadLine();
        }

        private static bool Evaluator<T1, T2>(Expression<Func<T1, T2, bool>> expression, T1 a, T2 b)
        {
            return expression.Compile()(a, b);
        }

        private static bool Evaluator<T1, T2>(Func<T1, T2, bool> func, T1 a, T2 b)
        {
            return func(a, b);
        }
        #endregion

        #region Sample 6
        public static void Create_Func_Filters_From_Dictionary()
        {
            var filters = new Dictionary<string, object>
                {
                    { "Id", 1 },
                    { "Name", "Spencer Group"}
                };

            IList<Func<Customer, bool>> funcs = CreateEqualExpressions<Customer>(filters).ToList();

            ProcessFuncs<Customer>(funcs);
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

        private static void ProcessFuncs<T>(IList<Func<Customer, bool>> funcs)
        {
            var repository = new FakeCustomerRepository();

            IQueryable<Customer> query = repository.Customers.AsQueryable();

            foreach (var func in funcs)
            {
                query = query.Where(func).AsQueryable();
            }

            var results = query.ToList();
            var control = repository.GetCustomers();
        }
        #endregion
    }

    public static class Extensions
    {
        public static string EvaluateExpression(this BinaryExpression expression)
        {
            return Expression.Lambda<Func<int>>(expression).Compile().Invoke().ToString();
        }
    }
}
