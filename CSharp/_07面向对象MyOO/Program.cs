// 1 面向对象Object Oriented    OOP
// 2 封装继承多态--抽象
//   封装：把客观事物封装成抽象的类，并且类可以把自己的数据和方法只让可信的类或者对象操作，对不可信的进行信息隐藏
//     作用：数据安全；内部修改保持稳定；提供重用性；分工合作；方便构建大型复杂系统
//   继承：可以让某个类型的对象获得另一个类型的对象的属性的方法
//     作用：去掉重复代码；可以实现多态
//   多态：指一个类实例的相同方法在不同情形有不同表现形式
//     类型：方法重载、接口&实现、抽象类&实现、继承（重写）
//     作用：
//   抽象：
// 3 重写overwrite(new) 覆写override 重载overload
// 4 抽象类接口

// 用手机玩游戏
#region 面向过程
using _07面向对象MyOO;
using _07面向对象MyOO.Interface;
using _07面向对象MyOO.Service;
{
    Console.WriteLine("拥有一个手机");
    Console.WriteLine("开机");
    Console.WriteLine("启动游戏");
    Console.WriteLine("玩游戏");
    Console.WriteLine("游戏结束");
}

#endregion

#region 面向对象
{

    Player player = new()
    {
        Id = 123,
        Name = "K"
    };
    player.PlayPhone(new iPhone());

    // 运行时多态
    // 
    {
        BasePhone phone = new iPhone();
        phone.Call();
        phone.System();
        //phone.Video(); // 编译器不支持，运行时可调用， 强制转换或者使用dynamic可调用
    }
    {
        IExtend phone = new iPhone();
        //phone.Call();
        phone.Video();
    }

    // 如何选择抽象类和接口
    // 接口：纯粹的约束     多实现更灵活
    // 抽象类：父类加约束   单根性，只能单继承
}
#endregion

