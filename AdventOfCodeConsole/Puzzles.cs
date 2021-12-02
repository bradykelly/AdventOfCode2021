using System.Runtime.CompilerServices;

namespace AdventOfCodeConsole
{
    internal static class Puzzles
    {
        private static async Task<int[]> GetIntsForDay(int day)
        {
            var input = await AdventOfCode.GetInputForDay(1);
            var depths = input
                .Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            return depths;
        }

        internal static async Task Day1A()
        {
            var depths = await GetIntsForDay(1);

            var sub = depths
                .Select((n, i) => i != 0 && depths[i - 1] < n)
                .Count(b => b);

            Console.Write(sub);
        }

        internal static async Task Day1B()
        {
            var depths = await GetIntsForDay(1);

            var count = 0;

            for (var i = 2; i < depths.Length - 1; i++)
            {
                // a + b + c  >  b + c + d is the same as a > d
                if (depths[i + 1] > depths[i - 2])
                {
                    count++;
                }
            }

            Console.Write(count);
        }

        internal static async Task Day2A()
        {
            (int horizontal, int vertical) position = (0, 0);

            var input = await AdventOfCode.GetInputForDay(2);
            var directions = input
                .Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            foreach (var direction in directions)
            {
                var move = direction.Split(" ");
                var distance = int.Parse(move[1]);

                switch (move[0])
                {
                    case "forward":
                        position.horizontal += distance;
                        break;
                    case "down":
                        position.vertical += distance;
                        break;
                    case "up":
                        position.vertical -= distance;
                        break;
                }
            }

            Console.WriteLine(position.vertical * position.horizontal);
        }

        internal static async Task Day2B()
        {
            (int horizontal, int vertical) position = (0, 0);
            var aim = 0;

            var input = await AdventOfCode.GetInputForDay(2);
            var directions = input
                .Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            foreach (var direction in directions)
            {
                var move = direction.Split(" ");
                var distance = int.Parse(move[1]);

                switch (move[0])
                {
                    case "forward":
                        position.horizontal += distance;
                        position.vertical += aim * distance;
                        break;
                    case "down":
                        aim += distance;
                        break;
                    case "up":
                        aim -= distance;
                        break;
                }
            }

            Console.WriteLine(position.vertical * position.horizontal);
        }
    }
}
