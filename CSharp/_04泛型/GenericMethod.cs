using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04泛型
{
    /// <summary>
    /// 泛型方法 
    /// </summary>
    public class GenericMethod
    {
        /// <summary>
        /// 2.0推出的新语法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tParameter"></param>
        public static void Show<T>(T tParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(GenericMethod), tParameter.GetType().Name, tParameter.ToString());
        }
        
        /// <summary>
        /// 打印Object类型值
        /// </summary>
        /// <param name="iParameter"></param>
        public static void ShowObject(object oParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(GenericMethod), oParameter.GetType().Name, oParameter.ToString());
        }
    }
}
