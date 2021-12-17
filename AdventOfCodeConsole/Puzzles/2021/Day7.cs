using AdventOfCodeConsole.Tools;

namespace AdventOfCodeConsole.Puzzles._2021;

public class Day7 : IDay
{
    private int GetTriangularFuelCost(int stepCount)
    {
        return stepCount * (stepCount + 1) / 2;
    }

    public ulong Part1(string input)
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

        return (ulong)minFuel;
    }

    public ulong Part2(string input)
    {
        var horizontals = InputReader.GetIntsFromLine(input);
        var minPos = horizontals.ToArray().Min();
        var maxPos = horizontals.ToArray().Max();
        var minFuel = GetTriangularFuelCost((maxPos - minPos) * horizontals.Length);

        for (var candidateAlignment = minPos; candidateAlignment <= maxPos; candidateAlignment++)
        {
            var totalFuel = 0;
            foreach (var crab in horizontals)
            {
                totalFuel += GetTriangularFuelCost(Math.Abs(crab - candidateAlignment));
            }

            minFuel = Math.Min(totalFuel, minFuel);
        }

        return (ulong)minFuel;
    }
}