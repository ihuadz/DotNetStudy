using _05反射DB.Interface;

namespace _05反射DB.SqlServer
{
    public class SqlServerHelper:IDBHelper
    {
        public SqlServerHelper()
        {
            Console.WriteLine("SqlServerHelper");
        }

        public void Query()
        {
            Console.WriteLine("SqlServerHelper.Query");
        }
    }
}