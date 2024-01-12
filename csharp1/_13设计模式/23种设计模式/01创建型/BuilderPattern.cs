using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13设计模式._23种设计模式._01创建型
{
    /// <summary>
    /// 建造者模式
    /// </summary>
    /// <remarks>
    /// 
    /// 将一个复杂对象的构建和它的表示分离，使得同样的构建过程，可以创建不同的表示
    /// 
    /// 解决的问题：
    /// 在我们软件开发中，有事会面临着”一个复杂对象“的创建工作，通常由各个部分的子对象用一定的算法构成，
    /// 由于需求的变化，这个复杂对象的各个部分也经常面临着剧烈的变化，但是将他们组合到一起却相对稳定
    /// </remarks>
    internal class BuilderPattern
    {
        public static void Show()
        {
            //组装电脑
            IBuilderComputer gCom = new GoodComputer();
            IBuilderComputer bCom = new BadComputer();

            Director directory = new Director();
            directory.BuildComputer(gCom);
            gCom.GetComputer().ShowComputer();

            directory.BuildComputer(bCom);
            bCom.GetComputer().ShowComputer();

        }
    }

    interface IBuilderComputer
    {
        void BuildCpu();

        void BuildDisk();

        void BuildMemory();

        void BuildScreen();

        void BuildSystem();

        Computer GetComputer();
    }


    class GoodComputer : IBuilderComputer
    {
        Computer computer = new Computer();
        public void BuildCpu()
        {
            computer.AddPart("i7CPU");
        }

        public void BuildDisk()
        {
            computer.AddPart("2T固态硬盘");
        }

        public void BuildMemory()
        {
            computer.AddPart("32GB 内存");
        }

        public void BuildScreen()
        {
            computer.AddPart("36寸显示器");
        }

        public void BuildSystem()
        {
            computer.AddPart("Win11系统");
        }

        public Computer GetComputer()
        {
            return computer;
        }
    }

    class BadComputer : IBuilderComputer
    {
        Computer computer = new Computer();
        public void BuildCpu()
        {
            computer.AddPart("i3CPU");
        }

        public void BuildDisk()
        {
            computer.AddPart("256GB机械硬盘");
        }

        public void BuildMemory()
        {
            computer.AddPart("2GB 内存");
        }

        public void BuildScreen()
        {
            computer.AddPart("20寸显示器");
        }

        public void BuildSystem()
        {
            computer.AddPart("Win7系统");
        }

        public Computer GetComputer()
        {
            return computer;
        }
    }

    /// <summary>
    /// 导演类，决定执行顺序
    /// </summary>
    class Director
    {
        public void BuildComputer(IBuilderComputer builderComputer)
        {
            builderComputer.BuildCpu();
            builderComputer.BuildDisk();
            builderComputer.BuildMemory();
            builderComputer.BuildScreen();
            builderComputer.BuildSystem();
        }
    }

    class Computer
    {
        List<string> listPart = new List<string>();

        public void AddPart(string part)
        {
            listPart.Add(part);
        }

        public void ShowComputer()
        {
            foreach (string part in listPart)
            {
                Console.WriteLine("正在安装" + part);
            }
        }
    }
}
