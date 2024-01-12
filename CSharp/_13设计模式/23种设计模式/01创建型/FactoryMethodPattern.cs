using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _13设计模式._23种设计模式._01创建型
{

    /// <summary>
    /// 工厂方法设计模式
    /// </summary>
    internal class FactoryMethodPattern
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

            ReflectionFactory reflectionFactory = new ReflectionFactory();
            //调用
            ICalFactory calFactory = reflectionFactory.GetCalFactory(oper);
            ICalculator calculator = calFactory.GetCalculator();

            Console.WriteLine("运算结果:" + calculator.GetResult(num1, num2));

        }
    }

    /// <summary>
    /// 运算符特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    class OperToFactoryAttribute : Attribute
    {
        public string Oper { get; }
        public OperToFactoryAttribute(string oper)
        {
            Oper = oper;
        }
    }

    /// <summary>
    /// 反射创建运算工厂对象
    /// </summary>
    class ReflectionFactory
    {
        //声明运算符与计算工厂映射
        Dictionary<string, ICalFactory> dic = new Dictionary<string, ICalFactory>();

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <remarks>
        /// 通过反射将对应运算符的计算对象添加到键值对
        /// </remarks>
        public ReflectionFactory()
        {
            //1、获取当前运行程序集
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                //获取到继承了计算工厂接口ICalFactory的对象
                if (typeof(ICalFactory).IsAssignableFrom(type) && !type.IsInterface)
                {
                    OperToFactoryAttribute otf = type.GetCustomAttribute<OperToFactoryAttribute>() ?? throw new ArgumentNullException("OperToFactoryAttribute");
                    if (otf != null)
                    {
                        //创建对应的计算工厂对象并添加到字典
                        dic[otf.Oper] = Activator.CreateInstance(type) as ICalFactory ?? throw new ArgumentNullException("OperToFactoryAttribute"); ;
                    }
                }
            }
        }

        /// <summary>
        /// 获取对应的计算工厂对象
        /// </summary>
        /// <param name="oper"></param>
        /// <returns></returns>
        public ICalFactory GetCalFactory(string oper)
        {
            if (dic.TryGetValue(oper, out ICalFactory? fac))
            {
                if (fac == null) throw new Exception("此运算符无法计算");
                return fac;
            }

            throw new Exception("此运算符无法计算");
        }
    }

    /// <summary>
    /// 工厂接口
    /// </summary>
    interface ICalFactory
    {
        ICalculator GetCalculator();
    }

    /// <summary>
    /// 计算接口
    /// </summary>
    interface ICalculator
    {
        double GetResult(double d1, double d2);
    }

    /// <summary>
    /// 加法对象
    /// </summary>
    class Add : ICalculator
    {
        public double GetResult(double d1, double d2)
        {
            return d1 + d2;
        }
    }

    /// <summary>
    /// 减法对象
    /// </summary>
    class Sub : ICalculator
    {
        public double GetResult(double d1, double d2)
        {
            return d1 - d2;
        }
    }

    /// <summary>
    /// 乘法对象
    /// </summary>
    class Mul : ICalculator
    {
        public double GetResult(double d1, double d2)
        {
            return d1 * d2;
        }
    }

    /// <summary>
    /// 除法对象
    /// </summary>
    class Div : ICalculator
    {
        public double GetResult(double d1, double d2)
        {
            return d1 / d2;
        }
    }

    /// <summary>
    /// 加法工厂
    /// </summary>
    [OperToFactory("+")]
    class AddFactory : ICalFactory
    {
        public ICalculator GetCalculator()
        {
            return new Add();
        }
    }

    /// <summary>
    /// 减法工厂
    /// </summary>
    [OperToFactory("-")]
    class SubFactory : ICalFactory
    {
        public ICalculator GetCalculator()
        {
            return new Sub();
        }
    }

    /// <summary>
    /// 乘法工厂
    /// </summary>
    [OperToFactory("*")]
    class MulFactory : ICalFactory
    {
        public ICalculator GetCalculator()
        {
            return new Mul();
        }
    }

    /// <summary>
    /// 除法工厂
    /// </summary>
    [OperToFactory("/")]
    class DivFactory : ICalFactory
    {
        public ICalculator GetCalculator()
        {
            return new Div();
        }
    }
}
