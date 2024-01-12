using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13设计模式.七大原则.DIP_依赖倒置_
{
    /// <summary>
    /// 依赖注入方式
    /// </summary>
    /// <remarks>
    /// 1、接口注入
    /// 2、构造方法
    /// 3、set构造器
    /// </remarks>
    internal class DIPShow2
    {
        public static void Show()
        {
            {
                //接口注入
                Person person = new Person();
                person.Driver(new Benz());
            }

            {
                //构造器注入
                Person1 person = new Person1(new Benz());
                person.Driver();
            }

            {
                //set方法注入
                Person2 person = new Person2();
                person.Set(new Benz());
                person.Driver();
            }
        }
    }

    interface ICar
    {
        void Run();
    }

    /// <summary>
    /// 接口注入
    /// </summary>
    interface IDriver
    {
        void Driver(ICar car);
    }

    /// <summary>
    /// 构造器注入
    /// </summary>
    interface IDriver1
    {
        void Driver();
    }

    /// <summary>
    /// 构造器注入
    /// </summary>
    interface IDriver2
    {
        void Set(ICar car);

        void Driver();
    }

    class Benz : ICar
    {
        public void Run()
        {
            Console.WriteLine("奔驰在奔跑");
        }
    }

    /// <summary>
    /// 接口注入
    /// </summary>
    class Person : IDriver
    {
        public void Driver(ICar car)
        {
            car.Run();
        }
    }

    /// <summary>
    /// 构造器注入
    /// </summary>
    class Person1 : IDriver1
    {
        readonly ICar _car;
        public Person1(ICar car)
        {
            this._car = car;
        }

        public void Driver()
        {
            this._car.Run();
        }
    }

    /// <summary>
    /// set方法注入
    /// </summary>
    class Person2 : IDriver2
    {

        ICar? _car;

        public void Set(ICar car)
        {
            _car = car;
        }

        public void Driver()
        {
            this._car?.Run();
        }
    }
}
