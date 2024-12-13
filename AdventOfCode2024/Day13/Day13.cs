using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode2024
{
    internal static class Day13
    {
        static List<(long x, long y)> coordinates = new();
        internal static void ReadCoordinates()
        {
            var coords = new List<(int x, int y)>();
            string pattern = @"X[+=](?<X>-?\d+),\s*Y[+=](?<Y>-?\d+)";
            Regex regex = new Regex(pattern);

            coordinates =   File.ReadAllLines("Day13/Day13.txt")
                           .Select(line => regex.Match(line))
                           .Where(match => match.Success)
                           .Select(match => (
                               long.Parse(match.Groups["X"].Value),
                               long.Parse(match.Groups["Y"].Value)))
                           .ToList();
        }

        internal static decimal Solution_One()
        {
            ReadCoordinates();

            decimal tokensSpent = 0;

            for (int i = 0; i < coordinates.Count; i += 3)
            {
                long buttonA_X = coordinates[i].x;
                long buttonA_Y = coordinates[i].y;
                long buttonB_X = coordinates[i + 1].x;
                long buttonB_Y = coordinates[i + 1].y;
                decimal prize_X = coordinates[i + 2].x + 10000000000000;
                decimal prize_Y = coordinates[i + 2].y + 10000000000000;

                bool validCombination = false;

                decimal delta = buttonA_X * buttonB_Y - buttonA_Y * buttonB_X;
                if (delta == 0) continue;
                decimal a = (buttonB_Y * prize_X - buttonB_X * prize_Y) / delta;
                decimal b = (buttonA_X * prize_Y - buttonA_Y * prize_X) / delta;
                if (a % 1 != 0) continue;
                if (b % 1 != 0) continue;
                if ((3 * a) + b < decimal.MaxValue) tokensSpent += (3 * a) + b;
            }
            return tokensSpent;
        }
    }
}
