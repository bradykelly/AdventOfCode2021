namespace AdventOfCodeConsole.Puzzles._2021;

public class Day6 : IDay
{
    private void MakeGenerations(int days, long[] generation)
    {
        var hitZero = false;

        for (int day = 0; day < days; day++)
        {
            if (generation[0] >= 1)
            {
                hitZero = true;
            }

            var prevGenZero = generation[0];
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
        var fish = input.Split(',').Select(byte.Parse);

        long[] counts = new long[9];
        foreach (var counter in fish)
        {
            counts[counter] += 1;
        }

        MakeGenerations(days, counts);

        return counts.Sum();
    }

    public static int DayNumber => 6;

    public ulong Part1(string input)
    {
        return (ulong)CalculateFish(input, 80);
    }

    public ulong Part2(string input)
    {
        return (ulong)CalculateFish(input, 256);
    }
}