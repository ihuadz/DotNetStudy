using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13设计模式._23种设计模式._02结构型
{
    /// <summary>
    /// 组合设计模式
    /// </summary>
    /// <remarks>
    /// 将对象组合成树状结构以表示“部分-整体”的层次结构
    /// 组合模式也叫合成模式，有时又叫做部分-整体模式，主要是用来描述部分与整体的关系
    /// 
    /// 优点：高层模块调用简单，节点自由增加
    /// 缺点：高层模块需要知道组合中的所有类，不太容易限制容器中的构件，与依赖倒置原则冲突
    /// </remarks>
    internal class CompositePattern
    {
        public static void Show()
        {
            //Component 树根
            //Composite 树枝
            //Leaf 树叶

            Component com = new DepartmentComposite("云南招聘网");

            Component dept1 = new DepartmentComposite("技术中心");

            Employee emp = new("huadz");

            com.Add(dept1);
            dept1.Add(emp);

            com.Display(3);
        }

        abstract class Component
        {
            public string Name;

            public Component(string name)
            {
                Name = name;
            }

            public abstract void Add(Component component);
            public abstract void Remove(Component component);
            public abstract void Display(int depth);
        }

        class DepartmentComposite : Component
        {
            private List<Component> _components;
            public DepartmentComposite(string name) : base(name)
            {
                _components = new List<Component>();
            }

            public override void Add(Component component)
            {
                _components.Add(component);
            }

            public override void Display(int depth)
            {
                Console.WriteLine($"{new String('-', depth)}{this.Name}");
                foreach (Component component in _components)
                {
                    component.Display(depth + 4);
                }
            }

            public override void Remove(Component component)
            {
                _components.Remove(component);
            }
        }

        class Employee : Component
        {
            public Employee(string name) : base(name)
            {
            }

            [Obsolete("该方法已失效")]
            public override void Add(Component component)
            {
                throw new NotImplementedException();
            }

            public override void Display(int depth)
            {
                Console.WriteLine($"{new String('-', depth)}{this.Name}");
            }

            [Obsolete("该方法已失效")]
            public override void Remove(Component component) => throw new NotImplementedException();
        }
    }
}
