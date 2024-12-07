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
            }
        }
        internal static long Solution_One()
        {
            long sum = 0;
            for (int i = 0; i < answers.Count; i++)
            {
                sum += IsValidSum(answers[i], ints[i]);
            }
            return sum;
        }
        internal static long IsValidSum(long answer, List<long> nums)
        {
            long currProduct = nums[0];
            for (int i = 1; i < nums.Count; i++)
            {
                currProduct *= nums[i];
            }
            if (currProduct < answer) return 0;
            if (currProduct == answer) return answer;

            for (int i = 1; i < nums.Count; i++)
            {
                for (int j = 1; j < nums.Count; j++)
                {

                }
            }


            return 0;
        }
    }
}
