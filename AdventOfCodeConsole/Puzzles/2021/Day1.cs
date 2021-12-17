using AdventOfCodeConsole.Tools;

namespace AdventOfCodeConsole.Puzzles._2021;

public class Day1 : IDay
{
    public ulong Part1(string input)
    {
        var depths = InputReader.GetIntsFromCsvString(input);
        var increases = 0;
        for (var i = 1; i < depths.Length; i++)
        {
            if (depths[i - 1] < depths[i])
                increases++;
        }

        return (ulong)increases;
    }

    public ulong Part2(string input)
    {
        var depths = InputReader.GetIntsFromCsvString(input);

        var count = 0;
        for (var i = 2; i < depths.Length - 1; i++)
        {
            // (a + b + c'  >  (b + c + d) is the same as a > d
            if (depths[i + 1] > depths[i - 2])
            {
                count++;
            }
        }

        return (ulong)count;
    }
}
