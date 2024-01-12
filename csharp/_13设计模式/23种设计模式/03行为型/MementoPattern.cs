
namespace _13设计模式
{
    /// <summary>
    /// 备忘录模式
    /// </summary>
    /// <remarks>
    /// 在不破坏封装性的前提下，捕获一个对象的内部状态，并在该对象之外保存这个状态，这样以后就可将该对象恢复到原先保存的状态
    /// 
    /// 该模式定义在ICloneable接口出现之前，所以需要将状态保存在对象外；有了ICloneable之后更为灵活，可以将状态保存在对象内部
    /// 
    /// 注意：备忘录模式的缺点是：在实际应用中，备忘录模式都是多状态和多备份的，如果要保存的状态过多，势必会占用大量的内存，影响程序的性能
    /// 
    /// </remarks>
    internal class MementoPattern
    {
        internal static void Show()
        {
            Originator originator = new Originator();
            Caretaker caretaker = new();
            originator.SetState("On");

            Console.WriteLine("创建备忘");
            caretaker.SetMemento(originator.CreateMemento());
            Console.WriteLine($"State {originator.GetState()}");
            Console.WriteLine("修改状态");
            originator.SetState("Off");
            Console.WriteLine($"State {originator.GetState()}");
            Console.WriteLine("恢复备忘");
            originator.RestoreMemento(caretaker.GetMemento());
            Console.WriteLine($"State {originator.GetState()}");


        }
    }

    /// <summary>
    /// 发起人
    /// </summary>
    internal class Originator
    {
        private string state = string.Empty;

        public string GetState()
        {
            return state;
        }

        public void SetState(string state)
        {
            this.state = state;
        }

        public IMemento CreateMemento()
        {
            return new Memento(state);
        }

        public void RestoreMemento(IMemento memento)
        {
            state = ((Memento)memento).GetState();
        }

        /// <summary>
        /// 内部备忘录
        /// </summary>
        private class Memento : IMemento
        {
            private string state = string.Empty;

            public Memento(string state)
            {
                this.state = state;
            }

            public string GetState()
            {
                return state;
            }

            public void SetState(string state)
            {
                this.state = state;
            }
        }
    }

    /// <summary>
    /// 备忘录空接口
    /// </summary>
    interface IMemento
    {
    }

    /// <summary>
    /// 备忘录管理者
    /// </summary>
    internal class Caretaker
    {
        private IMemento memento;

        public IMemento GetMemento()
        {
            return memento;
        }

        public void SetMemento(IMemento memento)
        {
            this.memento = memento;
        }
    }
}