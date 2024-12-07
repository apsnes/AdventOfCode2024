using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal static class DaySix
    {
        static List<List<char>> chars = new();
        static HashSet<(int, int)> visitedPositions = new();
        static (int, int) guardStartPosition;
        internal static void ReadFile()
        {
            StreamReader sr = new("Day6/DaySix.txt");
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
                        guardStartPosition = (i, j);
                        break;
                    }
                }
            }
            Direction currentDirection = Direction.North;
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
        internal static int Solution_Two()
        {
            int result = 0;
            foreach ((int, int) position in visitedPositions)
            {
                if (position == guardStartPosition) continue;
                int i = position.Item1, j = position.Item2;
                chars[i][j] = '#';
                if (IsLoop()) result++;
                chars[i][j] = '.';
            }
            return result;
        }
        internal static bool IsLoop()
        {
            HashSet<(int, int, Direction)> currentVistedPositions = new();

            (int rows, int cols, Direction currentDirection) guardPosition = (guardStartPosition.Item1, guardStartPosition.Item2, Direction.North);
            currentVistedPositions.Add(guardPosition);
            int rows = chars.Count, cols = chars[0].Count;

            while (guardPosition.rows != 0 && guardPosition.cols != 0 && guardPosition.rows != rows - 1 && guardPosition.cols != cols - 1)
            {
                switch (guardPosition.currentDirection)
                {
                    case Direction.North:
                        {
                            if (chars[guardPosition.rows - 1][guardPosition.cols] == '#')
                            {
                                guardPosition.currentDirection = Direction.East;
                            }
                            else
                            {
                                guardPosition.rows--;
                                if (currentVistedPositions.Contains(guardPosition)) return true;
                                currentVistedPositions.Add(guardPosition);
                            }
                            break;
                        }
                    case Direction.East:
                        {
                            if (chars[guardPosition.rows][guardPosition.cols + 1] == '#')
                            {
                                guardPosition.currentDirection = Direction.South;
                            }
                            else
                            {
                                guardPosition.cols++;
                                if (currentVistedPositions.Contains(guardPosition)) return true;
                                currentVistedPositions.Add(guardPosition);
                            }
                            break;
                        }
                    case Direction.South:
                        {
                            if (chars[guardPosition.rows + 1][guardPosition.cols] == '#')
                            {
                                guardPosition.currentDirection = Direction.West;
                            }
                            else
                            {
                                guardPosition.rows++;
                                if (currentVistedPositions.Contains(guardPosition)) return true;
                                currentVistedPositions.Add(guardPosition);
                            }
                            break;
                        }
                    case Direction.West:
                        {
                            if (chars[guardPosition.rows][guardPosition.cols - 1] == '#')
                            {
                                guardPosition.currentDirection = Direction.North;
                            }
                            else
                            {
                                guardPosition.cols--;
                                if (currentVistedPositions.Contains(guardPosition)) return true;
                                currentVistedPositions.Add(guardPosition);
                            }
                            break;
                        }
                }
            }
            return false;
        }
    }
}
