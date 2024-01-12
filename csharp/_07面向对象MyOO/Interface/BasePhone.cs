using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07面向对象MyOO.Interface
{
    /// <summary>
    /// 手机基类，抽象类
    /// </summary>
    public abstract class BasePhone
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Branch { get; set; } = string.Empty;

        public void Call()
        {
            Console.WriteLine($"Use {this.GetType().Name} Call");
        }

        public void Text()
        {
            Console.WriteLine($"Use {this.GetType().Name} Text");
        }

        public abstract void System();
    }
}
