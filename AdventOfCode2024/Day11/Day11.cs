using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal static class Day11
    {
        internal static int Solution_One()
        {
            //Setup initial stoneList
            string input = "27 10647 103 9 0 5524 4594227 902936";
            string[] stones = input.Split(' ');
            List<long> stoneList = new();
            foreach (string stone in stones)
            {
                long stoneValue = int.Parse(stone);
                stoneList.Add(stoneValue);
            }

            //Loop 25 times
            for (int i = 0; i < 25; i++)
            {
                List<long> tempList = new();
                for (int j = 0; j < stoneList.Count; j++)
                {
                    if (stoneList[j] == 0)
                    {
                        tempList.Add(1);
                    }
                    else if (stoneList[j].ToString().Length % 2 == 0)
                    {
                        string current = stoneList[j].ToString();
                        int length = current.Length;
                        string firstHalf = current.Substring(0, length / 2);
                        string secondHalf = current.Substring(length / 2);
                        tempList.Add(long.Parse(firstHalf));
                        tempList.Add(long.Parse(secondHalf));
                    }
                    else
                    {
                        tempList.Add(stoneList[j] * 2024);
                    }
                }
                stoneList = tempList;
            }
            return stoneList.Count;
        }
    }
}
