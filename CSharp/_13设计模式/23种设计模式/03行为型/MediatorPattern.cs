namespace _13设计模式._23种设计模式._03行为型
{
    /// <summary>
    /// 中介者模式
    /// </summary>
    /// <remarks>
    /// 用一个中介对象来封装一系列的对象交互。中介者使各对象不需要显式地相互引用，
    /// 从而使其耦合松散，而且可以独立地改变它们之间的交互。
    /// 
    /// 优点：
    /// 减少类间的依赖，把原有的一对多的依赖变成了一对一的依赖，同事类只依赖中介者，减少了依赖，当然同时也降低了类间的耦合。
    /// 缺点：
    /// 中介者会膨胀的很大，而且逻辑复杂，原本N个对象直接的相互依赖关系转换为中介者和同事类的依赖关系，同事类越多，中介者的逻辑就越复杂。
    /// </remarks>
    public class MediatorPattern
    {
        public static void Show()
        {
            IMediator mediator = new ConcreteMediator();

            Colleague colleague1 = new PurchaseManager(mediator);
            Colleague colleague2 = new SalesManager(mediator);
            Colleague colleague3 = new StockManager(mediator);

            mediator.SetColleague(colleague1, colleague2, colleague3);

            colleague1.Send("采购管理需要采购电脑");
            colleague2.Send("销售管理需要销售电脑");
            colleague3.Send("存货管理需要存储电脑");
        }
    }

    /// <summary>
    /// 中介者接口
    /// </summary>
    public interface IMediator
    {
        void Send(string message, Colleague colleague);

        void SetColleague(Colleague colleague1, Colleague colleague2, Colleague colleague3);
    }

    /// <summary>
    /// 具体中介者类
    /// </summary>
    public class ConcreteMediator : IMediator
    {
        public Colleague Colleague1;
        public Colleague Colleague2;
        public Colleague Colleague3;

        public void Send(string message, Colleague colleague)
        {
            if (colleague == Colleague1)
            {
                Colleague2.Notify(message);
                Colleague3.Notify(message);
            }
            else if (colleague == Colleague2)
            {
                Colleague1.Notify(message);
                Colleague3.Notify(message);
            }
            else if (colleague == Colleague3)
            {
                Colleague1.Notify(message);
                Colleague2.Notify(message);
            }
        }

        public void SetColleague(Colleague colleague1, Colleague colleague2, Colleague colleague3)
        {
            this.Colleague1 = colleague1;
            this.Colleague2 = colleague2;
            this.Colleague3 = colleague3;
        }
    }

    /// <summary>
    /// 同事类
    /// </summary>
    public abstract class Colleague
    {
        protected IMediator mediator;

        // 构造函数，得到中介者对象
        public Colleague(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public abstract void Send(string message);
        public abstract void Notify(string message);
    }

    /// <summary>
    /// 采购管理
    /// </summary>
    public class PurchaseManager : Colleague
    {
        public PurchaseManager(IMediator mediator) : base(mediator) { }

        public override void Send(string message)
        {
            mediator.Send(message, this);
        }

        public override void Notify(string message)
        {
            Console.WriteLine("采购管理收到消息: " + message);
        }
    }

    /// <summary>
    /// 销售管理
    /// </summary>
    public class SalesManager : Colleague
    {
        public SalesManager(IMediator mediator) : base(mediator) { }

        public override void Send(string message)
        {
            mediator.Send(message, this);
        }

        public override void Notify(string message)
        {
            Console.WriteLine("销售管理收到消息: " + message);
        }
    }

    /// <summary>
    /// 存货管理
    /// </summary>
    public class StockManager : Colleague
    {
        public StockManager(IMediator mediator) : base(mediator) { }

        public override void Send(string message)
        {
            mediator.Send(message, this);
        }

        public override void Notify(string message)
        {
            Console.WriteLine("存货管理收到消息: " + message);
        }
    }
}