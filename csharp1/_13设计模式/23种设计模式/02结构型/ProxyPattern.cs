using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13设计模式._23种设计模式._02结构型
{
    /// <summary>
    /// 代理模式
    /// </summary>
    /// <remarks>
    /// 为其他对象提供一种代理，以控制这个对象的访问
    /// 
    /// 远程代理
    /// 虚拟代理
    /// 安全代理
    /// </remarks>
    internal class ProxyPattern
    {
        public static void Show()
        {
            IOrder order = new ProxyOrder(new RealOrder("笔记本", 200, "张三"));

            order.SetProductName("DELL笔记本", "张三");
            Console.WriteLine(order.GetProductName());

            order.SetProductName("惠普笔记本", "李四");
        }

    }

    interface IOrder
    {
        string GetProductName();

        void SetProductName(string productName, string user);

        int GetOrderNum();

        void SetOrderNum(int orderNum, string user);

        void SetOrderUser(string userName, string user);

        string GetOrderUser();
    }

    class RealOrder : IOrder
    {
        public RealOrder(string productName, int orderNum, string userName)
        {
            ProductName = productName;
            OrderNum = orderNum;
            UserName = userName;
        }

        private string ProductName { get; set; }
        private int OrderNum { get; set; }
        private string UserName { get; set; }


        public int GetOrderNum()
        {
            return OrderNum;
        }

        public string GetOrderUser()
        {
            return UserName;
        }

        public string GetProductName()
        {
            return ProductName;
        }

        public void SetOrderNum(int orderNum, string user)
        {
            this.OrderNum = orderNum;
        }

        public void SetOrderUser(string userName, string user)
        {
            this.UserName = userName;
        }

        public void SetProductName(string productName, string user)
        {
            this.ProductName = productName;
        }
    }

    class ProxyOrder : IOrder
    {
        private RealOrder realOrder;
        public ProxyOrder(RealOrder realOrder)
        {
            this.realOrder = realOrder;
        }

        public int GetOrderNum()
        {
            return realOrder.GetOrderNum();
        }

        public string GetOrderUser()
        {
            return realOrder.GetOrderUser();
        }

        public string GetProductName()
        {
            return realOrder.GetProductName();
        }

        public void SetOrderNum(int orderNum, string user)
        {
            if (user != null && user.Equals(realOrder.GetOrderUser()))
            {
                realOrder.SetOrderNum(orderNum, user);
            }
            else
            {
                Console.WriteLine("无权操作！");
            }
        }

        public void SetOrderUser(string userName, string user)
        {
            if (user != null && user.Equals(realOrder.GetOrderUser()))
            {
                realOrder.SetOrderUser(userName, user);
            }
            else
            {
                Console.WriteLine("无权操作！");
            }
        }

        public void SetProductName(string productName, string user)
        {
            if (user != null && user.Equals(realOrder.GetOrderUser()))
            {
                realOrder.SetProductName(productName, user);
            }
            else
            {
                Console.WriteLine("无权操作！");
            }
        }
    }
}
