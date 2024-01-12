using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13设计模式._23种设计模式._02结构型
{
    /// <summary>
    /// 装饰器模式
    /// </summary>
    /// <remarks>
    /// 动态的给一个对象添加一些额外的职责，就增加功能来说，装饰模式比生成子类更为灵活
    /// 
    /// 优点：装饰类和被装饰类可以独立发展，而不会相互耦合；装饰模式是继承关系的一个替代方案；装饰模式可以动态的扩展一个实现类的功能。
    /// 缺点：多层装饰比较复杂。
    /// </remarks>
    internal class DecoratorPattern
    {
        public static void Show()
        {
            //点一杯奶茶，加两份补丁、一份珍珠、一份仙草
            MilkTea milkTea = new MilkTea();

            Buding buding = new Buding();
            buding.SetComponent(milkTea);
            Buding buding1 = new Buding();
            buding1.SetComponent(buding);

            Xiancao xiancao = new Xiancao();
            xiancao.SetComponent(buding1);

            Zhenzhu zhenzhu = new Zhenzhu();
            zhenzhu.SetComponent(xiancao);

            Console.WriteLine($"总共花费{zhenzhu.Cost()}RMB");
        }
    }

    abstract class Yinliao
    {
        public abstract double Cost();
    }

    class MilkTea : Yinliao
    {
        public override double Cost()
        {
            Console.WriteLine("奶茶10块一杯");
            return 10;
        }
    }

    class FruitTea : Yinliao
    {
        public override double Cost()
        {
            Console.WriteLine("果茶15块一杯");
            return 15;
        }
    }

    class SodaTea : Yinliao
    {
        public override double Cost()
        {
            Console.WriteLine("苏打水8块一杯");
            return 8;
        }
    }


    abstract class Decorator : Yinliao
    {
        //添加父类引用
        private Yinliao yinliao;

        //通过set方法赋值
        public void SetComponent(Yinliao yinliao)
        {
            this.yinliao = yinliao;
        }

        public override double Cost()
        {
            return this.yinliao.Cost();
        }
    }

    class Buding : Decorator
    {
        private static double money = 5;

        public override double Cost()
        {
            Console.WriteLine("布丁5元");
            return base.Cost() + money;
        }
    }

    class Xiancao : Decorator
    {
        private static double money = 7;

        public override double Cost()
        {
            Console.WriteLine("仙草7元");
            return base.Cost() + money;
        }
    }


    class Zhenzhu : Decorator
    {
        private static double money = 7;

        public override double Cost()
        {
            Console.WriteLine("珍珠7元");
            return base.Cost() + money;
        }
    }
}
