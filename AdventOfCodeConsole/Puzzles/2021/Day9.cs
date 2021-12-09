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

        for (var y = 0; y < rows; y++)
        {
            for (var x = 0; x < cols; x++)
            {
                var adjacents = EnumerableMatrixFunctions.AdjacentElementsOrthogonal(heatMap, y, x);

                var z = adjacents.Select(a => a - '0');
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