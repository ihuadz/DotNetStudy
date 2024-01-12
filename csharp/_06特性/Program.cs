// 没有破坏类型封装的前提下，可以加点额外的信息和行为
// 特性不主动使用（反射）不会生效
using _06特性;
using _06特性.Extend;

Console.WriteLine("************特性Attribute学习************");


Student student = new()
{
    Id = 1,
    Name = "李华",
    QQ = 123456
};

student.Study();
student.Answer("李华");


Manager.Show(student);

{
    UserState userState = UserState.Normal;
    Console.WriteLine(userState.GetRemark());
    Console.WriteLine(UserState.Frozen.GetRemark());
    Console.WriteLine(UserState.Deleted.GetRemark());

}