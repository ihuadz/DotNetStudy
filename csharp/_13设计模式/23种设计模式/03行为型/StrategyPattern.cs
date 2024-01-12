
namespace _13设计模式._23种设计模式._03行为型
{
    internal class StrategyPattern
    {
        /// <summary>
        /// 策略模式
        /// </summary>
        /// <remarks>
        /// 定义一组算法，将每个算法都封装起来，并且使它们之间可以互换。
        /// 
        /// 优点：算法可以自由切换；避免使用多重条件判断；扩展性良好。
        /// 缺点：策略类会增多；所有策略类都需要对外暴露。
        /// </remarks>
        internal static void Show()
        {
            Context context = new Context();
            context.SetStrategy(new ConcreteStrategyB());

            context.ExecuteStrategy();
        }
    }

    /// <summary>
    /// 策略接口
    /// </summary>
    internal interface IStrategy
    {
        void Execute();
    }

    /// <summary>
    /// 具体策略A
    /// </summary>
    internal class ConcreteStrategyA : IStrategy
    {
        /// <summary>
        /// 执行具体策略A
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("执行具体策略A");
        }
    }

    /// <summary>
    /// 具体策略B
    /// </summary>
    internal class ConcreteStrategyB : IStrategy
    {
        /// <summary>
        /// 执行具体策略B
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("执行具体策略B");
        }
    }

    /// <summary>
    /// 环境类
    /// </summary>
    internal class Context
    {
        private IStrategy _strategy;

        /// <summary>
        /// 设置策略
        /// </summary>
        /// <param name="strategy">策略对象</param>
        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        /// <summary>
        /// 执行策略
        /// </summary>
        public void ExecuteStrategy()
        {
            _strategy.Execute();
        }
    }
}