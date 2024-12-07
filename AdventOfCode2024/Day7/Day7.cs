using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal static class Day7
    {
        static List<long> answers = new();
        static List<List<long>> ints = new();
        internal static void ReadFile()
        {
            string[] lines = File.ReadAllLines("Day7/Day7.txt");
            foreach(string line in lines)
            {
                string[] parts = line.Split(": ");
                answers.Add(long.Parse(parts[0]));
                string[] digits = parts[1].Split(' ');
                List<long> currentDigits = new();
                foreach (string digit in digits)
                {
                    currentDigits.Add(long.Parse(digit));
                }
                ints.Add(currentDigits);
            }
        }
        internal static long Solution_One()
        {
            long total = 0;
            for (int i = 0; i < answers.Count; i++)
            {
                if (IsValid(answers[i], ints[i], ints[i][0], 1))
                {
                    total += answers[i];
                }
            }
            return total;
        }
        internal static bool IsValid(long answer, List<long> nums, long currentValue, int index)
        {
            if (index == nums.Count) return currentValue == answer;

            if (IsValid(answer, nums, currentValue + nums[index], index + 1)) return true;

            if (IsValid(answer, nums, currentValue * nums[index], index + 1)) return true;

            //Added Concat variant for part two
            if (IsValid(answer, nums, Concat(currentValue, nums[index]), index + 1)) return true;

            return false;
        }
        internal static long Concat(long firstValue, long secondValue)
        {
            string combinedNums = firstValue.ToString() + secondValue.ToString();
            return long.Parse(combinedNums);
        }
    }
}
