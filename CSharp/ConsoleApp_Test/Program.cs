


//C#文档 https://learn.microsoft.com/zh-cn/dotnet/csharp/tour-of-csharp/features

#region 水仙花数
/*for (int i = 100; i <= 999; i++)
{
    var hundreds = i / 100;
    var tens = i % 100 / 10;
    var ones = i % 10;


    if ((Math.Pow(hundreds, 3) + Math.Pow(tens, 3) + Math.Pow(ones, 3)) == i)
    {
        Console.WriteLine(i);
    }

}*/
#endregion

#region 乘法表

/*for (int i = 1; i <= 9; i++)
{
    for (int j = 1; j <= 9; j++)
    {
        Console.Write($"{j}*{i}={i*j}\t");
        if (j >= i) break;
    }
    Console.WriteLine();
}*/

#endregion

#region 冒泡排序

/*int[] nums = { 1, 2, 6, 4, 5, 3, 7, 8, 9 };

for (int i = 0; i < nums.Length; i++)
{
    for (int j = 0; j < nums.Length - 1 - i; j++)
    {
        if (nums[j] > nums[j+1])
        {
            int temp = nums[j];
            nums[j] = nums[j+1];
            nums[j+1] = temp;
        }
    }
    Console.WriteLine(nums[i]);
}*/

#endregion

#region ref关键字使用
/*
// 测试ref
static void RefTest(ref Test1 t1)
{
    t1.id = 1000;
    t1.Name = "测试ref";
}

var t = new Test1
{
    id = 1,
    Name = "Hello World"
};
RefTest(ref t);
Console.WriteLine(t.Name);
*/

#endregion

#region params 使用，只能放在参数列表最后，且只能存在一个
/*static void ParamsTest(string name,params int[] scoce)
{

}*/
#endregion

#region 递归

/*using ConsoleApp_Test;

static void TellStory(int year)
{
    Console.WriteLine("从前有座山");
    Console.WriteLine("山里有座庙");
    Console.WriteLine("庙里有个老和尚和小和尚");
    Console.WriteLine("有一天，小和尚哭了，老和尚和小和尚讲了一个故事：");
    Global.ti++;
    if (Global.ti >= year)
    {
        return;
    }
    TellStory(year);
}

TellStory(10);*/
#endregion

Console.ReadKey();


#region 类
/// <summary>
/// 测试ref
/// </summary>
class Test1
{
    public long id { get; set; }

    public string Name { get; set; }

}
#endregion

interface IInterface1
{
    public void Func1();

    public void Func2();
}

interface IInterface2 : IInterface1
{
    public void Func3();
}