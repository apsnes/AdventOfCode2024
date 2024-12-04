using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
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
        static internal void ReadFile()
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
        static internal int Solution_One()
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
        static internal bool isMatch(int i, int j, (int row, int col) direction)
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
    }
}
