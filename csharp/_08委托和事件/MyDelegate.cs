using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08委托和事件
{
    public class MyDelegate
    {
        
    }

    public delegate void NoReturnNoParams();
    public delegate void NoReturnWithParams(int id);
    public delegate int WithReturnNoParams();
    public delegate int WithReturnWithParams(int id);
}
