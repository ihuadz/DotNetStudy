using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05反射
{
    /// <summary>
    /// 反射调用泛型类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class ReflectionGenericTest<T,T1,T2>
    {
        public ReflectionGenericTest()
        {
            Console.WriteLine($"调用ReflectionGenericTest成功，传入类型{typeof(T)},{typeof(T1)},{typeof(T2)}");
        }

        public void Show<T3,T4>(T t,T1 t1,T2 t2)
        {
            Console.WriteLine($"调用泛型方法成功,传入类型{typeof(T3)},{typeof(T4)},传入参数{t},{t1},{t2}");
        }
    }
}
