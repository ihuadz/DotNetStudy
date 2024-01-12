using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05反射
{
    /// <summary>
    /// 单例模式
    /// </summary>
    public sealed class Singleton
    {
        /// <summary>
        /// 静态字段存储实例
        /// </summary>
        private static Singleton _Singleton = null;

        /// <summary>
        /// 构建私有构造方法
        /// </summary>
        private Singleton()
        {
            Console.WriteLine("Singleton被构造了");
        }

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static Singleton()
        {
            _Singleton = new Singleton();
        }

        /// <summary>
        /// 提供静态创建实例方法
        /// </summary>
        /// <returns></returns>
        public static Singleton GetInstance()
        {
            return _Singleton;
        }
    }
}
