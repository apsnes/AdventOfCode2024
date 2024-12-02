using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal class Day_One
    {
        internal static List<int> leftColumn = new();
        internal static List<int> rightColumn = new();
        internal static int Solution()
        {
            StreamReader sr = new("DayOne.txt");
            string line;
            while((line = sr.ReadLine()) != null)
            {
                string[] lineParts = line.Split("   ");
                leftColumn.Add(int.Parse(lineParts[0].Trim()));
                rightColumn.Add(int.Parse(lineParts[1].Trim()));
            }
            leftColumn.Sort();
            rightColumn.Sort();
            int totalDistance = 0;
            for(int i = 0; i < leftColumn.Count; i++)
            {
                totalDistance += Math.Abs(leftColumn[i] - rightColumn[i]);
            }
            return totalDistance;
        }
        internal static int Solution_Part_Two()
        {
            Dictionary<int, int> rightColumnCounts = new();
            int similarityScore = 0;
            foreach(int val in rightColumn)
            {
                if(!rightColumnCounts.ContainsKey(val)) rightColumnCounts[val] = 0;
                rightColumnCounts[val]++;
            }
            foreach(int val in leftColumn)
            {
                if (rightColumnCounts.ContainsKey(val))
                {
                    similarityScore += val * rightColumnCounts[val];
                }
            }
            return similarityScore;
        }
    }      
}


