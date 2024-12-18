using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal static class Day18
    {
        internal static List<(int x, int y)> Coordinates = new();
        internal static int[][] map = new int[71][];
        internal static void ReadFile()
        {
            string[] lines = File.ReadAllLines("Day18/Day18.txt");
            foreach (string line in lines)
            {
                string[] nums = line.Split(',');
                Coordinates.Add((int.Parse(nums[0]), int.Parse(nums[1])));
            }
        }
        internal static void WriteBlocks()
        {
            for (int i = 0; i <= 70; i++)
            {
                map[i] = new int[71];
            }
            for (int i = 0; i < 1024; i++)
            {
                int x = Coordinates[i].x;
                int y = Coordinates[i].y;
                map[x][y] = '#';
            }
        }
        internal static int CalculateShortestPath()
        {
            return 0;
        }
    }
}
