using _13设计模式._23种设计模式._01创建型;
using _13设计模式._23种设计模式._02结构型;
using _13设计模式._23种设计模式._03行为型;
using _13设计模式.DIP;
using _13设计模式.ISP;
using _13设计模式.LoD;
using _13设计模式.LSP;
using _13设计模式.OCP;
using _13设计模式.SRP;
using _13设计模式.七大原则._7CRP_合成复用_;
using _13设计模式.七大原则.DIP_依赖倒置_;
using System;

namespace _13设计模式
{
    /// <summary>
    /// 设计模式：面向对象语言开发过程中，遇到各种场景核问题，解决方案和思路，沉淀下来就是设计模式
    /// 设计模式七大原则：面向对象语言开发过程中，推荐的一些指导性原则（并不是强制要求的）
    /// 
    /// 目的：保证代码可读性、可靠性、稳定性、易于扩展
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("_13设计模式");

            // 1、单一职责原则（Single Responsibility Principle，简称SRP ）
            // 2、里氏替换原则（Liskov Substitution Principle,简称LSP） 
            // 3、依赖倒置原则（Dependence Inversion Principle,简称DIP）
            // 4、接口隔离原则（Interface Segregation Principle,简称ISP）
            // 5、迪米特法则（Law of Demeter,简称LoD）
            // 6、开放封闭原则（Open Close Principle,简称OCP）
            #region 面向对象设计模式的七大原则
            ////单一职责原则
            //{
            //    SPRShow.Show();
            //}

            ////开闭原则
            //{
            //    OCPShow.Show();
            //}

            ////依赖倒置
            //{
            //    DIPShow.Show();
            //    DIPShow2.Show();
            //}

            ////里氏替换
            //{
            //    LSPShow.Show();
            //}

            ////接口分离
            //{
            //    ISPShow iSPShow = new ISPShow();
            //}

            ////迪米特
            //{
            //    LODShow.Show();
            //}

            ////合成复用
            //{
            //    CRPShow.Show();
            //}
            #endregion

            #region 设计模式

            #region 创建型设计模式
            //{
            //    //单例模式
            //    //饿汉式
            //    SingleHungryPattern.Show();

            //    //懒汉式
            //    SingleLazyManPattern.Show();
            //}

            //{
            //    //工厂模式
            //    //简单静态工厂
            //    FactorySimpleStaticPattern.Show();

            //    //工厂方法设计模式
            //    FactoryMethodPattern.Show();

            //    //抽象工厂
            //    FactoryAbstractPattern.Show();
            //}

            //{
            //    //原型模式
            //    PrototypePattern.Show();
            //}

            //{
            //    //建造者模式
            //    BuilderPattern.Show();
            //}
            #endregion

            #region 结构型设计模式
            //{
            //    //适配器模式
            //    AdapterPattern.Show();
            //}

            //{
            //    //装饰器模式
            //    DecoratorPattern.Show();
            //}

            //{
            //    //代理模式
            //    ProxyPattern.Show();
            //}

            //{
            //    //桥接模式
            //    BridgePattern.Show();
            //}

            //{
            //    //组合设计模式
            //    CompositePattern.Show();
            //}

            //{
            //    //享元设计
            //    FlyweightPattern.Show();
            //}

            //{
            //    //外观设计
            //    FacadePattern.Show();
            //}
            #endregion

            #region 行为型设计模式
            //{
            //    //模板方法模式
            //    TemplateMethodPattern.Show();
            //}

            //{
            //    //中介者模式
            //    MediatorPattern.Show();
            //}

            //{
            //    //命令模式
            //    CommandPattern.Show();
            //}

            //{
            //    //责任链模式
            //    ChainOfResponsibilityPattern.Show();
            //}

            //{
            //    //策略模式
            //    StrategyPattern.Show();
            //}

            //{
            //    //迭代器模式（IteratorPattern）
            //    IteratorPattern.Show();
            //}

            //{
            //    //观察者模式（Oberver Pattern）
            //    OberverPattern.Show();
            //}

            //{
            //    //备忘录模式（MementoPattern）
            //    MementoPattern.Show();
            //}

            //{
            //    //访问者模式（VisitorPattern）
            //    VisitorPattern.Show();
            //}

            //{
            //    //状态模式（State Pattern）
            //    StatePattern.Show();
            //}

            {
                //解释器模式InterpreterPattern
                InterpreterPattern.Show();
            }
            #endregion
            #endregion
        }
    }
}