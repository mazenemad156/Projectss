using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ImageFilters
{
    class CountSort
    {

        public static byte[] countsort(byte[] arr)
        {
            int n = arr.Length;

            byte[] output = new byte[n];

            int[] count = new int[256];

            for (int i = 0; i < n; ++i)
                ++count[arr[i]];

            for (int i = 1; i <= 255; ++i)
                count[i] += count[i - 1];

            for (int i = n - 1; i >= 0; i--)
            {
                output[count[arr[i]] - 1] = arr[i];
                --count[arr[i]];
            }


            
            return output;
        }


       
    }


}