using Microsoft.Win32;

namespace AdventOfCode2024;

internal class Program
{
    static void Main(string[] args)
    {
        Day18.ReadFile();
        Console.WriteLine(Day18.CalculateCutOff());
    }
}
