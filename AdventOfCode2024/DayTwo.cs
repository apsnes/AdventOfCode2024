using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
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
                for(int j = 0; j < lineParts.Length; j++)
                {
                    currentArray[j] = int.Parse(lineParts[j].Trim());
                }
                matrix[i] = currentArray;
                i++;
            }

            int safeArrays = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                bool isIncreasing = matrix[row][1] > matrix[row][0];
                bool isSafe = true;
                for (int col = 1; col < matrix[row].Length; col++)
                {
                    if (isIncreasing && matrix[row][col] < matrix[row][col - 1] || !isIncreasing && matrix[row][col] > matrix[row][col - 1] || Math.Abs(matrix[row][col - 1] - matrix[row][col]) > 3 || matrix[row][col - 1] == matrix[row][col])
                    {
                        isSafe = false;
                        break;
                    }         
                }
                if (isSafe) safeArrays++;
            }
            return safeArrays;
        }
    }
}
