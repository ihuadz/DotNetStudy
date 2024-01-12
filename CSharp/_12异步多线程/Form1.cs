using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace _12异步多线程
{
    /// <summary>
    /// Thread是C#语言对线程对象的封装
    /// 
    /// 是对方法执行的描述
    /// 同步：完成计算之后再进入下一行
    /// 异步：不会等待方法的完成，直接进入下一行，不会等待
    /// 
    /// 多线程就是实现异步的方式
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSync_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"***********btnSync_Click Start {Thread.CurrentThread.ManagedThreadId} {DateTime.Now}************");
            for (int i = 0; i < 5; i++)
            {
                this.DoSomethingLong($"btnSync_Click{i}");
            }

            Console.WriteLine($"***********btnSync_Click End {Thread.CurrentThread.ManagedThreadId} {DateTime.Now}************");
        }

        /// <summary>
        /// 自定义锁
        /// </summary>
        private static readonly object AsyncTestLock_Lock = new object();

        /// <summary>
        /// 异步
        /// 1 同步方法卡界面，主（UI）线程忙于计算
        ///   异步多线程不卡界面，主线程没有进行计算，交给子线程做
        /// 
        /// 2 同步方法慢，只有一个线程干活
        ///   异步多线程方法快，多个线程并发运算
        ///   并不是线性增长，a资源换时间，可能资源不够   b多线程也有管理成本
        ///   但并不是越多越好
        ///   多个独立任务可以同时运行
        /// 
        /// 3 异步多线程无序：启动无序 执行时间不确定 结束也无序
        ///   一定不要通过等几毫秒的形式来控制顺序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAsync_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"***********btnAsync_Click Start {Thread.CurrentThread.ManagedThreadId} {DateTime.Now}************");
            //for (int i = 0; i < 5; i++)
            //{
            //    var name = $"btnAsync_Click{i}";
            //    Task.Run(() => DoSomethingLong(name)).ContinueWith(t => Console.WriteLine($"线程{t.Id}_{name}结束"));

            //}

            {
                // 只有一个i 延迟后就会变成5或者其他数字
                // 使用内部变量就可以解决此问题（每次循环新增变量）
                for (int i = 0; i < 5; i++)
                {
                    int k = i;
                    Task.Run(() =>
                    {
                        Console.WriteLine($"k={k}_i={i}");
                    });
                }
            }

            //{
            //    TaskFactory taskFactory = Task.Factory;
            //    taskFactory.StartNew(() => DoSomethingLong("btnAsync_Click6"));

            //}
            //{
            //    // Parallel 卡界面，主线程参与计算，节约了一个线程
            //    Parallel.Invoke(() =>
            //    {
            //        DoSomethingLong("1232");
            //        DoSomethingLong("1235");
            //        DoSomethingLong("1236");
            //    });
            //}

            //{
            //    // MaxDegreeOfParallelism限制线程数量
            //    ParallelOptions parallelOptions = new ParallelOptions();
            //    parallelOptions.MaxDegreeOfParallelism = 3;
            //    Parallel.For(0, 10, parallelOptions, x => Console.WriteLine($"{x}"));

            //}

            //{
            //    // 多线程异常，最好在子线程内处理好异常
            //    // AggregateException 多用于多线程异常
            //    AggregateException aggregateException = null;

            //}

            {
                // 线程 取消
                try
                {
                    List<Task> tasks = new List<Task>();
                    TaskFactory taskFactory = Task.Factory;

                    CancellationTokenSource cts = new CancellationTokenSource();
                    for (int i = 0; i < 40; i++)
                    {
                        int k = i;
                        string name = string.Format("线程取消测试{0}", i);
                        void act(object? t)
                        {
                            try
                            {
                                if (k == 11)
                                {
                                    throw new Exception($"{t}执行失败");
                                }

                                if (cts.IsCancellationRequested)
                                {
                                    Console.WriteLine($"{t}放弃执行");
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine($"{t}执行成功");
                                }
                            }
                            catch (Exception ex)
                            {
                                cts.Cancel();
                                Console.WriteLine($"{ex.Message}");
                            }
                        }
                        tasks.Add(taskFactory.StartNew(act, name, cts.Token));
                    }
                    Task.WaitAll(tasks.ToArray());
                }
                catch (AggregateException aex)
                {
                    foreach (var item in aex.InnerExceptions)
                    {
                        Console.WriteLine(item.Message);
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            {
                // 线程安全
                // lock 方式，没有并发，所以解决了问题，但牺牲性能 尽量最小计算量使用
                // 安全队列 ConcurrentQueue
                // 数据拆分，避免冲突
                try
                {
                    TaskFactory taskFactory = Task.Factory;
                    List<Task> tasks = new List<Task>();

                    int TotalCount = 0;
                    for (int i = 0; i < 10000; i++)
                    {  
                        // lock 方式，没有并发，所以解决了问题，但牺牲性能
                        tasks.Add(taskFactory.StartNew(() =>
                        {
                            lock (AsyncTestLock_Lock)
                            {
                                TotalCount += 1;
                            }
                        }));

                        // lock是语法糖，相当于执行以下两条语句
                        // 占用此引用链接，不要用string 因为享元
                        //Monitor.Exit(AsyncTestLock_Lock);
                        //Monitor.Enter(AsyncTestLock_Lock);

                        // 官方标准写法
                        // private 防止外面也去lock   static全局唯一   readonly不改动  object引用类型
                        //private static readonly object AsyncTestLock_Lock = new object();
                    }
                    Task.WaitAll(tasks.ToArray());
                    Console.WriteLine(TotalCount);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            Console.WriteLine($"***********btnAsync_Click End {Thread.CurrentThread.ManagedThreadId} {DateTime.Now}************");
        }
        private static bool IsNotNull([NotNullWhen(true)] object? obj) => obj != null;
        private void DoSomethingLong(string name)
        {
            Console.WriteLine($"***********DoSomethingLong {name} Start {Thread.CurrentThread.ManagedThreadId} {DateTime.Now}************");
            long lResult = 0;
            for (long i = 0; i < 10000000; i++)
            {
                lResult += i;
            }
            Thread.Sleep(2000);

            Console.WriteLine($"***********DoSomethingLong {name} End {Thread.CurrentThread.ManagedThreadId} {DateTime.Now}************");

            {
                //ManualResetEvent
            }
        }
    }
}