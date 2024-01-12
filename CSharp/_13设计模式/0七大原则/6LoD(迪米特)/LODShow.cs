using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13设计模式.LoD
{
    /// <summary>
    /// 迪米特法则（Law of Demeter,简称LoD） 最少知识原则
    /// 一个对象应该对其他对象保持最少的了解
    /// 面向对象--类--类鱼类之间会有交互--功能模块--系统
    /// 高内聚，低耦合：高度封装，类与类之间减少依赖
    /// 耦合关系：依赖、关联、组合、聚合  继承 实现
    /// 只与直接的朋友通信
    /// 
    /// 去掉内部依赖--降低访问修饰符
    /// 门面（外观）模式/中介者模式
    /// </summary>
    internal class LODShow
    {
        public static void Show()
        {
            {
                //关机操作
                //对象：人、电脑
                Person person = new Person();
                person.CloseComputer();
            }

            {
                //分别打印总公司员工的ID和分公司员工ID

                //class1:总公司员工类
                //class2:总公司员工管理类
                //获取总公司所有员工
                //打印总公司所有员工
                Console.WriteLine("总公司员工工号：");
                HeadOfficeEmployeeManager headOfficeEmployeeManager = new HeadOfficeEmployeeManager();
                var headOfficeEmployees = headOfficeEmployeeManager.GetHeadOfficeEmployees();
                headOfficeEmployeeManager.Print(headOfficeEmployees);

                //class3:分公司员工类
                //class4:分公司员工管理
                //获取分公司所有员工
                //打印分公司所有员工
                Console.WriteLine("分公司员工工号：");
                BranchOfficeEmployeeManager branchOfficeEmployeeManager = new BranchOfficeEmployeeManager();
                var branchOfficeEmployees = branchOfficeEmployeeManager.GetHeadOfficeEmployees();
                branchOfficeEmployeeManager.Print(branchOfficeEmployees);
            }

        }
    }

    class Computer
    {
        private void PressCloseBtn()
        {
            Console.WriteLine("按下关闭按钮");
        }

        private void SaveProgram()
        {
            Console.WriteLine("保存应用程序");
        }

        private void CloseCreen()
        {
            Console.WriteLine("按下关闭屏幕");
        }

        private void ClosePower()
        {
            Console.WriteLine("关闭电源");
        }

        public void Close()
        {
            PressCloseBtn();
            SaveProgram();
            CloseCreen();
            ClosePower();
        }
    }
    class Person
    {
        public void CloseComputer()
        {
            Computer computer = new Computer();
            computer.Close();
        }
    }

    class HeadOfficeEmployee
    {
        public long ID { get; set; }
    }

    class BranchOfficeEmployee
    {
        public long ID { get; set; }
    }

    class HeadOfficeEmployeeManager
    {
        public List<HeadOfficeEmployee> GetHeadOfficeEmployees()
        {
            var lst = new List<HeadOfficeEmployee>();
            for (int i = 0; i < 10; i++)
            {
                lst.Add(new HeadOfficeEmployee { ID = i });
            }
            return lst;
        }

        public void Print(List<HeadOfficeEmployee> emps)
        {
            foreach (var item in emps)
            {
                Console.WriteLine(item.ID);
            }
        }
    }

    class BranchOfficeEmployeeManager
    {
        public List<BranchOfficeEmployee> GetHeadOfficeEmployees()
        {
            var lst = new List<BranchOfficeEmployee>();
            for (int i = 0; i < 5; i++)
            {
                lst.Add(new BranchOfficeEmployee { ID = i });
            }
            return lst;
        }

        public void Print(List<BranchOfficeEmployee> emps)
        {
            foreach (var item in emps)
            {
                Console.WriteLine(item.ID);
            }
        }
    }
}
