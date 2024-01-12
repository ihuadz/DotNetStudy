using _04泛型;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _05反射
{
    public static class Mapster
    {
        /// <summary>
        /// 使用反射实现Adapt对象适应方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T Adapt<T>(this People obj)
        {
            if (obj == null)
                return default;

            Type typeT = typeof(T);
            Type typeObj = obj.GetType();

            object t = Activator.CreateInstance(typeT);
            foreach (var item in typeT.GetProperties())
            {
                var value = typeObj.GetProperty(item.Name).GetValue(obj);
                item.SetValue(t, value);
            }

            return (T)t;
        }
    }
}
