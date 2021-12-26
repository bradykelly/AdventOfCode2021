//Iterate through the matrix, calling maybe-flash.
//    If an octopus's energy level is 9 when called with maybe-flash, it calls flash! on itself, else it increments its energy level.
//    flash! iterates through its neighbors, calling maybe-flash on each.

using System.Diagnostics;

namespace AdventOfCodeConsole.Puzzles._2021;

public class Day11 : IDay
{
    public static int DayNumber => 11;

    private static Octopus[,] OctoGrid = new Octopus[0, 0];

    public static void DebugGrid()
    {
        for (int y = 0; y < OctoGrid.GetLongLength(0); y++)
        {
            for (int x = 0; x < OctoGrid.GetLongLength(1); x++)
            {
                Debug.Write(OctoGrid[y, x].Energy);
            }
            Debug.WriteLine(null);
        }
    }

    private static void BuildGrid(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        OctoGrid = new Octopus[lines.Length, lines[0].Length];
        for (int y = 0; y < OctoGrid.GetLongLength(0); y++)
        {
            string line = lines[y];
            for (int x = 0; x < line.Length; x++)
            {
                char ch = line[x];
                OctoGrid[y, x] = new Octopus(y, x, ch - '0');
            }
        }
    }

    private class Octopus
    {
        public int Y { get; }

        public int X { get; }

        public int Energy { get; set; }

        public Octopus(int y, int x, int energy)
        {
            Y = y;
            X = x;
            Energy = energy;
        }

        public static IEnumerable<Octopus> GetNeighbours(Octopus[,] array, int row, int column)
        {
            long rows = array.GetLongLength(0);
            long columns = array.GetLongLength(1);

            for (int y = row - 1; y <= row + 1; y++)
                for (int x = column - 1; x <= column + 1; x++)
                    if (x >= 0 && y >= 0 && x < columns && y < rows && !(y == row && x == column))
                    {
                        yield return array[y, x];
                    }
        }

        public override string ToString()
        {
            return $"{Y},{X}: {Energy}";
        }

        public int Flash(Octopus[,] grid)
        {
            var count = 1;

            var neighbours = GetNeighbours(grid, this.Y, this.X);
            foreach (var nb in neighbours)
            {
                nb.Energy++;
                if (nb.Energy is 10)
                {
                    count += nb.Flash(grid);
                }
            }

            return count;
        }
    }

    private static int Step()
    {
        var count = 0;

        for (int y = 0; y < OctoGrid.GetLongLength(0); y++)
        {
            for (int x = 0; x < OctoGrid.GetLongLength(1); x++)
            {
                OctoGrid[y, x].Energy++;
                if (OctoGrid[y, x].Energy is 10)
                    count += OctoGrid[y, x].Flash(OctoGrid);
            }
        }

        for (int y = 0; y < OctoGrid.GetLongLength(0); y++)
        {
            for (int x = 0; x < OctoGrid.GetLongLength(1); x++)
            {
                if (OctoGrid[y, x].Energy > 9)
                    OctoGrid[y, x].Energy = 0;
            }
        }

        return count;
    }

    public ulong Part1(string input)
    {
        BuildGrid(input);

        var flashCount = 0;
        for (int i = 0; i < 100; i++)
        {
            flashCount += Step();
        }

        return (ulong)flashCount;
    }

    public ulong Part2(string input)
    {
        BuildGrid(input);

        var i = 1;
        while (Step() is not 100)
            i++;

        return (ulong)i;
    }
}
