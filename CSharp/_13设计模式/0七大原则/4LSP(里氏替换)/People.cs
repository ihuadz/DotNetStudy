using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13设计模式.LSP
{
    internal class People
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public virtual void Show()
        {
            Console.WriteLine($"{typeof(People).Name} Show");
        }

    }

    internal class Yunnan : People
    {
        public string Flower { get; set; } = string.Empty;

        public override void Show()
        {
            Console.WriteLine($"{typeof(People).Name} Show");
        }
    }
}
