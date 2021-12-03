namespace AdventOfCodeConsole.Puzzles;

internal static class Day3
{
    private static char MostCommonBit(int pos, string[] binaries)
    {
        var count0 = 0;
        var count1 = 0;
        for (var i = 0; i < binaries.Length; i++)
        {
            if (binaries[i][pos] == '0')
                count0 += 1;
            else
            {
                count1 += 1;
            }
        }

        return count1 > count0 ? '1' : '0';
    }

    private static char LeastCommonBit(int pos, string[] binaries)
    {
        var count0 = 0;
        var count1 = 0;
        for (var i = 0; i < binaries.Length; i++)
        {
            if (binaries[i][pos] == '0')
                count0 += 1;
            else
            {
                count1 += 1;
            }
        }

        return count1 > count0 ? '0' : '1';
    }

    public static int Part1(string input)
    {
        var binary = "";
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        for (var pos = 0; pos < lines[0].Length; pos++)
        {
            var mostCommon = MostCommonBit(pos, lines);
            binary += mostCommon;
        }

        var gamma = Convert.ToInt32(binary, 2);
        
        binary = "";
        for (var pos = 0; pos < lines[0].Length; pos++)
        {
            var leastCommon = LeastCommonBit(pos, lines);
            binary += leastCommon;
        }

        var epsilon = Convert.ToInt32(binary, 2);

        return gamma * epsilon;
    }

    public static int Part2(string input)
    {
        return 0;
    }
}