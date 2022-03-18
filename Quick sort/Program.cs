using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Quick_sort
{
    class Program
    {
 
        public static int Partion(int[] arr, int start, int end)
        {

            int pivot = arr[start];
            int swapIndex = start;
            for (int i = start + 1; i < end; i++)
            {
                if (arr[i] < pivot)
                {
                    swapIndex++;
                    Swap(arr, i, swapIndex);
                }
            }
            Swap(arr, start, swapIndex);
            return swapIndex;
        }
        public static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        public static int[] Quick_sort(int[] arr, int start, int end)
        {
            if (start < end)
            {

                int pivot = Partion(arr, start, end);
                Quick_sort(arr, start, pivot);
                Quick_sort(arr, pivot + 1, end);
            }
            return arr;
        }
        static void Main(string[] args)
        {
            var arr = new[] { 4, 5, 9, 200, -2, -9, 55 };
            var sorted = Quick_sort(arr, 0, arr.Length);
            foreach (var item in sorted)
            {
                Console.Write(item + " ");
            }
            System.Threading.Thread.Sleep(1000000000);
        }
    }

}