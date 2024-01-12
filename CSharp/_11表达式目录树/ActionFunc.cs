using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11表达式目录树
{
    internal class ActionFunc
    {
        public void Show()
        {
            // Action 0dao16个参数的void委托
            Action action = () => { };
            Action<int> action1 = i => Console.WriteLine(i);
            action1(1);

            // Func 0dao16个参数的带返回值委托
            Func<int> func1 = () => 1;
            Func<string,int> func2 = x => Convert.ToInt32(x);
        }
    }
}
