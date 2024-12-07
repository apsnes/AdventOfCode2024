using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Day6
{
    internal static class DaySix
    {
        static List<List<char>> chars = new();
        internal static void ReadFile()
        {
            StreamReader sr = new("DaySix.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                List<char> currChars = line.ToCharArray().ToList();
                chars.Add(currChars);
            }
        }
        internal static int Solution_One()
        {
            int cols = chars[0].Count;
            int rows = chars.Count;
            (int rows, int cols) guardPosition = (0, 0);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (chars[i][j] == '^')
                    {
                        guardPosition = (i, j);
                        break;
                    }
                }
            }
            Direction currentDirection = Direction.North;
            HashSet<(int, int)> visitedPositions = new();
            visitedPositions.Add(guardPosition);
            while (guardPosition.rows != 0 && guardPosition.cols != 0 && guardPosition.rows != rows - 1 && guardPosition.cols != cols - 1)
            {
                switch (currentDirection)
                {
                    case Direction.North:
                        {
                            if (chars[guardPosition.rows - 1][guardPosition.cols] == '#')
                            {
                                currentDirection = Direction.East;
                            }
                            else
                            {
                                guardPosition.rows--;
                                visitedPositions.Add(guardPosition);
                            }
                            break;
                        }
                    case Direction.East:
                        {
                            if (chars[guardPosition.rows][guardPosition.cols + 1] == '#')
                            {
                                currentDirection = Direction.South;
                            }
                            else
                            {
                                guardPosition.cols++;
                                visitedPositions.Add(guardPosition);
                            }
                            break;
                        }
                    case Direction.South:
                        {
                            if (chars[guardPosition.rows + 1][guardPosition.cols] == '#')
                            {
                                currentDirection = Direction.West;
                            }
                            else
                            {
                                guardPosition.rows++;
                                visitedPositions.Add(guardPosition);
                            }
                            break;
                        }
                    case Direction.West:
                        {
                            if (chars[guardPosition.rows][guardPosition.cols - 1] == '#')
                            {
                                currentDirection = Direction.North;
                            }
                            else
                            {
                                guardPosition.cols--;
                                visitedPositions.Add(guardPosition);
                            }
                            break;
                        }
                }
            }
            return visitedPositions.Count;
        }
        internal enum Direction
        {
            North,
            East,
            South,
            West
        }
    }
}
