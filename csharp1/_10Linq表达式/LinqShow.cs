using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10Linq表达式
{
    /// <summary>
    /// Linq To Object（Enumerable）
    /// 完成对数据的操作，通过委托封装完成通用代码，泛型+迭代器去提供特性
    /// 
    /// Linq To Sql（Queryable） SQL+ADO.NET，通过表达式目录树解析SQL
    /// </summary>
    public static class LinqShow
    {

        public static List<Student> GetStudents()
        {
            var lstStudent = new List<Student>();
            for (int i = 0; i < 100; i++)
            {
                lstStudent.Add(new Student()
                {
                    Name = i.ToString(),
                    Age = 12,
                    Id = i
                });
            }
            return lstStudent; 
        }
    }
}
