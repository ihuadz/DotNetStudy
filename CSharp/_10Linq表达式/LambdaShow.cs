using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10Linq表达式
{
    internal class LambdaShow
    {
        public delegate void NoReturnNoPara();
        public delegate void NoReturnWithPara(int x, string y);

        public void Show()
        {
            {
                //1.1 1.0
                NoReturnNoPara method = new NoReturnNoPara(this.DoNothing);
            }
            {
                //2.0
                // 匿名方法
                NoReturnNoPara method = new NoReturnNoPara(delegate ()
                {
                    Console.WriteLine("This is DoNothing");
                });
            }
            {
                //3.0 lambda
                NoReturnNoPara method = new NoReturnNoPara(() =>
                {
                    Console.WriteLine("This is DoNothing");
                });
            }
            {
                NoReturnWithPara method = new NoReturnWithPara((x,y) =>
                {
                    Console.WriteLine("This is DoNothing");
                });
            }
        }

        private void DoNothing()
        {
            Console.WriteLine("This is DoNothing");
        }
    }
}
