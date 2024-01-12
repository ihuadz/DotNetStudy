
using System.Xml.Linq;

namespace _13设计模式
{
    /// <summary>
    /// 访问者模式
    /// </summary>
    /// <remarks>
    /// 封装一些作用于某种数据结构中的各元素的操作，它可以在不改变数据结构的前提下定义作用于这些元素的新的操作，比如迭代不同类型对象
    /// 
    /// 优点：符合单一职责原则、优秀的扩展性、灵活性非常高
    /// 缺点：具体元素对访问者公布细节，违反了迪米特原则；具体元素变更比较困难；违反了依赖倒置原则，依赖了具体类，没有依赖抽象
    /// </remarks>
    internal class VisitorPattern
    {
        internal static void Show()
        {
            var visitor = new Visitor();
            for (int i = 0; i < 10; i++)
            {
                Element el = ObjectStructure.CreateElement();

                el.Accept(visitor);
            }
        }

    }

    /// <summary>
    /// 抽象元素
    /// </summary>
    abstract class Element
    {
        public abstract void DoSomething();

        public abstract void Accept(IVisitor visitor);
    }

    /// <summary>
    /// 具体元素
    /// </summary>
    class ConcreteElement1 : Element
    {
        private int _value;
        public ConcreteElement1(int value)
        {
            this._value = value;
        }

        public override void DoSomething()
        {
            Console.WriteLine($"{nameof(ConcreteElement1)} value:{_value}");
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// 具体元素
    /// </summary>
    class ConcreteElement2 : Element
    {
        private int _value;
        public ConcreteElement2(int value)
        {
            this._value = value;
        }

        public override void DoSomething()
        {
            Console.WriteLine($"{nameof(ConcreteElement2)} value:{_value}");
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// 访问接口
    /// </summary>
    interface IVisitor
    {
        void Visit(ConcreteElement1 element1);

        void Visit(ConcreteElement2 element2);
    }

    /// <summary>
    /// 具体访问者
    /// </summary>
    class Visitor : IVisitor
    {
        public void Visit(ConcreteElement1 element1)
        {
            element1.DoSomething();
        }

        public void Visit(ConcreteElement2 element2)
        {
            element2.DoSomething();
        }
    }

    /// <summary>
    /// 结构对象
    /// </summary>
    class ObjectStructure
    {
        public static Element CreateElement()
        {
            Random random = new Random();
            var rv = random.Next(0, 100);
            if (rv > 50)
            {
                return new ConcreteElement1(rv);
            }
            else
            {
                return new ConcreteElement2(rv);
            }
        }
    }
}