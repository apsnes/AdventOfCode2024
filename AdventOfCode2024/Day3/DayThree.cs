using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Day3
{
    internal class DayThree
    {
        internal static string[] lines;
        internal static void ReadFile()
        {
            lines = File.ReadAllLines("DayThree.txt");
        }

        internal static int Solution_One()
        {
            int total = 0;

            foreach (string line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == 'm')
                    {
                        if (i < line.Length - 7)
                        {
                            if (line.Substring(i, 3) == "mul")
                            {
                                int startIndex = i + 4;
                                int endIndex = startIndex;
                                while (endIndex < line.Length && line[endIndex] != ')')
                                {
                                    endIndex++;
                                }
                                if (endIndex < line.Length && endIndex > startIndex)
                                {
                                    string currentSum = line.Substring(startIndex, endIndex - startIndex);
                                    string[] parts = currentSum.Split(',');

                                    if (parts.Length == 2 &&
                                        int.TryParse(parts[0], out int num1) &&
                                        int.TryParse(parts[1], out int num2))
                                    {
                                        total += num1 * num2;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return total;
        }
        internal static int Solution_Two()
        {
            int total = 0;
            bool doing = true;
            foreach (string line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == 'm')
                    {
                        if (doing)
                        {
                            if (i < line.Length - 7)
                            {
                                if (line.Substring(i, 3) == "mul")
                                {
                                    int startIndex = i + 4;
                                    int endIndex = startIndex;
                                    while (endIndex < line.Length && line[endIndex] != ')')
                                    {
                                        endIndex++;
                                    }
                                    if (endIndex < line.Length && endIndex > startIndex)
                                    {
                                        string currentSum = line.Substring(startIndex, endIndex - startIndex);
                                        string[] parts = currentSum.Split(',');

                                        if (parts.Length == 2 &&
                                            int.TryParse(parts[0], out int num1) &&
                                            int.TryParse(parts[1], out int num2))
                                        {
                                            total += num1 * num2;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (line[i] == 'd')
                    {
                        if (line.Substring(i, 7) == "don't()")
                        {
                            doing = false;
                        }
                        else if (line.Substring(i, 4) == "do()")
                        {
                            doing = true;
                        }
                    }
                }
            }
            return total;
        }
    }
}
