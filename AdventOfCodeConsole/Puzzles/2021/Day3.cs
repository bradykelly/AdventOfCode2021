using System.Runtime.CompilerServices;
using System.Text;

namespace AdventOfCodeConsole.Puzzles._2021;

public class Day3 : IDay
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static char? MostCommonBit(int pos, List<string> binaries)
    {
        var count0 = 0;
        var count1 = 0;
        foreach (var bin in binaries)
        {
            switch (bin[pos])
            {
                case '0':
                    count0 += 1;
                    break;
                default:
                    count1 += 1;
                    break;
            }
        }

        return count1 == count0 ? null : count1 > count0 ? '1' : '0';
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static char? LeastCommonBit(int pos, List<string> binaries)
    {
        var count0 = 0;
        var count1 = 0;
        foreach (var bin in binaries)
        {
            switch (bin[pos])
            {
                case '0':
                    count0 += 1;
                    break;
                default:
                    count1 += 1;
                    break;
            }
        }

        return count1 == count0 ? null : count1 > count0 ? '0' : '1';
    }

    public static int DayNumber => 3;

    public ulong Part1(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
        var lineLength = lines[0].Length;

        var gammaBinary = new StringBuilder(lineLength);
        var epsilonBinary = new StringBuilder(lineLength);

        for (var pos = 0; pos < lineLength; pos++)
        {
            var mostCommon = MostCommonBit(pos, lines);
            gammaBinary.Append(mostCommon);

            var leastCommon = LeastCommonBit(pos, lines);
            epsilonBinary.Append(leastCommon);
        }

        var gamma = Convert.ToInt32(gammaBinary.ToString(), 2);
        var epsilon = Convert.ToInt32(epsilonBinary.ToString(), 2);

        return (ulong)(gamma * epsilon);
    }

    public ulong Part2(string input)
    {
        var binaries = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
        var binaryLength = binaries[0].Length;

        var oxygenNumbers = binaries;
        for (var pos = 0; pos < binaryLength; pos++)
        {
            var mostCommon = MostCommonBit(pos, oxygenNumbers);
            oxygenNumbers = oxygenNumbers.Count switch
            {
                > 1 => oxygenNumbers.Where(bin => bin[pos] == (mostCommon ?? '1')).ToList(),
                _ => oxygenNumbers
            };
        }

        var co2Numbers = binaries;
        for (var pos = 0; pos < binaryLength; pos++)
        {
            var leastCommon = LeastCommonBit(pos, co2Numbers);
            co2Numbers = co2Numbers.Count switch
            {
                > 1 => co2Numbers.Where(bin => bin[pos] == (leastCommon ?? '0')).ToList(),
                _ => co2Numbers
            };
        }

        var support = Convert.ToInt32(oxygenNumbers[0], 2) * Convert.ToInt32(co2Numbers[0], 2);
        return (ulong)support;
    }
}