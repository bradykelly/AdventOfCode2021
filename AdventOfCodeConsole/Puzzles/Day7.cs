using AdventOfCodeConsole.Tools;

namespace AdventOfCodeConsole.Puzzles;

public class Day7 : IDay
{
    private const string Input = "16,1,2,0,4,2,7,1,2,14";

    public long Part1(string input)
    {
        var horizontals = InputReader.GetIntsFromLine(input);
        var minPos = horizontals.ToArray().Min();
        var maxPos = horizontals.ToArray().Max();
        var minFuel = (maxPos - minPos) * horizontals.Length;

        for (var candidateAlignment = minPos; candidateAlignment <= maxPos; candidateAlignment++)
        {
            var totalFuel = 0;
            foreach (var crab in horizontals)
            {
                totalFuel += Math.Abs(crab - candidateAlignment);
            }

            minFuel = Math.Min(totalFuel, minFuel);
        }

        return minFuel;
    }

    public long Part2(string input)
    {
        return 0;
    }
}