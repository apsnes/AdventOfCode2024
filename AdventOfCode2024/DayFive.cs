using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal static class DayFive
    {
        internal static List<string> rules = new();
        internal static List<List<int>> updates = new();
        internal static void ReadFile()
        {
            bool isRules = true;
            StreamReader sr = new("DayFive.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line == "")
                {
                    isRules = false;
                    continue;
                }
                if (isRules) rules.Add(line);
                else updates.Add(line.Trim().Split(",").Select(int.Parse).ToList());
            }
        }
        //internal static int Solution_One()
        //{
        //    int sum = 0;
        //    foreach (string update in updates)
        //    {
        //        bool isValid = true;
        //        int[] pages = update.Split(",").Select(x => int.Parse(x)).ToArray(); 
        //        foreach (string rule in rules)
        //        {
        //            int[] ruleNums = rule.Split("|").Select(x => int.Parse(x)).ToArray();
        //            if (pages.Contains(ruleNums[0]) && pages.Contains(ruleNums[1]))
        //            {
        //                if (Array.IndexOf(pages, ruleNums[0]) > Array.IndexOf(pages, ruleNums[1]))
        //                {
        //                    isValid = false;
        //                }
        //            }
        //        }
        //        if (isValid)
        //        {
        //            sum += pages[pages.Length / 2];
        //        }
        //    }
        //    return sum; 
        //}
        internal static int Solution_Two()
        {
            var SortedUpdates = updates.Select(i => i.OrderBy(x => x, new CustomComparer(rules))).Select(y => y.ToList()).ToList();
            return SortedUpdates.Where((x, i) => x.SequenceEqual(updates[i]) == false).ToList().Sum(x => x[x.Count / 2]);
        }
        public class CustomComparer(List<string> rules) : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (!rules.Contains(x.ToString()) && rules.Contains(y.ToString()))
                {
                    throw new Exception("Doesnt work");
                }

                string rule = rules.First(r => r.Contains(Convert.ToString(x)) && r.Contains(Convert.ToString(y)));

                string firstNum = rule.Split('|')[0];

                if (firstNum == x.ToString()) return -1;
                return firstNum == y.ToString() ? 1 : 0;

            }
        }
    }
}
