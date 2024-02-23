namespace _14Copilot使用;

public class QuickSort
{
    /// <summary>
    /// 快速排序算法
    /// </summary>
    /// <param name="array"></param>
    /// <param name="low"></param>
    /// <param name="high"></param>
    public static void Sort(int[] array, int low, int high)
    {
        if (low < high)
        {
            // 找到基准元素的位置
            int pivotIndex = Partition(array, low, high);

            // 对基准元素左边的子数组进行排序
            Sort(array, low, pivotIndex - 1);

            // 对基准元素右边的子数组进行排序
            Sort(array, pivotIndex + 1, high);

        }
    }

    /// <summary>
    /// 分区操作
    /// </summary>
    /// <param name="array"></param>
    /// <param name="low"></param>
    /// <param name="high"></param>
    /// <returns></returns>
    private static int Partition(int[] array, int low, int high)
    {
        // 选择最右边的元素作为基准
        int pivot = array[high];

        int i = low;

        // 将小于基准的元素放到左边，大于基准的元素放到右边
        for (int j = low; j < high; j++)
        {
            if (array[j] < pivot)
            {
                Swap(array, i, j);
                i++;
            }
        }

        // 将基准元素放到正确的位置
        Swap(array, i, high);

        return i;
    }

    /// <summary>
    /// 交换数组中的两个元素
    /// </summary>
    /// <param name="array"></param>
    /// <param name="i"></param>
    /// <param name="j"></param>
    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    /// <summary>
    /// 冒泡排序
    /// </summary>
    /// <param name="array"></param>
    public static void BubbleSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - 1 - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(array, j, j + 1);
                }
            }
        }
    }

    /// <summary>
    /// 水仙花算法
    /// </summary>
    public static void NarcissisticNumber()
    {
        for (int i = 100; i < 1000; i++)
        {
            int a = i / 100;
            int b = i / 10 % 10;
            int c = i % 10;
            if (i == a * a * a + b * b * b + c * c * c)
            {
                Console.WriteLine(i);
            }
        }
    }
}
