namespace AdventOfCodeConsole.Puzzles._2021;

public class Day1 : IDay
{
    private static int[] GetIntsFromInput(string input)
    {
        var ints = new List<int>();
        if (ints.Count == 0)
        {
            var lines = input
                .Split('\n');
            foreach (var line in lines)
            {
                if (line != string.Empty)
                {
                    ints.Add(int.Parse(line));
                }
            }
        }

        return ints.ToArray();
    }

    public long Part1(string input)
    {
        var depths = GetIntsFromInput(input);
        var increases = 0;
        for (var i = 1; i < depths.Length; i++)
        {
            if (depths[i - 1] < depths[i])
                increases++;
        }

        return increases;
    }

    public long Part2(string input)
    {
        var depths = GetIntsFromInput(input);

        var count = 0;
        for (var i = 2; i < depths.Length - 1; i++)
        {
            // (a + b + c'  >  (b + c + d) is the same as a > d
            if (depths[i + 1] > depths[i - 2])
            {
                count++;
            }
        }

        return count;
    }
}
