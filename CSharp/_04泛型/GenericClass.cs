using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04泛型
{
    /// <summary>
    /// 一个类满足不同的具体类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericClass<T>
    {
        public T _T;
    }

    /// <summary>
    /// 泛型接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericInterface<T>
    {
        T GetT();
    }

    /// <summary>
    /// 泛型委托
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="t"></param>
    public delegate void SaHi<T>(T t);

    /// <summary>
    /// 普通类继承泛型类/接口必须指定类型
    /// </summary>
    public class CommonClass : GenericClass<int>
    {

    }

    /// <summary>
    /// 泛型类继承泛型类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericClassChild<T> : GenericClass<T>
    {

    }
}
