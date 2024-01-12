namespace _09系统IO和序列化
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            // 不用特意记，用到的时候查一下，几次就能记住
        }


        private static void GetChildDirectory(List<DirectoryInfo> directoryInfos,DirectoryInfo directoryParent)
        {
            DirectoryInfo[] children = directoryParent.GetDirectories();
            if (children != null && children.Length > 0) // 递归的跳出条件
            {
                directoryInfos.AddRange(children);
                foreach (DirectoryInfo child in children)
                {
                    GetChildDirectory(directoryInfos, child);
                }
            }
        }
    }
}