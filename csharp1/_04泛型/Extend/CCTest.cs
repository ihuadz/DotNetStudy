using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04泛型.Extend
{
    /// <summary>
    /// 协变、逆变
    /// 只能用在接口、委托
    /// </summary>
    public class CCTest
    {
        IMyList<Sparrow,Bird> myList = new MyList<Sparrow,Bird>();
        IMyList<Sparrow, Bird> myList1 = new MyList<Sparrow, Sparrow>();//协变
        IMyList<Sparrow, Bird> myList2 = new MyList<Bird, Bird>();//逆变
        IMyList<Sparrow, Bird> myList3 = new MyList<Bird, Sparrow>();//逆变+协变
    }

    public class Bird
    {
        public int Id { get; set; }
    }

    public class Sparrow : Bird
    {
        public string Name { get; set; } = string.Empty;
    }

    /// <summary>
    /// 协变out关键字，只能做返回值
    /// 逆变in关键字，只能做参数
    /// </summary>
    /// <typeparam name="inT"></typeparam>
    /// <typeparam name="outT"></typeparam>
    public interface IMyList<in inT,out outT>
    {
        void ReadT(inT t);

        outT GetT();
    }

    public class MyList<T1,T2> : IMyList<T1,T2>
    {
        public void ReadT(T1 t)
        {
            throw new NotImplementedException();
        }

        T2 IMyList<T1, T2>.GetT()
        {
            throw new NotImplementedException();
        }
    }
}
