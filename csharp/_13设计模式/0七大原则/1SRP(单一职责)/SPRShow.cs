using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13设计模式.SRP
{
    /// <summary>
    /// 单一职责原则（Single Responsibility Principle，简称SRP ）
    /// 类T负责两个不同的职责：职责P1，职责P2.当职责P1需求发生改变而需要修改类T时，
    /// 有可能会导致原本运行正常的职责P2功能发生故障
    /// 
    /// 一个类只负责一个事
    /// 拆分后职责变得单一
    /// 简单--稳定--强大
    /// 
    /// 单一职责的成本：类变多了。上端需要知道更多类
    /// 
    /// 衡量使用：如果类相对稳定，扩展变化少，逻辑简单，违背单一职责也没关系
    ///         一个类不要让他太“累”
    ///         弱国不同职责总是一起变化，一定要分开
    ///         
    /// 方法层面：方法分支多，还可能扩展变化，最好拆分成多个方法
    ///      类：
    ///     接口：
    ///     类库：
    ///     项目：
    ///     系统：
    /// </summary>
    internal class SPRShow
    {
        public static void Show()
        {
            {
                //Animal animal = new Animal("鸡");
                //animal.Breath();
                //animal.Action();
            }
            {
                Animal animal = new AnimalFish("鱼");
                animal.Breath();
                animal.Action(); 

                // 要解决此问题，需要多个if else判断，这样违背了单一职责，Animal类干了多件事
            }
        }
    }
}
