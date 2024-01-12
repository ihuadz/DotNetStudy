using System.Diagnostics;
using System.Drawing;

namespace _12异步多线程_练习
{
    internal class Program
    {
        private static readonly object Open_LOCK = new object();

        private static readonly object Console_LOCK = new object();

        static void Main(string[] args)
        {
            try
            {
                var lstPerson = Helper.GetPerson();
                Stopwatch stopwatch = Stopwatch.StartNew();
                List<Task> tasks = new List<Task>();
                TaskFactory taskFactory = Task.Factory;

                bool IsOpen = true;

                CancellationTokenSource cts = new CancellationTokenSource();

                Task.Run(() =>
                {
                    int rnum = 0;
                    int year = DateTime.Now.Year;
                    while (rnum != year)
                    {
                        rnum = new Random(rnum).Next(2000,2100);
                        Thread.Sleep(500);
                    }

                    cts.Cancel();
                    LogPrint("天降雷霆灭世，天龙八部的故事就此结束。。。。", ConsoleColor.White);
                });

                foreach (var person in lstPerson)
                {
                    if (cts.IsCancellationRequested)
                    {
                        break;
                    }
                    tasks.Add(taskFactory.StartNew(t =>
                    {
                        LogPrint(person.Name, person.Color);
                        foreach (var experience in person.Experiences)
                        {
                            if (cts.IsCancellationRequested)
                            {
                                break;
                            }
                            Random random = new Random();
                            Thread.Sleep(random.Next(100,500));
                            LogPrint(experience, person.Color);
                            lock (Open_LOCK)
                            {
                                // 首次循环
                                if (experience == person.Experiences.First() && IsOpen)
                                {
                                    LogPrint($"天龙八部就此拉开序幕。。。。。", ConsoleColor.White);
                                    IsOpen = false;
                                }
                            }
                        }
                    },person.Name, cts.Token));
                }

                taskFactory.ContinueWhenAny(tasks.ToArray(), t =>
                {
                    if (cts.IsCancellationRequested)
                    {
                        return;
                    }
                    LogPrint($"{t.AsyncState}已做好准备啦。。。。。", ConsoleColor.White);
                });

                taskFactory.ContinueWhenAll(tasks.ToArray(), t =>
                {
                    if (cts.IsCancellationRequested)
                    {
                        return;
                    }
                    LogPrint($"中原群雄大战辽兵，忠义两难一死谢天", ConsoleColor.White);
                });

                taskFactory.ContinueWhenAll(tasks.ToArray() ,t =>
                {
                    if (cts.IsCancellationRequested)
                    {
                        return;
                    }
                    stopwatch.Stop();
                    LogPrint($"天龙八部结束，共耗时{stopwatch.ElapsedMilliseconds}ms",ConsoleColor.White);
                });
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        private static void LogPrint(string msg, string colorStr)
        {
            ConsoleColor color = ConsoleColor.Gray;
            if (Enum.TryParse(typeof(ConsoleColor), colorStr, out var res))
            {
                color = (ConsoleColor)res!;
            }
            lock (Console_LOCK)
            {
                Console.ForegroundColor = color;
                foreach (var c in msg)
                {
                    Thread.Sleep(80);
                    Console.Write(c);
                }
                Console.WriteLine();
            }


        }

        private static void LogPrint(string msg, ConsoleColor color)
        {
            lock (Console_LOCK)
            {
                Console.ForegroundColor = color;
                foreach (var c in msg)
                {
                    Thread.Sleep(80);
                    Console.Write(c);
                }
                Console.WriteLine();
            }


        }
    }
}