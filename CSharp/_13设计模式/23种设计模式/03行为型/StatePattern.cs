
namespace _13设计模式
{
    /// <summary>
    /// 状态模式
    /// </summary>
    /// <remarks>
    /// 当一个对象内在状态改变时允许其改变行为，这个对象看起来像是改变了其类
    /// 
    /// 优点：结构清晰、遵循设计原则、封装性非常好
    /// 缺点：子类会太多，不符合开闭原则
    /// </remarks>
    internal class StatePattern
    {
        internal static void Show()
        {
            StateContext context = new();
            context.SetCurrentState(StateContext.state1);

            context.Handle1();
            context.Handle2();
        }
    }

    /// <summary>
    /// 抽象环境角色
    /// </summary>
    abstract class State
    {
        protected StateContext context;

        public void SetContext(StateContext context)
        {
            this.context = context;
        }

        public abstract void Handle1();

        public abstract void Handle2();
    }

    class ConcreteStateA : State
    {
        public override void Handle1()
        {
            Console.WriteLine("concreteStateA handle1");
        }

        public override void Handle2()
        {
            base.context.SetCurrentState(StateContext.state2);
            base.context.Handle2();
        }
    }

    class ConcreteStateB : State
    {
        public override void Handle1()
        {
            base.context.SetCurrentState(StateContext.state1);
            base.context.Handle1();
        }

        public override void Handle2()
        {
            Console.WriteLine("concreteStateB handle2");
        }
    }

    /// <summary>
    /// 具体环境角色
    /// </summary>
    internal class StateContext
    {
        public static State state1 = new ConcreteStateA();
        public static State state2 = new ConcreteStateB();

        private State currentState;

        public State GetCurrentState()
        {
            return currentState;
        }

        public void SetCurrentState(State currentState)
        {
            this.currentState = currentState;
            //切换状态
            this.currentState.SetContext(this);
        }

        public void Handle1()
        {
            this.currentState.Handle1();
        }

        public void Handle2()
        {
            this.currentState.Handle2();
        }
    }
}