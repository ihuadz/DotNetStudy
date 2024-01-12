using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04泛型
{
    public class Model
    {
    }

    public class People
    {
        public string Description = "1234567489";

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public void Hi()
        {
            Console.WriteLine("你好");
        }
    }

    public class PeopleDto
    {
        public string Description = "1234567489";

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public void Hi()
        {
            Console.WriteLine("你好");
        }
    }

    public class Chinese : People
    {
        public virtual void SayHi()
        {
            Console.WriteLine("你好我是中国人");
        }
    }

    public class YunnanMan : Chinese
    {
        public override void SayHi()
        {
            Console.WriteLine("你好我是中国人");
        }
    }

    public interface IPeople
    {

    }
}
