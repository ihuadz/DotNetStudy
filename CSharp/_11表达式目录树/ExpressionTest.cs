using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _11表达式目录树
{
    internal class ExpressionTest
    {
        public static void Show()
        {
            {
                Func<int, int, int> func = (m, n) => (m * n) + 2;
                // 表达式目录树只能一行
                Expression<Func<int, int, int>> exp = (m, n) => (m * n) + 2;

                int iResult1 = func.Invoke(12, 23);
                int iResult2 = exp.Compile().Invoke(12, 23);
            }

            {
                // 拼装表达式树
                Expression<Func<People, bool>> lambda = x => x.Id.ToString().Equals("5");

                ParameterExpression parameterExpression = Expression.Parameter(typeof(People), "x");

                Expression<Func<People, bool>> lambda2 =
                    Expression.Lambda<Func<People, bool>>(
                        Expression.Call(
                            Expression.Call(
                                Expression.Property(
                                    parameterExpression, typeof(People).GetProperty("Id"))
                                , typeof(People).GetMethod("ToString"), Array.Empty<Expression>())
                            , typeof(People).GetMethod("Equals"), Expression.Constant("5", typeof(string)))
                        , new ParameterExpression[1] { parameterExpression });

            }

            {
                //用表达式目录树代替反射
            }

            {
                //ExpressionVisitor
            }
        }
    }
}
