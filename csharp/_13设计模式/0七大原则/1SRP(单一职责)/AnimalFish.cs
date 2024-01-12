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
    internal class AnimalFish : Animal
    {
        private string _Name;
        public AnimalFish(string name) : base(name)
        {

        }

        public override void Breath()
        {
            Console.WriteLine($"{this._Name} 呼吸空气");

        }

        public override void Action()
        {
            Console.WriteLine($"{this._Name} flying");
        }
    }
}
