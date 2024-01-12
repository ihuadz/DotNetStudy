using _13设计模式.七大原则.DIP_依赖倒置_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13设计模式._23种设计模式._02结构型
{
    /// <summary>
    /// 桥接设计模式
    /// </summary>
    /// <remarks>
    /// 将抽象部分与它的实现部分分离，使他们都可以独立的变化
    /// 
    /// 桥接设计模式优点：
    /// 1、桥接模式，相对于静态的继承而言，极大的减少了子类的个数，从而降低管理和维护成本。
    /// 2、桥接模式提高了系统的可扩展性，在两个变化唯独中任意扩展一个维度，都不需要修改原有系统，符合开闭原则。
    /// 就像一座桥，把两个变化的维度连接了起来。
    /// 桥接设计模式缺点：
    /// 1、桥接模式的引入会增加系统的理解与设计难度，由于组合/聚合关系建立在抽象层，要求开发者针对抽象进行设计与编程。
    /// 2、桥接模式要求正确的识别出系统中两个独立变化的维度，引起对开发者的编程思想有较高的要求。
    /// </remarks>
    internal class BridgePattern
    {
        public static void Show()
        {
            Car car = new QYCar();
            car.Move(new Red());
        }
    }

    interface IColor
    {
        string ShowColor();
    }

    class Red : IColor
    {
        public string ShowColor()
        {
            return "红色";
        }
    }

    class White : IColor
    {
        public string ShowColor()
        {
            return "白色";
        }
    }

    class Black : IColor
    {
        public string ShowColor()
        {
            return "褐色";
        }
    }

    abstract class Car
    {
        public abstract void Move(IColor color);
    }

    class QYCar : Car
    {
        public override void Move(IColor color)
        {
            Console.WriteLine($"{color.ShowColor()}的汽油车在跑");
        }
    }

    class EVCar : Car
    {
        public override void Move(IColor color)
        {
            Console.WriteLine($"{color.ShowColor()}的电动车在跑");
        }
    }

    class TaiyangnengCar : Car
    {
        public override void Move(IColor color)
        {
            Console.WriteLine($"{color.ShowColor()}的太阳能车在跑");
        }
    }
}
