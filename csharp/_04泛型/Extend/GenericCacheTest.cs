using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace _04泛型.Extend
{
    /// <summary>
    /// 泛型缓存
    /// </summary>
    public class GenericCacheTest
    {

        public static void Show()
        {
            for (int i = 0; i < 5; i++)
            {
                GenericCache<int>.GetCache();
                Thread.Sleep(10);
                GenericCache<long>.GetCache();
                Thread.Sleep(10);
                GenericCache<string>.GetCache();
                Thread.Sleep(10);
                GenericCache<DateTime>.GetCache();
            }
        }
    }

    /// <summary>
    /// 不同类型首次调用会创建一次副本，使用static静态关键字
    /// 缓存效率高，大于Dictionary
    /// 不能主动释放
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericCache<T>
    {
        static GenericCache()
        {
            _TypeTime = string.Format("{0}_{1}", typeof(T).FullName, DateTime.Now.ToString());
            
        }

        private static string _TypeTime = "";

        public static string GetCache()
        {
            Console.WriteLine(_TypeTime);
            return _TypeTime;
        }
    }
}
