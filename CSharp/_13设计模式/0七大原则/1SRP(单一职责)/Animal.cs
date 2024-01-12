using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13设计模式.SRP
{
    /// <summary>
    /// 封装
    /// 动物类
    /// 简单意味着稳定
    /// </summary>
    internal abstract class Animal
    {
        private string _Name;
        public Animal(string name)
        {
            _Name = name;
        }

        public abstract void Breath();

        public abstract void Action();
    }
}
