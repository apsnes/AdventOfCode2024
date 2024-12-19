using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal static class Day19
    {
        private static HashSet<string> combinations;
        private static List<string> towelDesigns;

        internal static void ReadFiles()
        {
            combinations = [.. File.ReadAllText("Day19/combinations.txt").Split(", ")];
            towelDesigns = [.. File.ReadAllLines("Day19/towelDesigns.txt")];
        }
        internal static (int, long) ValidDesigns()
        {
            int validDesignCount = 0;
            long validCombinationCount = 0;
            foreach (string design in towelDesigns)
            {
                if (IsValidDesign(design)) validDesignCount++;
                validCombinationCount += CountValidCombinations(design);
            }
            return (validDesignCount, validCombinationCount);
        }
        private static bool IsValidDesign(string design)
        {
            //Keep an array of booleans to keep track of which indexes have been seen
            bool[] seen = new bool[design.Length + 1];
            //Keep a queue of indexes to check
            Queue<int> indexQueue = new();
            //Enqueue start point
            indexQueue.Enqueue(0);
            //While there are still indexes to check
            while (indexQueue.Count > 0)
            {
                int start = indexQueue.Dequeue();
                //If we're past the end of the string, return true
                if (start == design.Length) return true;
                //Iterate from start + 1 to the end of the string to check all possible substrings
                for (int end = start + 1; end <= design.Length; end++)
                {
                    //If the substring from start to end is in the combinations, and we haven't seen this index before
                    if (combinations.Contains(design[start..end]) && !seen[end])
                    {
                        //Mark this index as seen
                        seen[end] = true;
                        //Enqueue the end index
                        indexQueue.Enqueue(end);
                    }
                }
            }
            return false;
        }
        private static int CountValidCombinations(string design)
        {
            int[] dp = new int[design.Length + 1];
            dp[0] = 1;
            for (int i = 0; i < design.Length; i++)
            {
                if (dp[i] > 0)
                {
                    for (int j = i + 1; j <= design.Length; j++)
                    {
                        if (combinations.Contains(design[i..j]))
                        {
                            dp[j] += dp[i];
                        }
                    }
                }
            }
            return dp[design.Length];
        }
    }
}
