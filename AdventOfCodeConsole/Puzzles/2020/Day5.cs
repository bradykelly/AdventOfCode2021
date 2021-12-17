using Microsoft.Diagnostics.Tracing.Parsers.AspNet;

namespace AdventOfCodeConsole.Puzzles._2020;

public class Day5 : IDay
{
    private enum ReturnPart
    {

    }

    private int GetIndicator(string directions, int dirIndex, (int start, int end) half, bool forRow)
    {
        if (dirIndex == directions.Length - 1)
        {
            return forRow ? half.start : half.end;
        }

        var halfOfHalf = (half.end - half.start + 1) / 2;
        (int start, int end) nextHalf = directions[dirIndex] switch
        {
            'F' => (half.start, half.start + halfOfHalf - 1),
            'B' => (half.start + halfOfHalf, half.end),
            'L' => (half.start, half.start + halfOfHalf - 1),
            'R' => (half.start + halfOfHalf, half.end),
            _ => (0, 0)
        };

        return GetIndicator(directions, dirIndex + 1, nextHalf, forRow);
    }

    public static int DayNumber => 5;

    public ulong Part1(string input)
    {
        var passes = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        var highestId = 0;
        foreach (var pass in passes)
        {
            var row = GetIndicator(pass.Substring(0, 7), 0, (0, 127), true);
            var col = GetIndicator(pass.Substring(7, 3), 0, (0, 7), false);
            var seatId = row * 8 + col;
            highestId = Math.Max(highestId, seatId);
        }

        return (ulong)highestId;
    }

    public ulong Part2(string input)
    {
        return 0;
    }
}
