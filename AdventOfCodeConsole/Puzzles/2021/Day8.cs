using Microsoft.Diagnostics.Tracing.Parsers.AspNet;

namespace AdventOfCodeConsole.Puzzles._2021
{
    public class Day8 : IDay
    {
        private int GetRow(string directions, int dirIndex, (int start, int end) half)
        {
            var halfOfHalf = (half.end - half.start + 1) / 2;
            if (dirIndex == directions.Length - 1)
            {
                return half.start;
            }
            var dir = directions[dirIndex];
            (int start, int end) nextHalf = dir switch
            {
                'F' => (half.start, half.start + halfOfHalf - 1),
                'B' => (half.start + halfOfHalf, half.end)
            };
            return GetRow(directions, dirIndex + 1, nextHalf);
        }

        public long Part1(string input)
        {
            var passes = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            var pass = "FBFBBFFRLR";
            var row = GetRow(pass.Substring(0, 7), 0, (0, 127));

            return 0;
        }

        public long Part2(string input)
        {
            return 0;
        }
    }
}