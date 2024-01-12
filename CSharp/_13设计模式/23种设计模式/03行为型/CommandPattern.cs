using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13设计模式._23种设计模式._03行为型
{
    internal class CommandPattern
    {
        /// <summary>
        /// 命令模式
        /// </summary>
        /// <remarks>
        /// 将一个请求封装为一个对象，从而使你可用不同的请求对客户进行参数化；
        /// 对请求排队或记录请求日志，以及支持可撤销的操作。
        /// 
        /// 优点：
        /// 类间解耦：调用者角色与接收者角色之间没有任何依赖关系，调用者实现功能时只需调用Command抽象类的execute方法就可以，不需要了解到底是哪个接收者执行。
        /// 可扩展性：Command的子类可以非常容易地扩展，而调用者Invoker和高层次的模块Client不产生严重的代码耦合。
        /// 
        /// 缺点：
        /// 如果有N个命令，问题就出来了，Command的子类就可不是几个，而是N个，这个类膨胀得非常大，这个就需要读者在项目中慎重考虑使用。
        /// </remarks>
        public static void Show()
        {
            // 创建接收者对象
            Receiver receiver = new Receiver();

            // 创建命令对象，并设置接收者
            ICommand command = new ConcreteCommand(receiver);

            // 创建调用者对象，并设置命令
            Invoker invoker = new Invoker();
            invoker.SetCommand(command);

            // 执行命令
            invoker.ExecuteCommand();

            Console.WriteLine("-------------ConcreteCommand2-------------");

            ICommand command2 = new ConcreteCommand2(receiver);
            invoker.SetCommand(command2);
            invoker.ExecuteCommand();

            invoker.RollBackCommand();

        }

        /// <summary>
        /// 命令接口
        /// </summary>
        interface ICommand
        {
            void Execute();

            void RollBack();
        }

        /// <summary>
        /// 具体命令类
        /// </summary>
        class ConcreteCommand : ICommand
        {
            private Receiver receiver;

            public ConcreteCommand(Receiver receiver)
            {
                this.receiver = receiver;
            }

            public void Execute()
            {
                receiver.Action();
                Console.WriteLine("ConcreteCommand execute");
            }

            public void RollBack()
            {
                Console.WriteLine("ConcreteCommand RollBack");
            }
        }

        class ConcreteCommand2 : ICommand
        {
            private Receiver receiver;

            public ConcreteCommand2(Receiver receiver)
            {
                this.receiver = receiver;
            }

            public void Execute()
            {
                receiver.Action();
                Console.WriteLine("ConcreteCommand2 execute");
            }

            public void RollBack()
            {
                Console.WriteLine("ConcreteCommand2 RollBack");
            }
        }


        /// <summary>
        /// 接收者类
        /// </summary>
        class Receiver
        {
            public void Action()
            {
                Console.WriteLine("执行命令");
            }
        }

        /// <summary>
        /// 调用者类
        /// </summary>
        class Invoker
        {
            private ICommand command;

            public void SetCommand(ICommand command)
            {
                this.command = command;
            }

            public void ExecuteCommand()
            {
                command.Execute();
            }

            public void RollBackCommand()
            {
                command.RollBack();
            }
        }


    }

}
