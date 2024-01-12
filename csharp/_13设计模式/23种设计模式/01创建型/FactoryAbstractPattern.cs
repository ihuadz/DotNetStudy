using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _13设计模式._23种设计模式._01创建型
{
    /// <summary>
    /// 抽象工厂
    /// </summary>
    internal class FactoryAbstractPattern
    {
        public static void Show()
        {
            ReflectionDBAndUserDactory reflectionDBAndUserDactory = new ReflectionDBAndUserDactory();

            Console.WriteLine("请输入数据库名称：");
            var dbName = Console.ReadLine();
            var fac = reflectionDBAndUserDactory.GetDBFactory(dbName);

            User user = new User();
            user.ID = 1;
            user.Name = "张三";

            Department dept = new Department();
            user.ID = 1;
            user.Name = "部门1";


            //更换数据库MSSQL MySQL PGSQL
            IDBFactory dBFactory = fac;
            IDBUser dBUser = dBFactory.GetDBUser();
            dBUser.InsertUser(user);
            dBUser.QueryUser(user.ID);

            IDBDepartment dBDepartment = dBFactory.GetDBDepartment();
            dBDepartment.InsertDepartment(dept);
            dBDepartment.QueryDepartment(dept.ID);
        }

    }

    class User
    {
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;
    }

    class Department
    {
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;
    }

    /// <summary>
    /// 数据库名称特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    class DBAttribute : Attribute
    {
        public string DBName { get; }
        public DBAttribute(string dBName)
        {
            DBName = dBName;
        }
    }

    /// <summary>
    /// 表名称特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    class EntityAttribute : Attribute
    {
        public string Name { get; }
        public EntityAttribute(string name)
        {
            Name = name;
        }
    }

    class ReflectionDBAndUserDactory
    {
        Dictionary<string, IDBFactory> dbFac = new();

        public ReflectionDBAndUserDactory()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (var item in assembly.GetTypes())
            {
                if (typeof(IDBFactory).IsAssignableFrom(item) && !item.IsInterface)
                {
                    DBAttribute da = item.GetCustomAttribute<DBAttribute>();
                    if (da != null)
                    {
                        dbFac[da.DBName] = Activator.CreateInstance(item) as IDBFactory;
                    }

                }
            }
        }

        public IDBFactory GetDBFactory(string dbName)
        {
            if (dbFac.TryGetValue(dbName, out IDBFactory? fac))
            {
                if (fac == null) throw new Exception("数据库不支持");

                return fac;
            }

            throw new Exception("数据库不支持");
        }
    }

    interface IDBFactory
    {
        IDBUser GetDBUser();
        IDBDepartment GetDBDepartment();
    }

    interface IDBUser
    {
        void InsertUser(User user);

        void QueryUser(int ID);
    }

    interface IDBDepartment
    {
        void InsertDepartment(Department dept);

        void QueryDepartment(int ID);
    }

    class MSSQLUser : IDBUser
    {
        public void InsertUser(User user)
        {
            Console.WriteLine($"MSSQL插入了{user.Name}");
        }

        public void QueryUser(int ID)
        {
            Console.WriteLine($"MSSQL查询{ID}的用户");
        }
    }

    class MYSQLUser : IDBUser
    {
        public void InsertUser(User user)
        {
            Console.WriteLine($"MYSQL插入了{user.Name}");
        }

        public void QueryUser(int ID)
        {
            Console.WriteLine($"MYSQL查询{ID}的用户");
        }
    }

    class PGUser : IDBUser
    {
        public void InsertUser(User user)
        {
            Console.WriteLine($"PG插入了{user.Name}");
        }

        public void QueryUser(int ID)
        {
            Console.WriteLine($"PG查询{ID}的用户");
        }
    }

    class MSSQLDepartment : IDBDepartment
    {
        public void InsertDepartment(Department dept)
        {
            Console.WriteLine($"MSSQL插入了{dept.Name}");
        }

        public void QueryDepartment(int ID)
        {
            Console.WriteLine($"MSSQL查询{ID}的部门");
        }
    }

    class MYSQLDepartment : IDBDepartment
    {
        public void InsertDepartment(Department dept)
        {
            Console.WriteLine($"MYSQL插入了{dept.Name}");
        }

        public void QueryDepartment(int ID)
        {
            Console.WriteLine($"MYSQL查询{ID}的部门");
        }
    }
    class PGDepartment : IDBDepartment
    {
        public void InsertDepartment(Department dept)
        {
            Console.WriteLine($"PG插入了{dept.Name}");
        }

        public void QueryDepartment(int ID)
        {
            Console.WriteLine($"PG查询{ID}的部门");
        }
    }

    [DB("MSSQL")]
    class MSSQLFactory : IDBFactory
    {
        [Entity("Department")]
        public IDBDepartment GetDBDepartment()
        {
            return new MSSQLDepartment();
        }

        [Entity("User")]
        public IDBUser GetDBUser()
        {
            return new MSSQLUser();
        }
    }

    [DB("MYSQL")]
    class MYSQLFactory : IDBFactory
    {

        [Entity("Department")]
        public IDBDepartment GetDBDepartment()
        {
            return new MYSQLDepartment();
        }

        [Entity("User")]
        public IDBUser GetDBUser()
        {
            return new MYSQLUser();
        }
    }

    [DB("PG")]
    class PGFactory : IDBFactory
    {
        [Entity("Department")]
        public IDBDepartment GetDBDepartment()
        {
            return new PGDepartment();
        }

        [Entity("User")]
        public IDBUser GetDBUser()
        {
            return new PGUser();
        }
    }


}
