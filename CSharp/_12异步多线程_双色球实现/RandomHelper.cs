using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12异步多线程_双色球实现
{
    internal class RandomHelper
    {
        public static int GetAsyncRandom(int min, int max)
        {
            string guid = System.Guid.NewGuid().ToString();
            Random random = new Random(guid.GetHashCode());
            Thread.Sleep(random.Next(50, 100));
            return random.Next(min, max);
        }

        /// <summary>
        /// 获取球数量
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string[] GetNums(int count)
        {
            List<string> list = new List<string>();
            for (int i = 1; i <= count; i++)
            {
                list.Add(i.ToString("00"));
            }
            return list.ToArray();
        }
    }
}
