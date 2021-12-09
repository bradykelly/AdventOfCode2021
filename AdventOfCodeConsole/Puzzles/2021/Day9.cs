using System.Reflection;
using AdventOfCodeConsole.Tools;

namespace AdventOfCodeConsole.Puzzles._2021;

public class Day9 : IDay
{
    private static List<(int y, int x)> GetLowPoints(int[,] heatMap)
    {
        var rowCount = heatMap.GetLength(0);
        var colCount = heatMap.GetLength(1);

        var lowPoints = new List<(int y, int x)>();
        for (var y = 0; y < rowCount; y++)
        {
            for (var x = 0; x < colCount; x++)
            {
                var height = heatMap[y, x];
                var adjacents = EnumerableMatrixFunctions.AdjacentElementsOrthogonal(heatMap, y, x);

                var isLow = true;
                foreach (var adj in adjacents)
                {
                    if (adj <= height)
                    {
                        isLow = false;
                        break;
                    }
                }

                if (isLow)
                {
                    lowPoints.Add((y, x));
                }
            }
        }

        return lowPoints;
    }

    public long Part1(string input)
    {
        int bigTotal = 0;
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var heatMap = new int[lines.Length, lines[0].Length];

        for (var y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (var x = 0; x < line.Length; x++)
            {
                heatMap[y, x] = line[x] - '0';
            }
        }

        var lows = GetLowPoints(heatMap);

        foreach (var low in lows)
        {
            bigTotal += heatMap[low.y, low.x] + 1;
        }
        return bigTotal;
    }

    public long Part2(string input)
    {
        var bigTotal = 0;





        return bigTotal;
    }
}