using _06特性.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06特性
{

    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    [Custom(123,Description = "自定义", Remark = "测试")]
    public class Student
    {
        [Custom]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [LongAtrribute(10000,999999999)]
        public long QQ { get; set; }

        public void Study()
        {
            Console.WriteLine("学习");
        }

        [Custom]
        [return: Custom]
        public string Answer([Custom]string name)
        {
            return $"this is {name}";
        }
    }
}
