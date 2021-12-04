namespace AdventOfCodeConsole.Puzzles
{
    public class Day1: IDay
    {
        private static int[] GetIntsFromInput(string? input)
        {
            return input is null ? Array.Empty<int>() : input
                .Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        public int Part1(string? input)
        {
            var depths = GetIntsFromInput(input);
            return depths
                .Select((n, i) => i != 0 && depths[i - 1] < n)
                .Count(b => b);
        }

        public int Part2(string? input)
        {
            var depths = GetIntsFromInput(input);

            var count = 0;
            for (var i = 2; i < depths.Length - 1; i++)
            {
                // a + b + c  >  b + c + d is the same as a > d
                if (depths[i + 1] > depths[i - 2])
                {
                    count++;
                }
            }

            return count;
        }
    }
}
