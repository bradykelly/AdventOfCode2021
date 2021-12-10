namespace AdventOfCodeConsole.Puzzles._2021
{
    public class Day10 : IDay
    {
        private readonly string _opening = "([{<";
        private readonly Dictionary<char, int> _closing = new Dictionary<char, int>
        {
            { ')', 3 },
            { ']', 57 },
            { '}', 1197},
            { '>', 25137}
        };

        public long Part1(string input)
        {
            var totalScore = 0;

            var openCount = 0;
            var closeCount = 0;

            var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            var stack = new Stack<char>();
            var maxLen = lines.Select(l => l.Length).Max();

            foreach (var line in lines)
            {
                if (line.Length != maxLen)
                {
                    continue;
                }

                foreach (var ch in line)
                {
                    if (_opening.Contains(ch))
                    {
                        stack.Push(ch);
                        openCount++;
                    }

                    else if (_closing.ContainsKey(ch))
                    {
                        closeCount++;
                        var a = stack.Pop();
                        if (!(a == '(' && ch == ')' || a == '[' && ch == ']' || a == '{' && ch == '}' || a == '<' && ch == '>'))
                        {
                            totalScore += _closing[ch];
                            break;
                        }
                    }

                    if (ch == line[^1])
                    {
                        if (openCount != closeCount)
                        {
                            if (_closing.ContainsKey(ch))
                            {
                                totalScore += _closing[ch];
                            }
                        }
                    }
                }
            }

            return totalScore;
        }

        private bool ValidatePerBraces(char a, char b)
        {
            return a == '(' && b == ')' || a == '[' && b == ']' || a == '{' && b == '}';
        }

        public long Part2(string input)
        {
            return 0;
        }
    }
}
