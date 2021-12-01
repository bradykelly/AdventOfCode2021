using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
