using _07面向对象MyOO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07面向对象MyOO.Service
{
    /// <summary>
    /// 苹果手机
    /// </summary>
    public class Huawei : BasePhone, IExtend
    {
        public override void System()
        {
            Console.WriteLine($"{this.GetType().Name} System is Huawei");
        }

        public void Video()
        {
            throw new NotImplementedException();
        }
    }
}
