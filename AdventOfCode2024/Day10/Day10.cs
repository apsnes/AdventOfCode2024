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
        static int totalScore = 0;
        static HashSet<(int, int, int, int)> visitedScores = new();
        static Dictionary<(int, int, int, int), int> routes = new();
        static int originalI;
        static int originalJ;
        internal static void ReadFile()
        {
            string line;
            using StreamReader sr = new("Day10/Day10.txt");
            while ((line = sr.ReadLine()) != null)
            {
                List<int> currentList = new();
                foreach (char c in line.Trim())
                {
                    currentList.Add(int.Parse(c.ToString()));
                }
                map.Add(currentList);
            }
        }
        internal static int Solution_One()
        {
            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[i].Count; j++)
                {
                    if (map[i][j] == 0)
                    {
                        originalI = i;
                        originalJ = j;
                        CalculatePathScore(i, j);
                    }
                }
            }
            return totalScore;
        }
        internal static void CalculatePathScore(int i, int j)
        {
            if (i < 0 || j < 0 || i >= map.Count || j >= map[0].Count) return;

            int current = map[i][j];
            if (current == 9)
            {
                if (!visitedScores.Contains((originalI, originalJ, i, j)))
                {
                    totalScore += 1;
                    visitedScores.Add((originalI, originalJ, i, j));
                }
                if (!routes.ContainsKey((originalI, originalJ, i, j))) routes[((originalI, originalJ, i, j))] = 0;
                routes[((originalI, originalJ, i, j))]++;
            }

            if (i < map.Count - 1 && map[i + 1][j] == current + 1) CalculatePathScore(i + 1, j);
            if (i > 0 && map[i - 1][j] == current + 1) CalculatePathScore(i - 1, j);
            if (j < map[0].Count - 1 && map[i][j + 1] == current + 1) CalculatePathScore(i, j + 1);
            if (j > 0 && map[i][j - 1] == current + 1) CalculatePathScore(i, j - 1);
        }
        internal static int CalculateRouteScore()
        {
            int sum = 0;
            foreach (var  route in routes)
            {
                sum += route.Value;
            }
            return sum;
        }
    }
}
