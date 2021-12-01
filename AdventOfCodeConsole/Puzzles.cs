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
            var lines = input.Split('\n').Where(s => s != "").ToList();
            var count = 0;

            for (var i = 1; i < lines.Count; i++)
            {
                if (int.Parse(lines[i - 1]) < int.Parse(lines[i]))
                {
                    count++;
                }
            }

            Console.Write(count);
        }
    }
}
