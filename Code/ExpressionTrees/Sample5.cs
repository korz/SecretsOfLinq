using System;
using System.Linq.Expressions;

namespace ExpressionTrees
{
    public static partial class Samples
    {
        public static void Sample5()
        {
            //Custom Expression
            
            var isBetweenFunc = CreateIsBetweenFunc();

            var rangeFromDate = new DateTime(2014, 1, 1);
            var rangeThruDate = new DateTime(2014, 12, 31);

            var isTrue = isBetweenFunc(new DateTime(2014, 7, 6), rangeFromDate, rangeThruDate);
            var isFalse = isBetweenFunc(new DateTime(2015, 1, 1), rangeFromDate, rangeThruDate);
        }

        private static Func<DateTime, DateTime, DateTime, bool> CreateIsBetweenFunc()
        {
            var dateParameter = Expression.Parameter(typeof(DateTime), "date");
            var fromDateParameter = Expression.Parameter(typeof(DateTime), "fromDate");
            var thruDateParameter = Expression.Parameter(typeof(DateTime), "thruDate");

            var greaterExpression = Expression.GreaterThanOrEqual(dateParameter, fromDateParameter);
            var lesserExpression = Expression.LessThanOrEqual(dateParameter, thruDateParameter);

            var andExpression = Expression.And(greaterExpression, lesserExpression);

            return Expression.Lambda<Func<DateTime, DateTime, DateTime, bool>>(andExpression, dateParameter, fromDateParameter, thruDateParameter).Compile();
        }
    }
}
