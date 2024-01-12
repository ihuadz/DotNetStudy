namespace _08委托和事件
{
    /// <summary>
    /// 委托：本质是一个类，继承了xxx，里面内置了几个方法
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                {
                    NoReturnNoParams method = new NoReturnNoParams(SayHello);
                    method.Invoke(); // method();
                }
                // beginInvoke
                {
                    WithReturnNoParams method = new WithReturnNoParams(GetIntReturn);
                    int iResult = method.Invoke();
                    var result = method.BeginInvoke(null, null);
                    method.EndInvoke(result);
                }
                // 多播委托: 一个变量保存多个方法，可以增减
                {
                    //+= 为委托实例按顺序增加方法，形成方法链，Invoke时，按顺序依次执行
                    NoReturnNoParams method = new NoReturnNoParams(SayHello);
                    method += new NoReturnNoParams(SayHello);

                    method.Invoke();

                    //-= 为委托实例按顺序移出方法，从方法链尾部开始匹配，遇到一个完全吻合的，移出且只移出一个，没有也不会异常
                    method -= new NoReturnNoParams(SayHello);
                    method.Invoke();

                    // 多播委托不能使用异步BeginInvoke，

                    foreach (NoReturnNoParams item in method.GetInvocationList().Cast<NoReturnNoParams>())
                    {
                        item.Invoke();
                    }

                    //委托是一个类型，事件时委托的一个实例
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        static void SayHello()
        {
            Console.WriteLine("Say Hello");
        }

        static int GetIntReturn()
        {
            return 1;
        }

        /// <summary>
        /// 事件声明，委托是一个类型，事件时委托的一个实例
        /// </summary>
        public event NoReturnNoParams? MethodEvent;
     }

}