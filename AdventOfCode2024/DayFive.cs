using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal static class DayFive
    {
        static List<string> rules = new();
        static List<string> updates = new();
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
                else updates.Add(line);
            }
       }
        internal static int Solution_One()
        {
            int sum = 0;
            foreach (string update in updates)
            {
                bool isValid = true;
                int[] pages = update.Split(",").Select(x => int.Parse(x)).ToArray(); 
                foreach (string rule in rules)
                {
                    int[] ruleNums = rule.Split("|").Select(x => int.Parse(x)).ToArray();
                    if (pages.Contains(ruleNums[0]) && pages.Contains(ruleNums[1]))
                    {
                        if (Array.IndexOf(pages, ruleNums[0]) > Array.IndexOf(pages, ruleNums[1]))
                        {
                            isValid = false;
                        }
                    }
                }
                if (isValid)
                {
                    sum += pages[pages.Length / 2];
                }
            }
            return sum;
        }
    }
}
