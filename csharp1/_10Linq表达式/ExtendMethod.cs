using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10Linq表达式
{
    /// <summary>
    /// 扩展方法类
    /// 最好指定类型扩展
    /// </summary>
    public static class ExtendMethod
    {
        /// <summary>
        /// 1 基于委托封装解耦，去掉重复代码，完成通用代码
        /// 2 泛型，应对各种类型
        /// 3 加迭代器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        //public static List<T> MyWhere<T>(this List<T> source, Func<T,bool>func)
        //{
        //    var list = new List<T>();
        //    foreach (var item in source)
        //    {
        //        if (func.Invoke(item))
        //        {
        //            list.Add(item);
        //        }
        //    }
        //    return list;
        //}

        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> source, Func<T, bool> func)
        {
            foreach (var item in source)
            {
                if (func.Invoke(item))
                {
                    yield return item;
                }
            }
        }

        public static void Sing(this Student student)
        {
            Console.WriteLine("This is Sing");
        }

        /// <summary>
        /// 最好指定类型，否则所有基类都可调用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public static void Show<T>(this T t) where T : Student
        {

        }
    }
}
