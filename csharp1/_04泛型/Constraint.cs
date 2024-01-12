using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04泛型
{
    /// <summary>
    /// 泛型约束，保证类型安全
    /// seald无法约束，没有意义
    /// </summary>
    public class Constraint
    {
        /// <summary>
        /// 2.0推出的新语法
        /// 1、可以使用基类的一切属性方法---权力
        /// 2、强制保证T一点是People或者People的子类---义务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tParameter"></param>
        public static void Show<T>(T tParameter)
            where T : People
        {
            //Console.WriteLine("This is {0},parameter={1},type={2}",
            //    typeof(GenericMethod), tParameter.GetType().Name, tParameter.ToString());

            Console.WriteLine($"{tParameter.Id}_{tParameter.Name}");
            tParameter.Hi();
        }

        /// <summary>
        /// 泛型约束例子
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T GetT<T>(T t)
            //where T : IPeople  //接口约束
            //where T : class  //引用类型约束
            //where T : struct  //值类型约束
            where T : new() //无参构造函数约束
        {
            //T tNew = null;
            //T tNew = default(T);
            T tNew = new T();
            return t;
        }
    }
}
