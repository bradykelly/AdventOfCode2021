using System.Text;

namespace AdventOfCodeConsole.Puzzles._2021;

public class Day14 : IDay
{
    public static int DayNumber => 14;

    public ulong Part1(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var rules = lines[1..];

        var workingPolymer = new StringBuilder(lines[0]);

        for (int s = 0; s < 10; s++)
        {
            // Start on our new polymer
            var startPolymer = workingPolymer.ToString();
            workingPolymer = new StringBuilder();

            // Find overlapping pairs.
            var pairs = new List<string>();
            for (var i = 0; i < startPolymer.Length - 1; i++)
            {
                pairs.Add(new string(new[] { startPolymer[i], startPolymer[i + 1] }));
            }

            // Insert rule chars into pairs
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
        }

        Dictionary<char, int> counts = workingPolymer.ToString().GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        var maxChar = counts.Where(x => x.Value == counts.Values.Max()).Select(x => x.Key).Single();
        var minChar = counts.Where(x => x.Value == counts.Values.Min()).Select(x => x.Key).Single();

        return (ulong)(counts[maxChar] - counts[minChar]);
    }

    public ulong Part2(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var rules = lines[1..];

        var workingPolymer = new StringBuilder(lines[0]);
        Dictionary<char, int> counts = new();

        void IncrementCharCount(char charToCount)
        {
            if (!counts.ContainsKey(charToCount))
                counts.Add(charToCount, 1);
            else
                counts[charToCount]++;
        }

        for (int s = 0; s < 10; s++)
        {
            // Start on our new polymer
            var startPolymer = workingPolymer.ToString();
            workingPolymer = new StringBuilder();

            // Find overlapping pairs.
            var pairs = new List<string>();
            for (var i = 0; i < startPolymer.Length - 1; i++)
            {
                pairs.Add(new string(new[] { startPolymer[i], startPolymer[i + 1] }));
            }

            // Insert rule chars into pairs
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
        }

        var maxChar = counts.Where(x => x.Value == counts.Values.Max()).Select(x => x.Key).Single();
        var minChar = counts.Where(x => x.Value == counts.Values.Min()).Select(x => x.Key).Single();

        return (ulong)(counts[maxChar] - counts[minChar]);
    }
}

