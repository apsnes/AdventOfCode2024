using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal static class Day9
    {
        static string puzzleInput = "";
        static int currentFileId = 0;
        internal static void ReadFile()
        {
            puzzleInput = File.ReadAllText("Day9/Day9.txt").Trim();
        }
        internal static long Solution_One()
        {
            List<int> disk = BuildDisk(puzzleInput);
            CompactDisk(disk);
            return CalculateChecksum(disk);
        }
        internal static List<int> BuildDisk(string input)
        {
            List<int> disk = new();
            
            for (int i = 0; i < input.Length; i++)
            {
                int length = int.Parse(input[i].ToString());
                int currentNum = -1;

                if (i % 2 == 0)
                {
                    currentNum = currentFileId;
                    currentFileId++;
                }

                for (int j = 0; j < length; j++)
                {
                    disk.Add(currentNum);
                }
            }
            return disk;
        }
        internal static void CompactDisk(List<int> disk)
        {
            for (int i = 0; i < disk.Count; i++)
            {
                if (disk[i] == -1)
                {
                    int lastNum = disk.FindLastIndex(x => x > 0);
                    if (i > lastNum) break;
                    disk[i] = disk[lastNum];
                    disk[lastNum] = -1;
                }
            }
        }
        internal static long CalculateChecksum(List<int> disk)
        {
            long checkSum = 0;
            for (int i = 0; i < disk.Count; i++)
            {
                if (disk[i] == -1) break;
                {
                    checkSum += i * disk[i];
                }
            }
            return checkSum;
        }
    }
}
