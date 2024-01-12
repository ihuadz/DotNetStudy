using _05反射DB.Interface;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _05反射
{
    /// <summary>
    /// 工厂创建
    /// </summary>
    public class DBFactory
    {
        private static string IDBHelperConfig = ConfigurationManager.AppSettings["DBHelper"];
        private static string DllName = IDBHelperConfig.Split(',')[0];
        private static string TypeName = IDBHelperConfig.Split(',')[1];

        /// <summary>
        /// 创建DB对象
        /// </summary>
        /// <returns></returns>
        public static IDBHelper Creat()
        {
            Assembly assembly = Assembly.Load(DllName);//加载dll
            Type type = assembly.GetType(TypeName);//获取类型信息
            object oDbHelper = Activator.CreateInstance(type);//创建对象
            IDBHelper iDbHelper = (IDBHelper)oDbHelper;//类型转换
            return iDbHelper;
        }
    }
}
