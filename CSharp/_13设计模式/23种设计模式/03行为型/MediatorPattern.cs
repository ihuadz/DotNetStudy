namespace _13���ģʽ._23�����ģʽ._03��Ϊ��
{
    /// <summary>
    /// �н���ģʽ
    /// </summary>
    /// <remarks>
    /// ��һ���н��������װһϵ�еĶ��󽻻����н���ʹ��������Ҫ��ʽ���໥���ã�
    /// �Ӷ�ʹ�������ɢ�����ҿ��Զ����ظı�����֮��Ľ�����
    /// 
    /// �ŵ㣺
    /// ����������������ԭ�е�һ�Զ�����������һ��һ��������ͬ����ֻ�����н��ߣ���������������ȻͬʱҲ������������ϡ�
    /// ȱ�㣺
    /// �н��߻����͵ĺܴ󣬶����߼����ӣ�ԭ��N������ֱ�ӵ��໥������ϵת��Ϊ�н��ߺ�ͬ�����������ϵ��ͬ����Խ�࣬�н��ߵ��߼���Խ���ӡ�
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

            colleague1.Send("�ɹ�������Ҫ�ɹ�����");
            colleague2.Send("���۹�����Ҫ���۵���");
            colleague3.Send("���������Ҫ�洢����");
        }
    }

    /// <summary>
    /// �н��߽ӿ�
    /// </summary>
    public interface IMediator
    {
        void Send(string message, Colleague colleague);

        void SetColleague(Colleague colleague1, Colleague colleague2, Colleague colleague3);
    }

    /// <summary>
    /// �����н�����
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
    /// ͬ����
    /// </summary>
    public abstract class Colleague
    {
        protected IMediator mediator;

        // ���캯�����õ��н��߶���
        public Colleague(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public abstract void Send(string message);
        public abstract void Notify(string message);
    }

    /// <summary>
    /// �ɹ�����
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
            Console.WriteLine("�ɹ������յ���Ϣ: " + message);
        }
    }

    /// <summary>
    /// ���۹���
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
            Console.WriteLine("���۹����յ���Ϣ: " + message);
        }
    }

    /// <summary>
    /// �������
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
            Console.WriteLine("��������յ���Ϣ: " + message);
        }
    }
}