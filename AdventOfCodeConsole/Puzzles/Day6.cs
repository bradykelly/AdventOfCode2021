namespace AdventOfCodeConsole.Puzzles;

public class Day6 : IDay
{
    private void MakeGenerations(int days, int[] generation)
    {
        var hitZero = false;

        int prevGenZero = 0;
        for (int day = 0; day < days; day++)
        {
            if (generation[0] >= 1)
            {
                hitZero = true;
            }

            prevGenZero = generation[0];
            for (var counter = 0; counter < generation.Length - 1; counter++)
            {
                generation[counter] = generation[counter + 1];
            }
            generation[^1] = 0;

            if (hitZero)
            {
                generation[6] += prevGenZero;
                generation[8] += prevGenZero;
                hitZero = false;
            }
        }
    }

    private long CalculateFish(string input, int days)
    {
        //The key is to not store all the timers, but a counter for each current timer
        //That is, 500 lanternfish at timer 0, 1000 at timer 1, 1500 at timer 2, etc
        var counters = input.Split(',').Select(byte.Parse);

        int[] generations = new int[9];
        foreach (var fish in counters)
        {
            generations[fish] += 1;
        }

        MakeGenerations(days, generations);

        return generations.Sum();
    }

    public long Part1(string input)
    {
        return CalculateFish(input, 80);
    }

    public long Part2(string input)
    {
        //return CalculateFish(input, 256);
        return 0;
    }
}