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
        internal static void ReadFile()
        {
            puzzleInput = File.ReadAllText("Day9/Day9.txt").Trim();
        }
        internal static long Solution_One()
        {
            List<char> disk = BuildDisk(puzzleInput);
            CompactDisk(disk);
            return CalculateChecksum(disk);
        }
        internal static List<char> BuildDisk(string input)
        {
            List<char> disk = new();
            int fileID = 0;
            
            for (int i = 0; i < input.Length; i++)
            {
                int length = int.Parse(input[i].ToString());

                char currentChar = input[i];

                if (i % 2 == 1) currentChar = '.';

                for (int j = 0; j < length; j++)
                {
                    disk.Add(currentChar);
                }
            }
            return disk;
        }
        internal static void CompactDisk(List<char> disk)
        {
            while (disk.Contains('.'))
            {
                int left = disk.FindIndex(c => c == '.');
                int right = disk.FindLast(Char.IsNumber);
                disk[left] = disk[right];
                disk.RemoveAt(right);
            }
        }
        internal static long CalculateChecksum(List<char> disk)
        {
            long checkSum = 0;
            for (int i = 0; i <  disk.Count; i++)
            {
                {
                    checkSum += i * long.Parse(disk[i].ToString());
                }
            }
            return checkSum;
        }
    }
}
