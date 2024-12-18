using Microsoft.Win32;

namespace AdventOfCode2024;

internal class Program
{
    static void Main(string[] args)
    {
        Day18.ReadFile();
        Day18.WriteBlocks();
        Console.WriteLine(Day18.CalculateShortestPath());
    }
}
