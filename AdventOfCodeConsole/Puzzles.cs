using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeConsole
{
    internal static class Puzzles
    {
        internal static async Task Day1A()
        {
            var input = await AdventOfCode.GetInputForDay(1);
            var lines = input
                .Split('\n')
                .Where(n => n != "")
                .Select(int.Parse)
                .ToList();

            var sub = lines
                .Select((n, i) => i != 0 && lines[i - 1] < n)
                .Count(b => b);

            Console.Write(sub);
        }
    }
}
