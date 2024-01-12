using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13设计模式._23种设计模式._01创建型
{
    /// <summary>
    /// 简单工厂设计模式
    /// </summary>
    internal class FactorySimpleStaticPattern
    {
        public static void Show()
        {
            //写一个简单的项目，来实现计算器加减乘除的功能
            Console.WriteLine("请输入第一个数");
            var num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("请输入第二个数");
            var num2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("请输入运算符");
            var oper = Console.ReadLine() ?? string.Empty;

            //调用
            ICalculator calculator = CalFactory.GetCalculator(oper);

            Console.WriteLine("运算结果:" + calculator?.GetResult(num1, num2));
        }

        class CalFactory
        {
            public static ICalculator GetCalculator(string oper)
            {
                //4个对象：加减乘除
                ICalculator? calculator = null;
                switch (oper)
                {
                    case "+": calculator = new Add(); break;
                    case "-": calculator = new Sub(); break;
                    case "*": calculator = new Mul(); break;
                    case "/": calculator = new Div(); break;
                }

                return calculator ?? throw new Exception("运算器出错");
            }
        }

        interface ICalculator
        {
            double GetResult(double d1, double d2);
        }

        class Add : ICalculator
        {
            public double GetResult(double d1, double d2)
            {
                return d1 + d2;
            }
        }

        class Sub : ICalculator
        {
            public double GetResult(double d1, double d2)
            {
                return d1 - d2;
            }
        }

        class Mul : ICalculator
        {
            public double GetResult(double d1, double d2)
            {
                return d1 * d2;
            }
        }

        class Div : ICalculator
        {
            public double GetResult(double d1, double d2)
            {
                return d1 / d2;
            }
        }
    }
}
