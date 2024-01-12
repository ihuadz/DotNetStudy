
namespace EventHandlerSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 简单的事件处理
            //Counter c = new Counter(new Random().Next(10));
            //c.ThresholdReached += c_ThresholdReached;

            //Console.WriteLine("press 'a' key to increase total");
            //while (Console.ReadKey(true).KeyChar == 'a')
            //{
            //    Console.WriteLine("adding one");
            //    c.Add(1);
            //}

            //温度监控
            TemperatureMonitor tm = new TemperatureMonitor();
            //tm.GetTemperature();

            TemperatureReporter tr = new TemperatureReporter();
            tr.Subscribe(tm);
            tr.OnNext(new Temperature(10, DateTime.Now));
        }

        static void c_ThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached);
            Environment.Exit(0);
        }
    }
}
