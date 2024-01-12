using _06特性.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _06特性
{
    public class Manager
    {
        public static void Show(Student student)
        {
            // 类的特性
            Type type = typeof(Student);
            if (type.IsDefined(typeof(CustomAttribute),true))
            {
                CustomAttribute attribute = (CustomAttribute)type.GetCustomAttribute(typeof(CustomAttribute));
                Console.WriteLine($"{attribute.Description}_{attribute.Remark}");
                attribute.Show();
            }

            // 属性的特性
            PropertyInfo property = type.GetProperty("Id");
            if (property.IsDefined(typeof(CustomAttribute), true))
            {
                CustomAttribute attribute = (CustomAttribute)type.GetCustomAttribute(typeof(CustomAttribute));
                Console.WriteLine($"{attribute.Description}_{attribute.Remark}");
                attribute.Show();
            }

            // 方法的特性
            MethodInfo method = type.GetMethod("Answer");
            if (method.IsDefined(typeof(CustomAttribute), true))
            {
                CustomAttribute attribute = (CustomAttribute)type.GetCustomAttribute(typeof(CustomAttribute));
                Console.WriteLine($"{attribute.Description}_{attribute.Remark}");
                attribute.Show();
            }

            // 参数的特性
            ParameterInfo parameter = method.GetParameters()[0];
            if (parameter.IsDefined(typeof(CustomAttribute), true))
            {
                CustomAttribute attribute = (CustomAttribute)type.GetCustomAttribute(typeof(CustomAttribute));
                Console.WriteLine($"{attribute.Description}_{attribute.Remark}");
                attribute.Show();
            }

            // 返回值的特性
            ParameterInfo returnParam = method.ReturnParameter;
            if (returnParam.IsDefined(typeof(CustomAttribute), true))
            {
                CustomAttribute attribute = (CustomAttribute)type.GetCustomAttribute(typeof(CustomAttribute));
                Console.WriteLine($"{attribute.Description}_{attribute.Remark}");
                attribute.Show();
            }

            student.Study();
            string result = student.Answer("你好");


            var isValid = student.Validate();
        }
    }
}
