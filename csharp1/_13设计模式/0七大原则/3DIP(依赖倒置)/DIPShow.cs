using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13设计模式.DIP
{
    /// <summary>
    /// 依赖倒置原则（Dependence Inversion Principle,简称DIP）
    /// 高层模块（调用者）不应该依赖于底层模块（被调用者），二者应该通过抽象依赖
    /// 依赖抽象，而不是依赖细节
    /// 面向抽象编程
    /// 
    /// 抽象：
    /// 
    /// 依赖细节：程序写死了，不谈什么扩展
    /// 依赖抽象：更具有通用性，而且具备扩展性
    /// 细节多点的，抽象是稳定的；系统架构基于抽象来搭建，会更稳定更具备扩展性
    /// 
    /// 面向抽象变成，底层模块里面尽量都有抽象类/接口
    /// 在声明参数/变量/属性的时候，尽量的都是 接口/抽象类
    /// 
    /// 在客户类中（高层模块），定义一个注入点，用来注入我们的服务类（底层模块）
    /// </summary>
    internal class DIPShow
    {
        public static void Show()
        {
            //歌手歌曲

            //歌手：唱歌
            //歌曲:返回歌词
            Singer singer = new Singer();
            singer.SingASong(new ChineseSong());
            singer.SingASong(new EnglishSong());

        }
    }

    interface ISongWords
    {
        string GetSongWords();
    }

    class ChineseSong : ISongWords
    {
        public string GetSongWords()
        {
            return "中国歌曲";
        }
    }

    class EnglishSong : ISongWords
    {
        public string GetSongWords()
        {
            return "英文歌曲";
        }
    }

    class Singer
    {
        public void SingASong(ISongWords songWords)
        {
            Console.WriteLine("歌手正在唱" + songWords.GetSongWords());
        }
    }
}
