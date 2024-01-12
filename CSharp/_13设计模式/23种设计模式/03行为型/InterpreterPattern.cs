using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13设计模式._23种设计模式._03行为型
{
    /// <summary>
    /// 解释器
    /// </summary>
    /// <remarks>
    /// 给定一门语言，定义它的文法的一种表示，并定义一个解释器，这个解释器使用该表示来解释语言中的句子。
    /// 
    /// 优点：扩展性好，灵活。
    /// 缺点：解释器模式会引起类膨胀，解释器模式采用递归调用方法，存在效率问题。
    /// 
    /// 该类是解释器模式的示例，用于执行四则运算。
    /// </remarks>
    internal class InterpreterPattern
    {
        public static void Show()
        {
            // 创建解释器上下文
            InterpreterContext context = new InterpreterContext();

            // 创建解释器 10 + (5 - 2 * (8 / 4))
            Expression expression = new AddExpression(new NumberExpression(10), new SubtractExpression(new NumberExpression(5), new MultiplyExpression(new NumberExpression(2), new DivideExpression(new NumberExpression(8), new NumberExpression(4)))));

            // 解释并计算表达式
            int result = expression.Interpret(context);

            Console.WriteLine("计算结果：" + result);
        }
    }

    /// <summary>
    /// 解释器上下文
    /// </summary>
    internal class InterpreterContext
    {
        // 可以在上下文中存储一些全局信息
    }

    /// <summary>
    /// 抽象表达式
    /// </summary>
    internal abstract class Expression
    {
        public abstract int Interpret(InterpreterContext context);
    }

    /// <summary>
    /// 数字表达式
    /// </summary>
    internal class NumberExpression : Expression
    {
        private int number;

        public NumberExpression(int number)
        {
            this.number = number;
        }

        public override int Interpret(InterpreterContext context)
        {
            return number;
        }
    }

    /// <summary>
    /// 加法表达式
    /// </summary>
    internal class AddExpression : Expression
    {
        private Expression leftExpression;
        private Expression rightExpression;

        public AddExpression(Expression leftExpression, Expression rightExpression)
        {
            this.leftExpression = leftExpression;
            this.rightExpression = rightExpression;
        }

        public override int Interpret(InterpreterContext context)
        {
            return leftExpression.Interpret(context) + rightExpression.Interpret(context);
        }
    }

    /// <summary>
    /// 减法表达式
    /// </summary>
    internal class SubtractExpression : Expression
    {
        private Expression leftExpression;
        private Expression rightExpression;

        public SubtractExpression(Expression leftExpression, Expression rightExpression)
        {
            this.leftExpression = leftExpression;
            this.rightExpression = rightExpression;
        }

        public override int Interpret(InterpreterContext context)
        {
            return leftExpression.Interpret(context) - rightExpression.Interpret(context);
        }
    }

    /// <summary>
    /// 乘法表达式
    /// </summary>
    internal class MultiplyExpression : Expression
    {
        private Expression leftExpression;
        private Expression rightExpression;

        public MultiplyExpression(Expression leftExpression, Expression rightExpression)
        {
            this.leftExpression = leftExpression;
            this.rightExpression = rightExpression;
        }

        public override int Interpret(InterpreterContext context)
        {
            return leftExpression.Interpret(context) * rightExpression.Interpret(context);
        }
    }

    /// <summary>
    /// 除法表达式
    /// </summary>
    internal class DivideExpression : Expression
    {
        private Expression leftExpression;
        private Expression rightExpression;

        public DivideExpression(Expression leftExpression, Expression rightExpression)
        {
            this.leftExpression = leftExpression;
            this.rightExpression = rightExpression;
        }

        public override int Interpret(InterpreterContext context)
        {
            return leftExpression.Interpret(context) / rightExpression.Interpret(context);
        }
    }
}
