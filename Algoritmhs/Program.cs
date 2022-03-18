using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{

    static void countsort(int[] arr)
    {
        int n = arr.Length;

        int[] output = new int[n];

        int[] count = new int[256];

        int[] array = new int[0];

        for (int i = 0; i < n; ++i)
            ++count[arr[i]];

        for (int i = 1; i <= 255; ++i)
            count[i] += count[i - 1];

        for (int i = n - 1; i >= 0; i--)
        {
            output[count[arr[i]] - 1] = arr[i];
            --count[arr[i]];
        }


        for (int i = 0; i < n; ++i)
            arr[i] = output[i];
    }


    public static void Main()
    {

        int[] arr = { 5, 35, 40, 20, 100, 1,200,
                       7, 32, 10, 55, 90, 3};

        countsort(arr);

        Console.Write("Sorted Integers array is ");
        for (int i = 0; i < arr.Length; ++i)
            Console.Write(" " + arr[i]);
        System.Threading.Thread.Sleep(200000);
    }
}

    
