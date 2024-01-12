using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04泛型
{
    /// <summary>
    /// 监控
    /// </summary>
    public class Monitor
    {
        /// <summary>
        /// 监控方法
        /// </summary>
        public static void Show()
        {

            long commonSecond = 0;
            long objectSecond = 0;
            long genericSecond = 0;


            {
                Stopwatch sw = Stopwatch.StartNew();
                for (int i = 0; i < 100000000; i++)
                {
                    ShowInt(123);
                }
                sw.Stop();
                commonSecond = sw.ElapsedMilliseconds;
            }

            {
                Stopwatch sw = Stopwatch.StartNew();
                for (int i = 0; i < 100000000; i++)
                {
                    ShowObject(123);
                }
                sw.Stop();
                objectSecond = sw.ElapsedMilliseconds;
            }

            {
                Stopwatch sw = Stopwatch.StartNew();
                for (int i = 0; i < 100000000; i++)
                {
                    ShowGeneric(123);
                }
                sw.Stop();
                genericSecond = sw.ElapsedMilliseconds;
            }

            Console.WriteLine("commonSecond={0},objectSecond={1},genericSecond={2}",
                commonSecond,objectSecond,genericSecond);
        }

        /// <summary>
        /// 打印int类型值
        /// </summary>
        /// <param name="iParameter"></param>
        private static void ShowInt(int iParameter)
        {

        }

        /// <summary>
        /// 打印Object类型值
        /// </summary>
        /// <param name="iParameter"></param>
        private static void ShowObject(object oParameter)
        {

        }

        /// <summary>
        /// 2.0推出的新语法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tParameter"></param>
        private static void ShowGeneric<T>(T tParameter)
        {

        }
    }
}
