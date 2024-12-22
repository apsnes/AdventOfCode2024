using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal static class Day22
    {
        static List<int> initialNumbers = new();
        internal static void ReadFile()
        {
            foreach (var item in File.ReadAllLines("Day22/Day22.txt").ToList())
            {
                initialNumbers.Add(int.Parse(item.Trim()));
            }
            foreach (var item in initialNumbers)
            {
                Console.WriteLine(item);
            }
        }
        internal static long SumSecretNumbers()
        {
            long sum = 0;


            return sum;
        }
    }
}
