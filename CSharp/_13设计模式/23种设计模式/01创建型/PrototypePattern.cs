using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _13设计模式._23种设计模式._01创建型
{
    /// <summary>
    /// 原型设计模式
    /// </summary>
    /// <remarks>
    /// 在保证性能的同时创建重复对象
    /// </remarks>
    internal class PrototypePattern
    {
        public static void Show()
        {
            Resume resume = new Resume()
            {
                Age = 23,
                Name = "张三",
                experience = new Experience
                {
                    TimeRange = "2015-2018",
                    Company = "华为"
                }
            };

            var resume2 = resume.Clone() as Resume;
            resume2.Age = 28;
            resume2.experience.Company = "腾讯";

            var resume3 = CloneHelper.DeepCopyByReflect(resume);
            resume3.Age = 35;
            resume3.experience.Company = "Bilibili";

            resume.ShowResum();
            resume2.ShowResum();
            resume3.ShowResum();

            //浅拷贝，只复制值类型。引用类型复制的是应用
            //深拷贝，二者都复制，使用this.MemberwiseClone(); 应用类型内部也需要实现ICloneable
            //可以使用反射和序列化实现深拷贝
        }

        class Resume : ICloneable
        {
            public string Name { get; set; } = string.Empty;

            public int Age { get; set; }

            public Experience experience;

            public Resume()
            {
                experience = new Experience();
            }

            /// <summary>
            /// 
            /// </summary>
            public void ShowResum()
            {
                Console.WriteLine($"{Name},{Age}岁");
                Console.WriteLine($"{experience.TimeRange},在{experience.Company}工作");
            }

            /// <summary>
            /// 使用私有构造函数深拷贝
            /// </summary>
            /// <param name="experience"></param>
            private Resume(Experience experience)
            {
                this.experience = (Experience)experience.Clone();
            }

            public object Clone()
            {
                //浅拷贝
                //return this.MemberwiseClone();
                Resume resume = new Resume(this.experience);
                resume.Name = Name;
                resume.Age = Age;
                return resume;
            }
        }

        class Experience : ICloneable
        {
            public string TimeRange { get; set; } = string.Empty;

            public string Company { get; set; } = string.Empty;

            public object Clone()
            {
                return this.MemberwiseClone();
            }
        }

        /// <summary>
        /// 拷贝帮助类
        /// </summary>
        class CloneHelper
        {

            // 使用反射进行深拷贝的方法
            public static T DeepCopyByReflect<T>(T obj)
            {
                //如果是字符串或值类型则直接返回
                if (obj is string || obj.GetType().IsValueType) return obj;
                object retval = Activator.CreateInstance(obj.GetType());
                FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                foreach (FieldInfo field in fields)
                {
                    try { field.SetValue(retval, DeepCopyByReflect(field.GetValue(obj))); }
                    catch { }
                }
                return (T)retval;
            }

            // 使用XML序列化和反序列化进行深拷贝的方法
            static T DeepCopyXml<T>(T source)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, source);
                    stream.Position = 0;
                    return (T)serializer.Deserialize(stream);
                }
            }

            // 使用JSON序列化和反序列化进行深拷贝的方法
            static T DeepCopyJson<T>(T source)
            {
                string jsonString = JsonSerializer.Serialize(source);
                return JsonSerializer.Deserialize<T>(jsonString);
            }
        }
    }
}
