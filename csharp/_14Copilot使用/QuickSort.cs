namespace _14Copilotʹ��;

public class QuickSort
{
    /// <summary>
    /// ���������㷨
    /// </summary>
    /// <param name="array"></param>
    /// <param name="low"></param>
    /// <param name="high"></param>
    public static void Sort(int[] array, int low, int high)
    {
        if (low < high)
        {
            // �ҵ���׼Ԫ�ص�λ��
            int pivotIndex = Partition(array, low, high);

            // �Ի�׼Ԫ����ߵ��������������
            Sort(array, low, pivotIndex - 1);

            // �Ի�׼Ԫ���ұߵ��������������
            Sort(array, pivotIndex + 1, high);

        }
    }

    /// <summary>
    /// ��������
    /// </summary>
    /// <param name="array"></param>
    /// <param name="low"></param>
    /// <param name="high"></param>
    /// <returns></returns>
    private static int Partition(int[] array, int low, int high)
    {
        // ѡ�����ұߵ�Ԫ����Ϊ��׼
        int pivot = array[high];

        int i = low;

        // ��С�ڻ�׼��Ԫ�طŵ���ߣ����ڻ�׼��Ԫ�طŵ��ұ�
        for (int j = low; j < high; j++)
        {
            if (array[j] < pivot)
            {
                Swap(array, i, j);
                i++;
            }
        }

        // ����׼Ԫ�طŵ���ȷ��λ��
        Swap(array, i, high);

        return i;
    }

    /// <summary>
    /// ���������е�����Ԫ��
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
    /// ð������
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
    /// ˮ�ɻ��㷨
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
