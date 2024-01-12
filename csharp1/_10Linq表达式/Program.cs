namespace _10Linq表达式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******Linq*******");

            #region 扩展方法
            Student student = new()
            {
                Id = 1,
                Name = "ss"
            };
            student.Study();
            student.Sing();
            #endregion

            #region Linq操作

            // 两种操作一样，关键字方式编译会转为调用方法的模式
            var students = LinqShow.GetStudents();

            var s = students.Where(x => x.Id == 3).FirstOrDefault();

            var s2 = from x in students where x.Id == 3 select x;
                     

            #endregion
        }
    }
}