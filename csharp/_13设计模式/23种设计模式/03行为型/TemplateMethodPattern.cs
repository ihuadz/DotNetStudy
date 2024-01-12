using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13设计模式._23种设计模式._03行为型
{
    /// <summary>
    /// 模板方法模式
    /// </summary>
    /// <remarks>
    /// 定义一个操作中的算法的框架，而将一些步骤延迟到子类中，是的子类可以不改变一个算法的结构即可重定义该算法的某些特定步骤
    /// </remarks>
    internal class TemplateMethodPattern
    {
        public static void Show()
        {
            //汽车模型
            HummerH1Model h1 = new();
            h1.SetAlarm(false);
            h1.Run();

            HummerH2Model h2 = new();
            h2.Run();
        }
    }

    abstract class HummerModel
    {
        private bool alarmFlag = true;

        /// <summary>
        /// 启动
        /// </summary>
        protected abstract void Start();

        /// <summary>
        /// 停止
        /// </summary>
        protected abstract void Stop();

        /// <summary>
        /// 鸣笛
        /// </summary>
        protected abstract void Alarm();

        /// <summary>
        /// 引擎启动
        /// </summary>
        protected abstract void EngineBoom();

        /// <summary>
        /// 跑起来, 这个就是模板方法
        /// </summary>
        public void Run()
        {
            this.Start();
            this.EngineBoom();
            if (alarmFlag)
            {
                this.Alarm();
            }
            this.Stop();

        }

        /// <summary>
        /// 钩子方法，默认可鸣笛
        /// </summary>
        /// <returns></returns>
        protected void SetAlarm(bool isAlarm)
        {
            alarmFlag = isAlarm;
        }


    }

    class HummerH1Model : HummerModel
    {
        private bool alarmFlag = true;

        protected override void Alarm()
        {
            Console.WriteLine("悍马H1鸣笛...");
        }

        protected override void EngineBoom()
        {
            Console.WriteLine("悍马H1引擎声音...");
        }

        protected override void Start()
        {
            Console.WriteLine("悍马H1启动...");
        }

        protected override void Stop()
        {
            Console.WriteLine("悍马H1停止...");
        }

        /// <summary>
        /// 客户端设置是否鸣笛
        /// </summary>
        /// <param name="isAlarm"></param>
        public new void SetAlarm(bool isAlarm)
        {
            base.SetAlarm(isAlarm);
        }
    }

    class HummerH2Model : HummerModel
    {
        public HummerH2Model()
        {
            base.SetAlarm(false);
        }

        protected override void Alarm()
        {
            Console.WriteLine("悍马H2鸣笛...");
        }

        protected override void EngineBoom()
        {
            Console.WriteLine("悍马H2引擎声音...");
        }

        protected override void Start()
        {
            Console.WriteLine("悍马H2启动...");
        }

        protected override void Stop()
        {
            Console.WriteLine("悍马H2停止...");
        }
    }
}
