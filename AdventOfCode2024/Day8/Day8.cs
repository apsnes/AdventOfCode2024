using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal static class Day8
    {
        static List<List<char>> matrix = new();
        static bool IsValidPosition(int row, int col) => row >= 0 && row < matrix.Count && col >= 0 && col < matrix[0].Count;
        internal static void ReadFile()
        {
            using StreamReader sr = new("Day8/Day8.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                List<char> currentLine = new();
                foreach (char c in line)
                {
                    currentLine.Add(c);
                }
                matrix.Add(currentLine);
            }
        }
        internal static int Solution_One()
        {
            Dictionary<char, List<(int rows, int cols)>> dict = new();
            for (int rows = 0; rows < matrix.Count; rows++)
            {
                for (int cols = 0; cols < matrix[0].Count; cols++)
                {
                    char c = matrix[rows][cols];
                    if (c == '.') continue;
                    if (!dict.ContainsKey(c)) dict[c] = new List<(int rows, int cols)>();
                    dict[c].Add((rows, cols));
                }
            }

            HashSet<(int, int)> uniqueLocations = new();

            foreach (var entry in dict)
            {
                if (entry.Value.Count < 2) continue;

                foreach (var coords in entry.Value)
                {
                    foreach (var c in entry.Value)
                    {
                        if (coords == c) continue;
                        int rowDifference = coords.rows - c.rows;
                        int colDifference = coords.cols - c.cols;
                        if (IsValidPosition(coords.rows + rowDifference, coords.cols + colDifference)) uniqueLocations.Add((coords.rows + rowDifference, coords.cols + colDifference));
                    }    
                }
            }
            return uniqueLocations.Count;
        }
    }
}
