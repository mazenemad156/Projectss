using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ImageFilters
{
    public class QuickSort
    {

        public static int Partion(byte[] arr, int start, int end)
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
        public static void Swap(byte[] arr, int i, int j)
        {
            byte temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        public static byte[] Quick_sort(byte[] arr, int start, int end)
        {
            if (start < end)
            {

                int pivot = Partion(arr, start, end);
                Quick_sort(arr, start, pivot);
                Quick_sort(arr, pivot + 1, end);
            }
            return arr;
        }
        
       
    }

}