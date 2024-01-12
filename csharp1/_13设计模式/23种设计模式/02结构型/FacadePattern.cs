using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13设计模式._23种设计模式._02结构型
{

    /// <summary>
    /// 外观设计模式
    /// </summary>
    /// <remarks>
    /// 要求一个子系统的外部与其内部的通信必须通过一个统一的对象进行。外观模式提供一个高层次的接口，使得子系统更易于使用。
    /// 
    /// 优点：减少系统的相互依赖，提高了灵活性，提高了安全性
    /// 缺点：不符合开闭原则
    /// </remarks>
    internal class FacadePattern
    {
        public static void Show()
        {

            // 1、不使用外观模式
            {
                ILetterProcess letterProcess = new LetterProcessImpl();
                letterProcess.WriteContext("Hello,It's me,do you know who I am? I'm your old lover.I'd like to....");
                letterProcess.FillEnvelope("Happy Road No. 666,God Province,Heaven");
                letterProcess.LetterIntoEnvelope();
                letterProcess.SendLetter();
            }

            // 2、使用外观模式
            {
                ModenPostOffice modenPostOffice = new ModenPostOffice();
                modenPostOffice.SendLetter("Hello,It's me,do you know who I am? I'm your old lover.I'd like to....", "Happy Road No. 666,God Province,Heaven");
            }
        }
    }

    /// <summary>
    /// 信件处理接口
    /// </summary>
    internal interface ILetterProcess
    {
        void WriteContext(string context);

        void FillEnvelope(string address);

        void LetterIntoEnvelope();

        void SendLetter();
    }

    /// <summary>
    /// 具体的信件处理类
    /// </summary>
    internal class LetterProcessImpl : ILetterProcess
    {
        public void FillEnvelope(string address)
        {
            Console.WriteLine("填写收件人地址及姓名：" + address);
        }

        public void LetterIntoEnvelope()
        {
            Console.WriteLine("把信放到信封中");
        }

        public void SendLetter()
        {
            Console.WriteLine("邮递信件");
        }

        public void WriteContext(string context)
        {
            Console.WriteLine("填写信的内容：" + context);
        }
    }

    /// <summary>
    /// 检查信件的类
    /// </summary>
    internal class Police
    {
        public void CheckLetter(ILetterProcess letterProcess)
        {
            Console.WriteLine("检查信件");
        }
    }

    /// <summary>
    /// 邮局类
    /// </summary>
    internal class ModenPostOffice
    {
        private ILetterProcess letterProcess = new LetterProcessImpl();
        private Police police = new Police();

        public void SendLetter(string context, string address)
        {
            letterProcess.WriteContext(context);
            letterProcess.FillEnvelope(address);
            police.CheckLetter(letterProcess);
            letterProcess.LetterIntoEnvelope();
            letterProcess.SendLetter();
        }
    }

}
