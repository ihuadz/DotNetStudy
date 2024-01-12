

#region new关键字、虚方法实现多态

Person person = new Person();
person.SayHi();
person.SayHello();

Person person2 = new Xiaoming();
Xiaoming xiaoming = (Xiaoming)person2;
xiaoming.SayHi();
xiaoming.SayHello();

#endregion

#region 求面积周长例子实现多态
Shape cirle = new Circle(5);
Console.WriteLine(cirle.GetArea());
Console.WriteLine(cirle.GetPerimeter());

Shape square = new Square(5,10);
Console.WriteLine(square.GetArea());
Console.WriteLine(square.GetPerimeter());
#endregion


#region 接口用法
IPersonable p = new Xiaohua();
p.Eat();
p.Sleep();
#endregion
Console.ReadKey();

#region 类
/// <summary>
/// 人物基类
/// </summary>
public class Person
{
    /// <summary>
    /// 普通方法
    /// </summary>
    public void SayHi()
    {
        Console.WriteLine("我是人");
    }

    /// <summary>
    /// 虚方法
    /// </summary>
    public virtual void SayHello()
    {
        Console.WriteLine("你好");
    }
}

public class Xiaoming : Person
{
    /// <summary>
    /// 使用new关键字忽略基类同名方法
    /// </summary>
    public new void SayHi()
    {
        Console.WriteLine("我是小明");
    }

    /// <summary>
    /// 重写虚方法实现多态
    /// </summary>
    public override void SayHello()
    {
        Console.WriteLine("你好,我是小明");
    }
}

/// <summary>
/// 形状类
/// </summary>
public abstract class Shape
{
    /// <summary>
    /// 求该形状面积
    /// </summary>
    /// <returns></returns>
    public abstract double GetArea();

    /// <summary>
    /// 求该形状周长
    /// </summary>
    /// <returns></returns>
    public abstract double GetPerimeter();
}
/// <summary>
/// 圆
/// </summary>
public class Circle : Shape
{
    private readonly double _radius;

    public Circle(double radius)
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }

    public override double GetPerimeter()
    {
        return Math.PI * _radius * 2;
    }
}

/// <summary>
/// 矩形
/// </summary>
public class Square : Shape
{
    private readonly double _length;
    private readonly double _width;

    public Square(double length, double width)
    {
        _length = length;
        _width = width;
    }

    public override double GetArea()
    {
        return _length * _width;
    }

    public override double GetPerimeter()
    {
        return (_length + _width) * 2;
    }
}

/// <summary>
/// 
/// </summary>
public class Xiaohua : IPersonable
{
    public void Eat()
    {
        Console.WriteLine("我会吃饭");
    }

    public void Sleep()
    {
        Console.WriteLine("我会睡觉");

    }
}

#endregion

#region 接口

public interface IPersonable
{
    void Eat();

    void Sleep();
}

#endregion