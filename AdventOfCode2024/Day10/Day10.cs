using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal static class Day10
    {
        static List<List<int>> map = new();
        private static Dictionary<(int, int), int> memo = new();
        internal static void ReadFile()
        {
            string line;
            using StreamReader sr = new("Day10/Day10.txt");
            while ((line = sr.ReadLine()) != null)
            {
                List<int> currentList = new();
                foreach (char c in line)
                {
                    currentList.Add(int.Parse(c.ToString()));
                }
                map.Add(currentList);
            }
        }
        internal static int Solution_One()
        {
            int totalScore = 0;
            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[i].Count; j++)
                {
                    if (map[i][j] == 0)
                    {
                        totalScore += CalculatePathScore(i, j);
                    }
                }
            }
            return totalScore;
        }
        internal static int CalculatePathScore(int i, int j)
        {
            if (memo.ContainsKey((i, j))) return memo[(i, j)];

            int score = 0;
            if (i < 0 || j < 0 || i >= map.Count || j >= map[0].Count) return 0;

            int current = map[i][j];
            if (current == 9) return 1;

            if (i < map.Count - 1 && map[i + 1][j] == current + 1) score += CalculatePathScore(i + 1, j);
            if (i > 0 && map[i - 1][j] == current + 1) score += CalculatePathScore(i - 1, j);
            if (j < map[0].Count - 1 && map[i][j + 1] == current + 1) score += CalculatePathScore(i, j + 1);
            if (j > 0 && map[i][j - 1] == current + 1) score += CalculatePathScore(i, j - 1);
            return score;
        }
    }
}
