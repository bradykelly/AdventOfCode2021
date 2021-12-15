using System.Text;

namespace AdventOfCodeConsole.Puzzles._2021;

public class Day14 : IDay
{
    public long Part1(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        var origPolymer = lines[0].ToArray();
        var rules = lines[1..^1];
        var workingPolymer = new StringBuilder();

        // Find overlapping pairs.
        var pairs = new List<string>();
        for (var i = 0; i < origPolymer.Length - 1; i++)
        {
            pairs.Add(new string(new[] { origPolymer[i], origPolymer[i + 1] }));
        }

        var threes = new List<string>();
        foreach (var pair in pairs)
        {
            var ruleSplit = rules.SingleOrDefault(r => r.StartsWith(pair))?.Split(" -> ");
            if (ruleSplit != null)
            {
                threes.Add(pair[0] + ruleSplit[1] + pair[1]);
            }
        }

        for (int i = 0; i < threes.Count; i++)
        {
            if (i == 0)
            {
                workingPolymer.Append(threes[i]);
            }
            else
            {
                workingPolymer.Append(threes[i][1..]);
            }
        }


        return 0;
    }

    public long Part2(string input)
    {
        return 0;
    }
}
