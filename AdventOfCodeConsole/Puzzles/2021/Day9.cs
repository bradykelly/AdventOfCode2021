using System.Reflection;
using AdventOfCodeConsole.Tools;

namespace AdventOfCodeConsole.Puzzles._2021;

public class Day9 : IDay
{
    public long Part1(string input)
    {
        var bigTotal = 0;

        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var heatMap = new int[lines.Length, lines[0].Length];

        for (var y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (var x = 0; x < line.Length; x++)
            {
                heatMap[y, x] = line[x];
            }
        }

        var rows = heatMap.GetLength(0);
        var cols = heatMap.GetLength(1);

        var lowPoints = new List<int>();
        for (var y = 0; y < rows; y++)
        {
            for (var x = 0; x < cols; x++)
            {
                var height = heatMap[y, x] - '0';
                var adjacents = EnumerableMatrixFunctions.AdjacentElementsOrthogonal(heatMap, y, x).Select(a => a - '0');

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
                    bigTotal += height + 1;
                    //lowPoints.Add(height);
                }
            }
        }

        return bigTotal;
    }

    public long Part2(string input)
    {
        var bigTotal = 0;





        return bigTotal;
    }
}