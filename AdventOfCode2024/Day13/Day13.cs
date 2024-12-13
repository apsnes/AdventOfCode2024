using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode2024
{
    internal static class Day13
    {
        static List<(int x, int y)> coordinates = new();
        internal static void ReadCoordinates()
        {
            var coords = new List<(int x, int y)>();
            string pattern = @"X[+=](?<X>-?\d+),\s*Y[+=](?<Y>-?\d+)";
            Regex regex = new Regex(pattern);

            coordinates =   File.ReadAllLines("Day13/Day13.txt")
                           .Select(line => regex.Match(line))
                           .Where(match => match.Success)
                           .Select(match => (
                               int.Parse(match.Groups["X"].Value),
                               int.Parse(match.Groups["Y"].Value)))
                           .ToList();
        }

        internal static int Solution_One()
        {
            ReadCoordinates();

            int tokensSpent = 0;

            for (int i = 0; i < coordinates.Count; i += 3)
            {
                int buttonA_X = coordinates[i].x;
                int buttonA_Y = coordinates[i].y;
                int buttonB_X = coordinates[i + 1].x;
                int buttonB_Y = coordinates[i + 1].y;
                int prize_X = coordinates[i + 2].x;
                int prize_Y = coordinates[i + 2].y;

                int minTokensSpent = int.MaxValue;

                bool validCombination = false;

                for (int a = 0; a <= 100; a++)
                {
                    int numeratorX = prize_X - buttonA_X * a;

                    if (numeratorX < 0) break; 

                    if (numeratorX % buttonB_X == 0)
                    {
                        int b = numeratorX / buttonB_X;

                        if (b >= 0 && b <= 100)
                        {
                            if (buttonA_Y * a + buttonB_Y * b == prize_Y)
                            {
                                validCombination = true;
                                minTokensSpent = Math.Min((a * 3) + b, minTokensSpent);
                            }
                        }
                    }
                }
                if (validCombination) tokensSpent += minTokensSpent;
            }
            return tokensSpent;
        }
    }
}
