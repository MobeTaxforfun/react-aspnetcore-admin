using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ZoneCore.Infra.DataAccess.EFCore
{
    public static class ExpressionExtension
    {

        private class ReplaceExpressionVisitor : ExpressionVisitor
        {
            private readonly Expression _oldValue;

            private readonly Expression _newValue;

            public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
            {
                _oldValue = oldValue;
                _newValue = newValue;
            }

            public override Expression Visit(Expression node)
            {
                if (node == _oldValue)
                {
                    return _newValue;
                }

                return base.Visit(node);
            }
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T));
            Expression left = new ReplaceExpressionVisitor(expr1.Parameters[0], parameterExpression).Visit(expr1.Body);
            Expression right = new ReplaceExpressionVisitor(expr2.Parameters[0], parameterExpression).Visit(expr2.Body);
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(left, right), new ParameterExpression[1] { parameterExpression });
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T));
            Expression left = new ReplaceExpressionVisitor(expr1.Parameters[0], parameterExpression).Visit(expr1.Body);
            Expression right = new ReplaceExpressionVisitor(expr2.Parameters[0], parameterExpression).Visit(expr2.Body);
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left, right), new ParameterExpression[1] { parameterExpression });
        }
    }
}
