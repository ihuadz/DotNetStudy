using _05反射DB.Interface;

namespace _05反射DB.Mysql
{
    public class MysqlHelper : IDBHelper
    {
        public MysqlHelper()
        {
            Console.WriteLine("MysqlHelper已创建");
        }

        public void Query()
        {
            Console.WriteLine("MysqlHelper.Query");
        }
    }
}