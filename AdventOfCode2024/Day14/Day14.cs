using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public static class Day14
{
    private static List<Robot> _robots = new();
    
    public static void ReadFile()
    {
        const string pattern = @"p=(?<px>-?\d+),(?<py>-?\d+)\s+v=(?<vx>-?\d+),(?<vy>-?\d+)";
        var regex = new Regex(pattern);
        foreach (Match match in regex.Matches(File.ReadAllText("Day14/Day14.txt")))
        {
            _robots.Add(new Robot(  int.Parse(match.Groups["px"].Value), 102 - int.Parse(match.Groups["py"].Value),
                                    int.Parse(match.Groups["vx"].Value), 0 - int.Parse(match.Groups["vy"].Value)));
        }
    }

    public static long CalculateSafetyFactor()
    {
        var topLeftCount = 0;
        var topRightCount = 0;
        var bottomLeftCount = 0;
        var bottomRightCount = 0;

        foreach (var robot in _robots)
        {
            robot.Px = ((robot.Px + (100 * robot.Vx)) % 101 + 101) % 101;
            robot.Py = ((robot.Py + (100 * robot.Vy)) % 103 + 103) % 103;
            if (robot.Px == 50 || robot.Py == 51) continue;
            if (robot.Px < 50 && robot.Py < 51) topLeftCount++;
            if (robot.Px > 50 && robot.Py < 51) topRightCount++;
            if (robot.Px < 50 && robot.Py > 51) bottomLeftCount++;
            if (robot.Px > 50 && robot.Py > 51) bottomRightCount++;
        }
        return (long)topLeftCount * topRightCount * bottomLeftCount * bottomRightCount;
    }
}

public class Robot(int px, int py, int vx, int vy)
{
    public int Px = px;
    public int Py = py;
    public int Vx = vx;
    public int Vy = vy;
}