using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ImageFilters
{
    class Knapsack
    {
        public static byte partitions(byte[] arr, int low, int high)
        {
            int pivot = arr[high];
            int pivotloc = low;
            byte temp;
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

            return (byte) pivotloc;
        }
         public static byte kthSmallest(byte[] arr, int low, int high, int k)
        {
            
            byte partition = partitions(arr, low, high);
            int partplus = partition + 1;
            int partminus = partition - 1;
            if (partition == k)
                return arr[partition];
            else if (partition < k)
                return kthSmallest(arr, partplus, high, k);
            else
                return kthSmallest(arr, low, partminus, k);

        }


      
        
    }
}