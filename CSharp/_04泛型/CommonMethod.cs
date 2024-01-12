using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04泛型
{
    /// <summary>
    /// 公用方法
    /// 泛型概念出现前使用的方法
    /// </summary>
    public class CommonMethod
    {
        /// <summary>
        /// 打印int类型值
        /// </summary>
        /// <param name="iParameter"></param>
        public static void ShowInt(int iParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod), iParameter.GetType().Name,iParameter.ToString());
        }

        /// <summary>
        /// 打印String类型值
        /// </summary>
        /// <param name="sParameter"></param>
        public static void ShowString(string sParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod), sParameter.GetType().Name, sParameter.ToString());
        }

        /// <summary>
        /// 打印DateTime类型值
        /// </summary>
        /// <param name="iParameter"></param>
        public static void ShowDateTime(DateTime dtParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod), dtParameter.GetType().Name, dtParameter.ToString());
        }

        /// <summary>
        /// 打印Object类型值,此方法会产生装箱拆箱操作，影响性能
        /// </summary>
        /// <param name="iParameter"></param>
        public static void ShowObject(object oParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod), oParameter.GetType().Name, oParameter.ToString());
        }
    }
}
