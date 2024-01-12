using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13设计模式._23种设计模式._02结构型
{
    /// <summary>
    /// 适配器模式
    /// </summary>
    /// <remarks>
    /// 将一个类的接口，转换成客户端希望的另外一个接口
    /// 适配器模式使得原本由于接口不兼容而不能一起工作的那些类可以一起工作
    /// 
    /// 解决问题：
    /// 在软件系统中，我们经常会需要将一些现成的对象放到新的环境中进行使用，但是新的环境要求的接口，
    /// 是这些现存对象所不能满足的，如何利用现有的对象，又能满足新的引用环境所需接口
    /// 
    /// 优点：更好的复用
    /// 缺点：由于Adapter的存在，会提供系统的复杂度
    /// </remarks>
    internal class AdapterPattern
    {
        public static void Show()
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);
            target.Request();
        }

        /// <summary>
        /// 客户端希望的另外一个接口
        /// </summary>
        internal interface ITarget
        {
            void Request();
        }

        /// <summary>
        /// 需要适配的类
        /// </summary>
        internal class Adaptee
        {
            public void SpecificRequest()
            {
                Console.WriteLine("Adaptee SpecificRequest");
            }
        }

        /// <summary>
        /// 适配器类
        /// </summary>
        internal class Adapter : ITarget
        {
            private Adaptee _adaptee;

            public Adapter(Adaptee adaptee)
            {
                _adaptee = adaptee;
            }

            public void Request()
            {
                _adaptee.SpecificRequest();
            }
        }

    }
}
