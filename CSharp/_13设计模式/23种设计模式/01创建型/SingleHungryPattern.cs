using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13设计模式._23种设计模式._01创建型
{
    /// <summary>
    /// 饿汉式单例模式
    /// 不推荐使用 还没调用对象就创建了，会造成资源浪费
    /// 还可以使用静态内部类实现
    /// </summary>
    internal class SingleHungryPattern
    {
        public static void Show()
        {
            var singleHungry1 = SingleHungry.GetSingleHungry();
            var singleHungry2 = SingleHungry.GetSingleHungry();
            var singleHungry3 = SingleHungry.GetSingleHungry();

            Console.WriteLine("singleHungry1-hashValue:" + singleHungry1.GetHashCode());
            Console.WriteLine("singleHungry2-hashValue:" + singleHungry2.GetHashCode());
            Console.WriteLine("singleHungry3-hashValue:" + singleHungry3.GetHashCode());

        }
    }

    public class SingleHungry
    {
        //1、构造函数私有化
        private SingleHungry()
        {

        }

        //2、创建一个唯一的对象
        //private: 迪米特，没有必要暴露给外界的成员，都写成private
        //static: 静态成员，保证在内存的唯一性
        //readonly：不允许修改
        private static readonly SingleHungry _singleHungry = new SingleHungry();

        //3、创建一个方法，实现对外提供获取类唯一对象的能力
        public static SingleHungry GetSingleHungry()
        {
            return _singleHungry;
        }
    }
}
