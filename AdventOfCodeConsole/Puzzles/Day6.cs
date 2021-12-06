using System.Collections.Immutable;

namespace AdventOfCodeConsole.Puzzles;

public class Day6 : IDay
{
    private Span<int> NextGeneration(Span<int> timers)
    {
        var newTimers = 0;
        var nextGenTimers = new List<int>();

        foreach (var timer in timers)
        {
            int nextDay;
            if (timer == 0)
            {
                nextDay = 6;
                newTimers++;
            }
            else
            {
                nextDay = timer - 1;
            }

            nextGenTimers.Add(nextDay);
        }

        for (var i = 0; i < newTimers; i++)
        {
            nextGenTimers.Add(8);
        }

        return nextGenTimers.ToArray().AsSpan();
    }

    public int Part1(string input)
    {
        var generation = input.Split(',').Select(int.Parse).ToArray().AsSpan();
        for (var day = 0; day < 80; day++)
        {
            generation = NextGeneration(generation);
        }

        return generation.Length;
    }

    public int Part2(string input)
    {
        return 0;
    }
}