namespace AdventOfCodeConsole.Puzzles._2021;

public class Day10 : IDay
{
    private List<string> _corrupted = new();
    public ulong Part1(string input)
    {
        Dictionary<char, char> _matches = new()
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' },
            { '<', '>' }
        };

        Dictionary<char, int> _scores = new()
        {
            { ')', 3 },
            { ']', 57 },
            { '}', 1197 },
            { '>', 25137 }
        };

        var totalScore = 0;
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var stack = new Stack<char>();
        foreach (var line in lines)
        {
            foreach (var ch in line)
            {
                if (_matches.ContainsKey(ch))
                {
                    stack.Push(ch);
                }
                else if (_matches.ContainsValue(ch))
                {
                    var sp = stack.Pop();
                    if (ch == _matches[sp]) continue;
                    totalScore += _scores[ch];
                    _corrupted.Add(line);
                    break;
                }
            }
        }

        return (ulong)totalScore;
    }

    public ulong Part2(string input)
    {
        Dictionary<char, char> _matches = new()
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' },
            { '>', '<' }
        };

        Dictionary<char, int> scores = new()
        {
            { ')', 1 },
            { ']', 2 },
            { '}', 3 },
            { '>', 4 }
        };

        var scoreList = new List<ulong>();
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var stack = new Stack<char>();
        foreach (var line in lines.Where(l => !_corrupted.Contains(l)))
        {
            foreach (var ch in line)
            {
                if (_matches.ContainsValue(ch))
                {
                    stack.Push(ch);
                }
                else
                {
                    var sp = stack.Pop();
                    if (_matches[ch] != sp)
                    {
                        break;
                    }
                }
            }

            var completion = "";
            while (stack.TryPop(out var ch))
            {
                completion += ch switch
                {
                    '(' => ')',
                    '[' => ']',
                    '{' => '}',
                    '<' => '>',
                    _ => null
                };
            }

            ulong totalScore = 0;
            foreach (var ch in completion)
            {
                totalScore *= 5;
                totalScore += (ulong)scores[ch];
            }
            scoreList.Add(totalScore);
        }

        var middle = scoreList.Count / 2;

        return scoreList.OrderBy(s => s).ToList()[middle];
    }
}
