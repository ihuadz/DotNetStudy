// 反射： System.Reflection .Net框架提供帮助类库，可以读取并使用metadata
using _04泛型;
using _05反射;
using _05反射DB.Interface;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("***********反射学习***********");
        try
        {
            Console.WriteLine("***********Reflection + Factory + Config ***********");
            // 实现IOC
            IDBHelper iDbHelper = DBFactory.Creat();
            iDbHelper.Query();

            Console.WriteLine();
            {
                Console.WriteLine("***********Reflection + Object ***********");
                Assembly assembly = Assembly.Load("_05反射");
                Type type = assembly.GetType("_05反射.Singleton");
                Singleton singleton = (Singleton)Activator.CreateInstance(type, true);//反射可调用对象私有构造函数
            }
            Console.WriteLine();

            {
                // 反射调用有参构造函数
                //ReflectionTest
                Assembly assembly = Assembly.Load("_05反射");
                Type type = assembly.GetType("_05反射.ReflectionTest");
                ReflectionTest objReflectionTest = (ReflectionTest)Activator.CreateInstance(type, new object[] { 123 });
                ReflectionTest objReflectionTest2 = (ReflectionTest)Activator.CreateInstance(type, new object[] { 123, "123" });
            }

            Console.WriteLine();

            {
                // 反射创建泛型类
                //ReflectionTest
                Assembly assembly = Assembly.Load("_05反射");
                Type type = assembly.GetType("_05反射.ReflectionGenericTest`3");
                Type newType = type.MakeGenericType(new Type[] { typeof(int), typeof(int), typeof(int) });
                ReflectionGenericTest<int, int, int> objRG = (ReflectionGenericTest<int, int, int>)Activator.CreateInstance(newType);

            }
            {
                Console.WriteLine("***********Reflection + Method ***********");
                // Mvc Controller、filter即利用反射使用URL调用方法
                // 反射调用有参构造函数
                //ReflectionTest
                Assembly assembly = Assembly.Load("_05反射");
                Type type = assembly.GetType("_05反射.ReflectionTest");
                ReflectionTest objReflectionTest = (ReflectionTest)Activator.CreateInstance(type);
                foreach (var item in type.GetMethods())
                {
                    Console.WriteLine(item.Name);
                }
                {
                    MethodInfo method = type.GetMethod("Show");
                    method.Invoke(objReflectionTest, null);
                }
                {
                    // 重载方法
                    MethodInfo method = type.GetMethod("Show1", new Type[] { typeof(int), typeof(string) });
                    method.Invoke(objReflectionTest, new object[] { 123, "456" });
                }
                {
                    //静态方法可以不用实例
                    MethodInfo method = type.GetMethod("Show2");
                    method.Invoke(null, new object[] { 123 });
                }
                {
                    // 重载方法
                    MethodInfo method = type.GetMethod("Show1", new Type[] { typeof(int) });
                    int obj = (int)method.Invoke(objReflectionTest, new object[] { 123 });
                    Console.WriteLine($"调用了有返回值的方法，返回值{obj}");
                }

                {
                    // 私有方法
                    MethodInfo method = type.GetMethod("Show3", BindingFlags.Instance | BindingFlags.NonPublic);
                    method.Invoke(objReflectionTest, new object[] { });
                }

                {
                    // 泛型方法
                    Assembly assembly2 = Assembly.Load("_05反射");
                    Type type2 = assembly.GetType("_05反射.ReflectionGenericTest`3");
                    Type newType2 = type2.MakeGenericType(new Type[] { typeof(int), typeof(int), typeof(int) });
                    ReflectionGenericTest<int, int, int> objRG = (ReflectionGenericTest<int, int, int>)Activator.CreateInstance(newType2);
                    MethodInfo method = newType2.GetMethod("Show");
                    MethodInfo newMethod = method.MakeGenericMethod(new Type[] { typeof(int), typeof(DateTime) });
                    newMethod.Invoke(objRG, new object[] { 123, 456, 789 });
                }
            }

            {
                Console.WriteLine("***********Reflection + Property/FIied ***********");
                // 场景：ORM等
                People people = new People();
                people.Id = 1;
                people.Name = "123";
                Console.WriteLine($"普通获取属性字段：{people.Id}---{people.Name}");

                Type type = typeof(People);
                object oPeaple = Activator.CreateInstance(type);
                foreach (var item in type.GetProperties())
                {

                    if (item.Name == "Id")
                    {
                        Console.WriteLine($"反射获取属性字段：item.Name:{item.GetValue(oPeaple)}");
                        item.SetValue(oPeaple, 2);

                    }

                    if (item.Name == "Name")
                    {
                        Console.WriteLine($"反射获取属性字段：item.Name:{item.GetValue(oPeaple)}");
                        item.SetValue(oPeaple, "456");
                    }
                }
                Console.WriteLine($"利用反射改变值后获取属性字段：{((People)oPeaple).Id}---{((People)oPeaple).Name}");

                foreach (var item in type.GetFields())
                {
                    Console.WriteLine($"反射获取属性字段：item.Name:{item.GetValue(oPeaple)}");
                    if (item.Name == "Description")
                    {

                        item.SetValue(oPeaple, "9854167498456");

                    }
                }
                Console.WriteLine($"利用反射改变值后获取属性字段：{((People)oPeaple).Description}");

                {
                    //使用反射实现Mapster.Adapt
                    People p = new()
                    {
                        Id = 1,
                        Name = "123"
                    };

                    PeopleDto dto = p.Adapt<PeopleDto>();
                    Console.WriteLine($"Adapt后的数据PeopleDto：{dto.Id}，{dto.Name}");
                }
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }

        Console.ReadLine();
    }
}