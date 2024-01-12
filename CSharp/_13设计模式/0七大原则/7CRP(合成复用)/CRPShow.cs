using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13设计模式.七大原则._7CRP_合成复用_
{
    /// <summary>
    /// 合成复用
    /// </summary>
    /// <remarks>
    /// 
    /// 将已有的对象纳入到新对象中，作为新对象的对象成员来实现的，新对象可以调用已有对象的工能，从而达到复用
    /// 
    /// 1 又称组合/聚合复用原则
    /// 2 将两使用对象组合，而不是继承来达到复用
    /// 3 实现方法
    /// 
    /// 继承的问题
    /// 1破坏了系统的對装性，基类发生了改变，子类的实现也会发生改变
    /// 2子类如果不需要某个方法或字段，则系统耦合性变高。
    /// 3继承是静态的，不能在程序运行时发生改变。
    /// 
    /// has a  对象组合
    /// is a 集成
    /// 
    /// 类和类之间的关系：泛化、实现、组合、聚合、关联、依赖
    /// </remarks>
    internal class CRPShow
    {
        public static void Show()
        {

        }
    }

    interface IColor
    {
        string ShowColor();
    }

    /// <summary>
    /// 实现接口
    /// </summary>
    class Green : IColor
    {
        public string ShowColor()
        {
            return "绿色";
        }
    }

    class Red : IColor
    {
        public string ShowColor()
        {
            return "红色";
        }
    }

    abstract class Car
    {
        public abstract void Run(IColor color);
    }

    /// <summary>
    /// OilCar是Car的特化  Car是OilCar的泛化
    /// </summary>
    class OilCar : Car
    {
        //关联
        private Energy energy;

        //依赖
        public void Fill(Oil oil)
        {

        }

        public override void Run(IColor color)
        {
            Console.WriteLine("汽油" + color.ShowColor() + "颜色的车在行驶");
        }
    }

    class EvCar : Car
    {
        //组合，强拥有
        private Cartwheel _cartwheel;
        public EvCar(Cartwheel cartwheel)
        {
            _cartwheel = cartwheel;
        }

        public override void Run(IColor color)
        {
            Console.WriteLine("电动" + color.ShowColor() + "颜色的车在行驶");
        }
    }

    /// <summary>
    /// 车轮
    /// </summary>
    class Cartwheel
    {
        public int Size;
    }

    /// <summary>
    /// 车队
    /// </summary>
    class Motorcade
    {
        /// <summary>
        /// 聚合 弱拥有
        /// </summary>
        private OilCar[] oilCars;
    }

    /// <summary>
    /// 能源
    /// </summary>
    class Energy
    {
        public string Name;
    }

    /// <summary>
    /// 石油
    /// </summary>
    class Oil
    {
        public string Type;
    }
}
