using System.Text;

namespace AdventOfCode2024;

public static class Day15
{
    private static List<List<char>> map = new();
    private static string instructions = "";
    private static int rowIndex = 1;
    private static int colIndex = 1;

    public static void ReadFile()
    {
        string input = File.ReadAllText("Day15/Day15.txt");
        string[] mapAndInstructions = input.Split("\r\n\r\n");
        instructions = mapAndInstructions[1];
        
        string[] mapParts = mapAndInstructions[0].Split("\r\n");

        for (int i = 0; i < mapParts.Length; i++)
        {
            map.Add(new List<char>());
        }
        
        for (int i = 0; i < mapParts.Length; i++)
        {
            foreach (char c in mapParts[i])
            {
                map[i].Add(c);
            }
        }
    }

    public static long Solution_One()
    {
        for (int i = 0; i < map.Count; i++)
        {
            for (int j = 0; j < map[i].Count; j++)
            {
                if (map[i][j] == '@')
                {
                    rowIndex = i;
                    colIndex = j;
                }
            }
        }
        foreach (char c in instructions)
        {
            ShiftArray(c);
        }

        long GPSSum = 0;
        for (int i = 0; i < map.Count; i++)
        {
            for (int j = 0; j < map[i].Count; j++)
            {
                if (map[i][j] == 'O')
                {
                    GPSSum += (i * 100) + j;
                }
            }
        }
        return GPSSum;
    }

    public static void ShiftArray(char direction)
    {
        if (rowIndex == map.Count - 1 || rowIndex == 0) return;
        if (colIndex == map[0].Count - 1 || colIndex == 0) return;
        if (direction == '>')
        {
            StringBuilder sb = new();
            for (int i = colIndex; i < map[rowIndex].Count; i++)
            {
                sb.Append(map[rowIndex][i]);
            }
            char[] currentArray = sb.ToString().ToCharArray();
            if (!currentArray.Contains('.')) return;
            int firstBlock = Array.IndexOf(currentArray, '#');
            int firstSpace = Array.IndexOf(currentArray, '.');
            if (firstBlock < firstSpace) return;
            for (int i = firstSpace; i >= colIndex; i--)
            {
                map[rowIndex][i] = map[rowIndex][i - 1];
            }
            map[rowIndex][colIndex] = '.';
            colIndex++;
        }
        if (direction == '<')
        {
            StringBuilder sb = new();
            for (int i = 0; i <= colIndex; i++)
            {
                sb.Append(map[rowIndex][i]);
            }
            char[] currentArray = sb.ToString().ToCharArray();
            if (!currentArray.Contains('.')) return;
            int firstBlock = Array.LastIndexOf(currentArray, '#');
            int firstSpace = Array.LastIndexOf(currentArray, '.');
            if (firstBlock > firstSpace) return;
            for (int i = firstSpace; i <= colIndex; i++)
            {
                map[rowIndex][i] = map[rowIndex][i + 1];
            }
            map[rowIndex][colIndex] = '.';
            colIndex--;
        }
        if (direction == '^')
        {
            StringBuilder sb = new();
            for (int i = 0; i <= rowIndex; i++)
            {
                sb.Append(map[i][colIndex]);
            }
            char[] currentArray = sb.ToString().ToCharArray();
            if (!currentArray.Contains('.')) return;
            int firstBlock = Array.LastIndexOf(currentArray, '#');
            int firstSpace = Array.LastIndexOf(currentArray, '.');
            if (firstBlock > firstSpace) return;
            for (int i = firstSpace; i <= rowIndex; i++)
            {
                map[i][colIndex] = map[i + 1][colIndex];
            }
            map[rowIndex][colIndex] = '.';
            rowIndex--;
        }
        if (direction == 'v')
        {
            StringBuilder sb = new();
            for (int i = rowIndex; i < map.Count; i++)
            {
                sb.Append(map[i][colIndex]);
            }
            char[] currentArray = sb.ToString().ToCharArray();
            if (!currentArray.Contains('.')) return;
            int firstBlock = Array.IndexOf(currentArray, '#');
            int firstSpace = Array.IndexOf(currentArray, '.');
            if (firstBlock < firstSpace) return;
            for (int i = firstSpace; i >= rowIndex; i--)
            {
                map[i][colIndex] = map[i - 1][colIndex];
            }
            map[rowIndex][colIndex] = '.';
            rowIndex++;
        }
    }
}