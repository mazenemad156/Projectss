using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters
{
    internal class AlphaTrim
    {

        public static byte[,] applyFilter(byte[,] ImageMatrix,int SortingAlgorithm)
        {
            for (int i = 0; i < ImageMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < ImageMatrix.GetLength(1); j++)
                {
                    ImageMatrix[i, j] = Window(ImageMatrix, i, j, 3, 1, 1, SortingAlgorithm);
                }
            }
            return ImageMatrix;
        }

        public static byte Window(byte[,] ImageMatrix, int x, int y, int WinSize, int ItrIdx, int T,int SortingAlgorithm)
        {



            byte[] arr = new byte[WinSize * WinSize];
            int index = 0;

            for (int i = x - ItrIdx; i <= x + ItrIdx; i++)
            {
                for (int j = y - ItrIdx; j <= y + ItrIdx; j++)
                {
                    if (i > 0 && j > 0 && i < ImageMatrix.GetLength(0) && j < ImageMatrix.GetLength(1))
                    {
                        arr[index] = ImageMatrix[i, j];
                        index++;
                    }
                }
            }

            byte[] sorted = new byte[arr.Length];
            byte[] TrimmedValues = new byte[T * 2];
            int avg = 0;
            int count = 0;
            if (SortingAlgorithm == 2)
            {
                sorted = CountSort.countsort(arr);
                for (int i = T; i < sorted.Length - T; i++)
                {
                    avg += sorted[i];
                    count++;
                }
            }
           else if(SortingAlgorithm == 1)
            {
                for (int i = 0; i < T; i++) {
                 TrimmedValues[i] = Knapsack.kthSmallest(arr, 0, arr.Length - 1, T);
                }
                for(int i = T; i < (T*2); i++)
                {
                    TrimmedValues[i] = Knapsack.kthLargest(arr, 0, arr.Length - 1, T);
                }
                for (int i = 0; i < arr.Length; i++)
                {
                    bool Trimmed = false;
                    for(int j = 0; j < TrimmedValues.Length; j++)
                    {
                        if (arr[i] == TrimmedValues[j])
                        {
                            Trimmed = true;
                        }
                    }
                    if (Trimmed == false)
                    {
                        avg += arr[i];
                        count++;
                    }
                }
            }
            var NewPixel = avg / count;
            return (byte) NewPixel;
        }
    }
}
