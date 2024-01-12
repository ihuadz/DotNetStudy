using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _13设计模式._23种设计模式._01创建型
{
    /// <summary>
    /// 懒汉式
    /// </summary>
    internal class SingleLazyManPattern
    {
        public static void Show()
        {
            //var singleLazyMan1 = SingleLazyMan.GetSingleLazyMan();
            //var singleLazyMan2 = SingleLazyMan.GetSingleLazyMan();
            //var singleLazyMan3 = SingleLazyMan.GetSingleLazyMan();

            //Console.WriteLine("singleLazyMan1-hashValue:" + singleLazyMan1.GetHashCode());
            //Console.WriteLine("singleLazyMan2-hashValue:" + singleLazyMan2.GetHashCode());
            //Console.WriteLine("singleLazyMan3-hashValue:" + singleLazyMan3.GetHashCode());

            // 懒汉式对象，只有当你调用方法的时候才能创建对象，节约了资源

            //问题：多线程模式会有线程安全问题
            //会被创建多次,需要加锁
            //for (int i = 0; i < 10; i++)
            //{
            //    new Thread(() => SingleLazyMan.GetSingleLazyMan()).Start();
            //}

            //通过反射破坏单例
            //1、创建单例
            //SingleLazyMan lazy1 = SingleLazyMan.GetSingleLazyMan();

            //2、反射破坏单例
            //Type t = typeof(SingleLazyMan);
            ////获取私有构造函数
            //ConstructorInfo[] cons = t.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
            //SingleLazyMan lazy1 = (SingleLazyMan)cons[0].Invoke(null);
            //SingleLazyMan lazy2 = (SingleLazyMan)cons[0].Invoke(null);

            //Console.WriteLine("SingleLazyMan1:" + lazy1.GetHashCode());
            //Console.WriteLine("SingleLazyMan2:" + lazy2.GetHashCode());

            //加入isOK标记一定程度避免了反射破环，但是还是可以使用反射修改isOK的值
            //反射破坏基本无解

        }

        public class SingleLazyMan
        {

            private static bool isOk = false;

            //1、构造函数私有化
            private SingleLazyMan()
            {
                //存在多个反射创建的情况，只有第一个会被执行，使用标记位 isOk 拦截
                lock (_lock)
                {
                    if (isOk == false)
                    {
                        isOk = true;
                    }
                    else
                    {
                        throw new Exception("阻止了反射破环单例！");
                    }
                }

                //lock (_lock)
                //{
                //    if (_singleLazyMan != null)
                //    {
                //        throw new Exception("阻止了反射破环单例！");
                //    }
                //}
            }

            //2、声明静态字段，存储我们唯一的对象
            //volatile 标记字段是不稳定的，不确定的
            //目的：避免指令重排
            //指令重排：在new一个对象时 执行步骤：1、开辟空间 2、创建对象 3、将空间指向对象
            //        正常情况的执行步骤为123，多线程的某些特殊情况会出现132，导致返回一个无用对象
            //        为了避免这一种情况添加volatile标记可解决
            private volatile static SingleLazyMan? _singleLazyMan;

            //创建锁，解决线程安全
            private static object _lock = new object();

            //3、创建一个方法，实现对外提供获取类唯一对象的能力
            public static SingleLazyMan GetSingleLazyMan()
            {

                //双重锁，不加双重锁会消耗系统资源，每一个线程进来都会去访问锁
                if (_singleLazyMan == null)
                {
                    //lock 是C#提供的语法糖
                    //实际调用Monitor.Enter() Monitor.Exit()互斥锁 用于解决多线程的安全问题
                    lock (_lock)
                    {
                        //在调用方法之前要判断，有没有类的实例，如果没有则创建并返回
                        if (_singleLazyMan == null)
                        {
                            _singleLazyMan = new SingleLazyMan();
                            Console.WriteLine("我被执行了一次");
                        }
                    }
                }
                return _singleLazyMan;
            }
        }
    }
}
