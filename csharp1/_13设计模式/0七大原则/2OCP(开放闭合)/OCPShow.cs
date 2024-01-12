using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13设计模式.OCP
{
    /// <summary>
    /// 开放封闭原则
    /// </summary>
    /// <remarks>
    /// 封装、抽象不是目的 目的是封装变化
    /// 只有把变化封装了，我们的程序才能做到单一、才能做到开放封闭 才能做到高内聚、低耦合
    /// 
    /// </remarks>
    internal class OCPShow
    {
        public static void Show()
        {
            //创建存款对象
            IBankClient client = new TransferClient();//new WithdrawMoneyClient();//new DepositClient();

            //创建业务员对象
            BankStuff bankStuff = new();

            bankStuff.HandleProcess(client);
        }

    }

    class BankStuff
    {
        /// <summary>
        /// 拿到接口引用
        /// </summary>
        private IBankProcess? _process;


        public void HandleProcess(IBankClient bankClient)
        {
            //用户端调用自己的GetBankProcess方法，返回业务对象
            _process = bankClient.GetBankProcess() ?? throw new Exception("_process不能空！");
            _process.ProcessBiz();
        }
    }

    interface IBankClient
    {
        IBankProcess GetBankProcess();
    }

    interface IBankProcess
    {
        void ProcessBiz();
    }

    class DepositClient : IBankClient
    {
        public IBankProcess GetBankProcess()
        {
            return new Deposit();
        }
    }

    class WithdrawMoneyClient : IBankClient
    {
        public IBankProcess GetBankProcess()
        {
            return new WithdrawMoney();
        }
    }

    class TransferClient : IBankClient
    {
        public IBankProcess GetBankProcess()
        {
            return new Transfer();
        }
    }

    class Deposit : IBankProcess
    {
        public void ProcessBiz()
        {
            Console.WriteLine("存款");
        }
    }

    class WithdrawMoney : IBankProcess
    {
        public void ProcessBiz()
        {
            Console.WriteLine("取款");
        }
    }

    class Transfer : IBankProcess
    {
        public void ProcessBiz()
        {
            Console.WriteLine("转账");
        }
    }
}
