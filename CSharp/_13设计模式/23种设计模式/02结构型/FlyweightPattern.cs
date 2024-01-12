using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13设计模式._23种设计模式._02结构型
{
    /// <summary>
    /// 享元模式(共享元素/对象)
    /// </summary>
    /// <remarks>
    /// 总结：当系统中大虽使用某些相同或者相似的对象，这些对象会消耗大量的资源，
    /// 并且这些对象剔除外部状态后可以通过同一个对象来替代，
    /// 这时，我们可以使用享元设计模式来解决。
    /// 
    /// 内部状态：对象内部不受环境改变的部分作为内部状态。
    /// 外部状态：随着环境的变化而变化的部分。
    /// 
    /// 用共享技术有效的支持大量细粒度的对象，对共享元素的有效利用，避免去创建大量重复的对象
    /// 池技术：字符串拘留池、数据库连接池、线程池等
    /// 
    /// 优点：通过对象的复用，减少了对象的数量，节省内存。
    /// 缺点：需要分类对象内部和外部的状态，提高了系统的复杂度
    /// </remarks>
    internal class FlyweightPattern
    {
        public static void Show()
        {
            //共享单车
            BikeFactory bikeFactory = new BikeFactory();

            FlyWeightBike bike = bikeFactory.GetBike();
            bike.Ride("张三");
            bike.Back("张三");

            FlyWeightBike bike2 = bikeFactory.GetBike();
            bike2.Ride("李四");

            FlyWeightBike bike3 = bikeFactory.GetBike();
            bike3.Ride("王五");


        }

        abstract class FlyWeightBike
        {
            //内部状态：BikeID State 0--锁定 1--骑行
            //外部状态：用户
            //骑行 锁定

            public string BikeID { get; set; } = string.Empty;
            public int State { get; set; }
            public abstract void Ride(string userName);
            public abstract void Back(string userName);

        }

        class YellowBike : FlyWeightBike
        {
            public YellowBike(string bikeID)
            {
                this.BikeID = bikeID;
            }

            public override void Back(string userName)
            {
                this.State = 0;
                Console.WriteLine($"用户{userName}归还了ID为{this.BikeID}ofo自行车");
            }

            public override void Ride(string userName)
            {
                this.State = 1;
                Console.WriteLine($"用户{userName}正在骑行ID为{this.BikeID}ofo自行车");
            }
        }

        class BikeFactory
        {
            List<FlyWeightBike> bikePool = new List<FlyWeightBike>();

            public BikeFactory()
            {
                for (int i = 0; i < 3; i++)
                {
                    bikePool.Add(new YellowBike(i.ToString()));
                }
            }

            public FlyWeightBike GetBike()
            {
                for (int i = 0; i < bikePool.Count; i++)
                {
                    if (bikePool[i].State == 0)
                    {
                        return bikePool[i];
                    }
                }

                return null;
            }
        }
    }

}
