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
                map[x][y] = 1;
            }
        }
        internal static int CalculateShortestPath()
        {
            List<(int row, int col)> directions = [(0, 1), (0, -1), (1, 0), (-1, 0)];
            Queue<(int row, int col, int length)> q = new();
            q.Enqueue((0, 0, 0));

            map[0][0] = 1;

            while (q.Count > 0)
            {
                var current = q.Dequeue();
                int currentRow = current.row;
                int currentCol = current.col;
                int currentLength = current.length;
                if (currentRow == 70 && currentCol == 70) return currentLength;

                foreach (var tup in directions)
                {
                    int newRow = currentRow + tup.row;
                    int newCol = currentCol + tup.col;

                    if ((newRow >= 0 && newRow <= 70) && (newCol >= 0 && newCol <= 70) && map[newRow][newCol] == 0)
                    {
                        map[newRow][newCol] = 1;
                        q.Enqueue((newRow, newCol, currentLength + 1));
                    }
                }
            }
            return 0;
        }
    }
}
