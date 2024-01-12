namespace _13设计模式
{
    /// <summary>
    /// 迭代器模式
    /// </summary>
    internal class IteratorPattern
    {
        internal static void Show()
        {
            Aggregate aggregate = new Aggregate();
            aggregate.Add("Item 1");
            aggregate.Add("Item 2");
            aggregate.Add("Item 3");

            IIterator iterator = aggregate.CreateIterator();
            while (iterator.HasNext())
            {
                object item = iterator.Next();
                Console.WriteLine(item);
            }
        }
    }
    /// <summary>
    /// 迭代器接口
    /// </summary>
    interface IIterator
    {
        bool HasNext();
        object Next();
        void Remove();
    }

    /// <summary>
    /// 具体迭代器
    /// </summary>
    class ConcreteIterator : IIterator
    {
        private List<object> items;
        private int position;

        public ConcreteIterator(List<object> items)
        {
            this.items = items;
            position = 0;
        }

        public bool HasNext()
        {
            return position < items.Count;
        }

        public object Next()
        {
            object item = items[position];
            position++;
            return item;
        }

        public void Remove()
        {
            items.RemoveAt(position - 1);
        }
    }

    /// <summary>
    /// 聚合类
    /// </summary>
    class Aggregate
    {
        private List<object> items;

        public Aggregate()
        {
            items = new List<object>();
        }

        public void Add(object item)
        {
            items.Add(item);
        }

        public IIterator CreateIterator()
        {
            return new ConcreteIterator(items);
        }
    }

}
