using System.Diagnostics;

namespace AdventOfCodeConsole.Puzzles._2021
{
    public class Day10 : IDay
    {
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

            var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            var stack = new Stack<char>();

            foreach (var line in lines)
            {
                foreach (var ch in line)
                {
                    if (ch is '(' or '[' or '{' or '<')
                    {   
                        stack.Push(ch);
                    }

                    else
                    {
                        var score = ch switch
                        {
                            ')' => 3,
                            ']' => 57,
                            '}' => 1197,
                            '>' => 25137,
                            _ => 0
                        };
                        if (score > 0)
                        {
                            var sp = stack.Pop();
                            if (!(sp == '(' && ch == ')' || sp == '[' && ch == ']' || sp == '{' && ch == '}' || sp == '<' && ch == '>'))
                            {
                                totalScore += score;
                                break;
                            }
                        }
                    }
                }
            }

            return totalScore;
        }

        public long Part2(string input)
        {
            return 0;
        }
    }
}
