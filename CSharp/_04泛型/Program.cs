// See https://aka.ms/new-console-template for more information
using _04泛型;
using _04泛型.Extend;
using Monitor = _04泛型.Monitor;

try
{
    Console.WriteLine("****************泛型练习*************");

    Console.WriteLine();
    Console.WriteLine();

    Console.WriteLine("****************CommonMethod*************");
    CommonMethod.ShowInt(123);
    CommonMethod.ShowString("567");
    CommonMethod.ShowDateTime(DateTime.Now);
    object obj = new
    {
        name = "lihua"
    };
    CommonMethod.ShowObject(obj);

    Console.WriteLine("****************CommonMethod*************");

    GenericMethod.Show(123);
    GenericMethod.Show("567");
    GenericMethod.Show(DateTime.Now);
    GenericMethod.Show(obj);

    Console.WriteLine("****************Monitor*************");
    Monitor.Show();

    Console.WriteLine();

    Console.WriteLine("****************GenericCacheTest*************");
    GenericCacheTest.Show();
}
catch (Exception ex)
{

    Console.WriteLine(ex);
}

Console.ReadKey();

