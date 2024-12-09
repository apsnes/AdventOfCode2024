using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal static class Day9
    {
        static string puzzleInput = "";
        internal static void ReadFile()
        {
            puzzleInput = File.ReadAllText("Day9/Day9.txt").Trim();
        }
        internal static long Solution_One()
        {
            StringBuilder sb = new();
            for(int i = 0; i < puzzleInput.Length; i++)
            {
                if (i % 2 == 0)
                {
                    int emptySpace = int.Parse(puzzleInput[i].ToString());
                    for (int j = 0; j < emptySpace; j++)
                    {
                        sb.Append('.');
                    }
                }
                else
                {
                    int blockLength = int.Parse(puzzleInput[i].ToString());
                    for (int j = 0; j < blockLength; j++)
                    {
                        sb.Append(puzzleInput[i]);
                    }
                }
            }
            string inputWithSpaces = sb.ToString();

            sb.Clear();
            int end = inputWithSpaces.Length - 1;

            for (int i = 0; i <= end; i++)
            {
                if (inputWithSpaces[i] != '.') sb.Append(inputWithSpaces[i]);
                else
                {
                    while (end >= 0 && inputWithSpaces[end] == '.') end--;
                    if (end >= 0)
                    {
                        sb.Append(inputWithSpaces[end]);
                        end--;
                    }
                }
            }

            List<char> disk = new(sb.ToString());

            int endIndex = disk.Count - 1;

            for (int i = endIndex; i >= 0; i--)
            {
                if (disk[i] != '.')
                {
                    char fileID = disk[i];
                    int firstEmptySpace = disk.FindIndex(x => x == '.');
                    if (firstEmptySpace != -1)
                    {
                        disk[firstEmptySpace] = fileID;
                        disk[i] = '.';
                    }
                }
            }
            long checksum = 0;
            for (int i = 0; i < disk.Count; i++)
            {
                if (disk[i] != '.')
                {
                    checksum += i * long.Parse(disk[i].ToString());
                }
                else
                {
                    break;
                }
            }
            return checksum;
        }
    }
}
