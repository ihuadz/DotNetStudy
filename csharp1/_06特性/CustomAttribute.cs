using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06特性
{
    /// <summary>
    /// 自定义特性
    /// 编译后会在IL内表现，会在metadata中有记录
    /// AttributeTargets 修饰限制
    /// AllowMultiple 可以多重修饰 
    /// Inherited 是否可继承
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public class CustomAttribute : Attribute
    {
        public CustomAttribute()
        {

        }

        public CustomAttribute(int id)
        {

        }

        public string Description { get; set; }

        public string Remark = null;

        public void Show()
        {
            Console.WriteLine($"this is {nameof(CustomAttribute)}");
        }
    }
}
