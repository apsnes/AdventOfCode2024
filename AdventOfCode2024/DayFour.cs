using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal static class DayFour
    {
        static char[][] matrix;
        static string searchTerm = "XMAS";
        static readonly (int row, int col)[] directions = new (int, int)[]
        {
            (0, 1),
            (0, -1),
            (1, 0),
            (-1, 0),
            (1, 1),
            (-1, -1),
            (1, -1),
            (-1, 1)
        };
        internal static void ReadFile()
        {
            string[] fileList = File.ReadAllLines("DayFour.txt");
            int rows = fileList.Length;
            matrix = new char[rows][];
            for (int i = 0; i < fileList.Length; i++)
            {
                int cols = fileList[i].Length;
                matrix[i] = new char[cols];
                for (int j = 0; j < cols; j++)
                {
                    matrix[i][j] = fileList[i][j];
                }
            }
        }
        internal static int Solution_One()
        {
            int count = 0;
            for(int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0;j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == searchTerm[0])
                    {
                        foreach (var direction in directions)
                        {
                            if (isMatch(i, j, direction))
                            {
                                count++;
                            }
                        }
                    }
                }
            }
            return count;
        }
        internal static bool isMatch(int i, int j, (int row, int col) direction)
        {
            for (int k = 0; k < searchTerm.Length; k++)
            {
                if (i < 0 || j < 0 || i >= matrix.Length || j >= matrix[i].Length) return false;

                if (matrix[i][j] != searchTerm[k]) return false;

                i += direction.row;
                j += direction.col;
            }
            return true;
        }

        static string patternSM = @"S.M";
        static string patternMS = @"M.S";

        internal static int Solution_Two()
        {
            int count = 0;

            for (int i = 1; i < matrix.Length - 1; i++)
            {
                for (int j = 1; j < matrix[i].Length - 1; j++)
                {
                    if (matrix[i][j] == 'A')
                    {
                        string diag1 = new string(new char[] { matrix[i - 1][j - 1], matrix[i][j], matrix[i + 1][j + 1] }); 
                        string diag2 = new string(new char[] { matrix[i - 1][j + 1], matrix[i][j], matrix[i + 1][j - 1] });
                        if ((Regex.IsMatch(diag1, patternSM) && Regex.IsMatch(diag2, patternMS)) || (Regex.IsMatch(diag1, patternMS) && Regex.IsMatch(diag2, patternSM)))
                        {
                            Console.WriteLine($"Checking position ({i}, {j}) with diagonals: {diag1} and {diag2}");
                            count++;
                            break;
                        }
                    }
                }
            }
            return count; //137
        }
    }
}
