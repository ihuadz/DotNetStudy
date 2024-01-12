using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05反射
{
    /// <summary>
    /// 反射测试，调用有参构造方法
    /// </summary>
    public class ReflectionTest
    {
        public ReflectionTest()
        {

        }


        public ReflectionTest(int param)
        {
            Console.WriteLine($"调用ReflectionTest(int param)成功，参数{param}");
        }

        public ReflectionTest(int param,string param2)
        {
            Console.WriteLine($"调用ReflectionTest(int param,string param2)成功，参数{param}，{param2}");
        }

        public void Show()
        {
            Console.WriteLine($"调用了无参方法ReflectionTest.Show");
        }

        public void Show1(int param,string param2)
        {
            Console.WriteLine($"调用了方法ReflectionTest.Show,参数{param}，{param2}");
        }

        public static void Show2(int param)
        {
            Console.WriteLine($"调用了静态方法ReflectionTest.Show2,参数{param}");

        }

        public int Show1(int param)
        {
            Console.WriteLine($"调用了方法ReflectionTest.Show1,参数{param}，返回值{param}");

            return param;
        }

        private void Show3()
        {
            Console.WriteLine($"调用了私有方法ReflectionTest.Show3");
        }
    }
}
