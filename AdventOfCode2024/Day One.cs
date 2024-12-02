using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal class Day_One
    {
        internal static int Solution()
        {
            List<int> leftColumn = new();
            List<int> rightColumn = new();
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
    }      
}


