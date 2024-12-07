using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Day2
{
    internal static class DayTwo
    {
        internal static int[][] matrix;
        internal static int Solution_One()
        {
            StreamReader sr = new("DayTwo.txt");
            string line;
            matrix = new int[File.ReadAllLines("DayTwo.txt").Length][];
            int i = 0;
            while ((line = sr.ReadLine()) != null)
            {
                string[] lineParts = line.Split();
                int[] currentArray = new int[lineParts.Length];
                for (int j = 0; j < lineParts.Length; j++)
                {
                    currentArray[j] = int.Parse(lineParts[j].Trim());
                }
                matrix[i] = currentArray;
                i++;
            }
            int safeArrays = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                if (Is_Array_Valid(matrix[row])) safeArrays++;
            }
            return safeArrays;
        }
        internal static int Solution_Two()
        {
            int safeArrays = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                List<int> nums = new List<int>(matrix[row]);
                for (int i = 0; i < matrix[row].Length; i++)
                {
                    nums.RemoveAt(i);
                    int[] currentArray = nums.ToArray();
                    if (Is_Array_Valid(currentArray))
                    {
                        safeArrays++;
                        break;
                    }
                    nums.Insert(i, matrix[row][i]);
                }
            }
            return safeArrays;
        }

        public static bool Is_Array_Valid(int[] arr)
        {
            bool isIncreasing = arr[1] > arr[0];
            for (int col = 1; col < arr.Length; col++)
            {
                if (isIncreasing && arr[col] < arr[col - 1] || !isIncreasing && arr[col] > arr[col - 1] || Math.Abs(arr[col - 1] - arr[col]) > 3 || arr[col - 1] == arr[col])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
