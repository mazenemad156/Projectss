using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class program
{
    static int partitions(int[] arr, int low, int high)
    {
        int pivot = arr[high], pivotloc = low, temp;
        for (int i = low; i <= high; i++)
        {
            if (arr[i] < pivot)
            {
                temp = arr[i];
                arr[i] = arr[pivotloc];
                arr[pivotloc] = temp;
                pivotloc++;
            }
        }
        temp = arr[high];
        arr[high] = arr[pivotloc];
        arr[pivotloc] = temp;

        return pivotloc;
    }
    static int kthSmallest(int[] arr, int low,
                                int high, int k)
    {
        int partition = partitions(arr, low, high);
        if (partition == k)
            return arr[partition];
        else if (partition < k)
            return kthSmallest(arr, partition + 1, high, k);
        else
            return kthSmallest(arr, low, partition - 1, k);

    }


    public static void Main(String[] args)
    {
        int[] array = { 4, 5, 9, 200, -2, -9, 55 };
        int[] arraycopy = { 4, 5, 9, 200, -2, -9, 55 };


        Console.WriteLine("Enter the Value You want");
        int kPosition = Convert.ToInt32(Console.ReadLine());
        int length = array.Length;

        if (kPosition > length)
        {
            Console.WriteLine("Index out of bound");
        }
        else
        {

            Console.WriteLine(kPosition + "-th smallest element in array : " +
                                kthSmallest(arraycopy, 0, length - 1,
                                                        kPosition - 1));
            double Sum = 0;
            int x = 0;
            double n = 0;
            for (int i = 0; i < array.Length; i++)
            {
                x = array[i];
                if (x > kthSmallest(arraycopy, 0, length - 1, kPosition - 1))
                {
                    n++;
                    Sum += x;
                }

            }
            double Average = Sum / n;
            Console.WriteLine("Average of higher values : " + Average);
            System.Threading.Thread.Sleep(200000);
        }
    }
}
