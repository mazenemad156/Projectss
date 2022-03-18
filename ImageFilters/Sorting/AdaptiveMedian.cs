
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageFilters
{
    internal class AdaptiveMedianFilter
    {
        public static byte[,] applyFilter(byte[,] ImageMatrix, int SortingAlgorithm,int MaxWinSize)
        {
            for (int i = 0; i < ImageMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < ImageMatrix.GetLength(1); j++)
                {
                    ImageMatrix[i, j] = Window(ImageMatrix, i, j, MaxWinSize, 3, 1,SortingAlgorithm);
                }
            }
            return ImageMatrix;
        }
        public static byte Window(byte[,] ImageMatrix, int x, int y, int MaxWinSize, int WinSize, int ItrIdx,int SortingAlgorithm)
        {
            if (WinSize % 2 == 0)
            {
                WinSize++;
            }
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
            if(SortingAlgorithm == 3)
            {
                sorted = QuickSort.Quick_sort(arr, 0, arr.Length);
            }
            else if(SortingAlgorithm == 2)
            {
                sorted = CountSort.countsort(arr);
            }
            byte Zmax = sorted[sorted.Length - 1];
            byte Zmin = sorted[0];
            byte Zmed = sorted[(sorted.Length / 2) + 1];
            int A1 = Zmed - Zmin;
            int A2 = Zmax - Zmed;
            if (A1 > 0 && A2 > 0)
            {
                int B1 = ImageMatrix[x, y] - Zmin;
                int B2 = Zmax - ImageMatrix[x, y];
                if (B1 > 0 && B2 > 0)
                {
                    return ImageMatrix[x, y];
                }
                else
                {
                    return Zmed;
                }
            }
            else
            {
                WinSize += 2;
                if (WinSize <= MaxWinSize)
                {
                    ItrIdx++;
                    return Window(ImageMatrix, x, y, MaxWinSize, WinSize, ItrIdx,SortingAlgorithm);
                }
                else
                {
                    return Zmed;
                }
            }
        }
    }
}