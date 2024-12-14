using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal static class Day11
    {      
        static Dictionary<(long, int), long> seenStones = new();

        internal static long Solution(int blinks)
        {
            string input = "27 10647 103 9 0 5524 4594227 902936";
            var stones = input.Split(' ').Select(long.Parse).ToList();

            long total = stones.Count;

            foreach (var stone in stones)
            {
                total += CalculateStoneCount(blinks, stone);
            }
            
            return total;
        }

        internal static long CalculateStoneCount(int blinks, long num)
        {
            if (blinks == 0) return 0;

            if (seenStones.ContainsKey((num, blinks))) return seenStones[(num, blinks)];

            long total = 0;

            if (num == 0)
            {
                total = CalculateStoneCount(blinks - 1, 1);
                seenStones[(num, blinks)] = total;
                return total;
            }

            string numAsString = num.ToString();
            if (numAsString.Length % 2 == 0)
            {
                total++;
                total += CalculateStoneCount(blinks - 1, int.Parse(numAsString.Substring(0, numAsString.Length / 2)));
                total += CalculateStoneCount(blinks - 1, int.Parse(numAsString.Substring(numAsString.Length / 2)));
                seenStones[(num, blinks)] = total;
                return total;
            }

            total = CalculateStoneCount(blinks - 1, num * 2024);
            seenStones[(num, blinks)] = total;
            return total;
        }
    }
}
