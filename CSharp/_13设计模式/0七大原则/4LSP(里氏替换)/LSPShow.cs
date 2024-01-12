using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13设计模式.LSP
{
    /// <summary>
    /// 里氏替换原则（Liskov Substitution Principle,简称LSP）
    /// 任何使用基类的地方，都可以透明的使用他的基类；继承+不改变行为
    /// 继承、多态
    /// 继承：通过继承，之类拥有弗雷德一切属性和行为，任何父类出现的地方，都可以用子类来代替
    /// 1 子类必须完全实现父类有的方法，如果子类没有父类的某项东西，就断掉继承
    /// 2 子类可以有父类没有的东西，所以子类出现的地方，不一定能用父类代替
    /// 3 透明：就是安全，父类的东西换成子类不影响运行
    ///     a 父类已经实现的东西 不要new（隐藏）
    ///     b 父类已经实现的东西，想要改的话必须用virtual+override 避免埋雷
    /// 声明变量、参数、属性、字段，最好都是基于基类的
    /// </summary>
    internal class LSPShow
    {
        public static void Show()
        {
            {
                People people = new Yunnan();
                people.Show();
            }
        }
    }
}
