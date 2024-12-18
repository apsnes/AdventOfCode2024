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
        internal static void WriteBlocks(int index)
        {
            for (int i = 0; i <= 70; i++)
            {
                map[i] = new int[71];
            }
            for (int i = 0; i < index; i++)
            {
                int x = Coordinates[i].x;
                int y = Coordinates[i].y;
                map[x][y] = 1;
            }
        }
        internal static int CalculateShortestPath()
        {
            //Maintain a list of all directions
            List<(int row, int col)> directions = [(0, 1), (0, -1), (1, 0), (-1, 0)];
            //Create a queue to hold coordinates and current steps taken
            Queue<(int row, int col, int length)> q = new();
            //Enqueue first position in the grid with length 0 as we are counting STEPS TAKEN, not path length
            q.Enqueue((0, 0, 0));
            map[0][0] = 1;

            while (q.Count > 0)
            {
                var current = q.Dequeue();
                int currentRow = current.row;
                int currentCol = current.col;
                int currentLength = current.length;
                //If we've reached the endpoint, return current steps taken
                if (currentRow == 70 && currentCol == 70) return currentLength;

                //Foreach direction, add the row & col values to our current row & col values,
                //then check if the new position on the map is within bounds and not blocked or already visited.
                foreach (var tup in directions)
                {
                    int newRow = currentRow + tup.row;
                    int newCol = currentCol + tup.col;

                    if ((newRow >= 0 && newRow <= 70) && (newCol >= 0 && newCol <= 70) && map[newRow][newCol] == 0)
                    {
                        //If valid, set new position to 1 so we dont revisit it.
                        map[newRow][newCol] = 1;
                        //Enqueue new position with length + 1 so that we can run the algorithm on the new position also.
                        q.Enqueue((newRow, newCol, currentLength + 1));
                    }
                }
            }
            //If no paths were found, return default value of 0 steps
            return 0;
        }
        internal static (int, int) CalculateCutOff()
        {
            for (int i = 1024; i < Coordinates.Count; i++)
            {
                //Rewrite map for each iteration
                WriteBlocks(i);
                int row = Coordinates[i].x;
                int col = Coordinates[i].y;
                //Check if path still valid, if not, return previous coordinates as that would have been the byte to block the map
                if (CalculateShortestPath() == 0) return Coordinates[i - 1];
            }
            return (0, 0);
        }
    }
}
