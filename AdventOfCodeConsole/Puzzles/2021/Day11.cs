//Iterate through the matrix, calling maybe-flash.
//    If an octopus's energy level is 9 when called with maybe-flash, it calls flash! on itself, else it increments its energy level.
//    flash! iterates through its neighbors, calling maybe-flash on each.

using System.Diagnostics;

namespace AdventOfCodeConsole.Puzzles._2021;

public class Day11 : IDay
{
    static Octopus[,] _octoGrid;

    public static void DebugGrid()
    {
        for (int y = 0; y < _octoGrid.GetLength(0); y++)
        {
            for (int x = 0; x < _octoGrid.GetLength(1); x++)
            {
                Debug.Write(_octoGrid[y, x].Energy);
            }
            Debug.WriteLine(null);
        }
    }

    private static void BuildOctoGrid(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        _octoGrid = new Octopus[lines.Length, lines[0].Length];
        for (int y = 0; y < _octoGrid.GetLength(0); y++)
        {
            string? line = lines[y];
            for (int x = 0; x < line.Length; x++)
            {
                char ch = line[x];
                _octoGrid[y, x] = new Octopus(y, x, ch - '0');
            }
        }
    }

    private static int _flashCount = 0;

    private class Octopus
    {
        public int Y { get; }

        public int X { get; }

        public int Energy { get; set; }

        public bool WasVisited { get; set; }

        public bool HasFlashed { get; set; } = false;

        public Octopus(int y, int x, int energy)
        {
            Y = y;
            X = x;
            Energy = energy;
        }

        public static IEnumerable<Octopus> NeighbouringOctopuses(Octopus[,] array, int row, int column)
        {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);

            for (int y = row - 1; y <= row + 1; y++)
                for (int x = column - 1; x <= column + 1; x++)
                    if (x >= 0 && y >= 0 && x < columns && y < rows && !(y == row && x == column))
                    {
                        var oct = array[y, x];
                        yield return array[y, x];
                    }
        }

        public override string ToString()
        {
            return $"{Y},{X}: {Energy}";
        }

        internal void Increment()
        {
            Energy++;
            if (Energy > 9 && !HasFlashed) Flash();
        }

        internal void Flash()
        {
            HasFlashed = true;
            Energy = 0;
            _flashCount += 1;
        }
    }

    public static int DayNumber => 11;

    public ulong Part1(string input)
    {
        BuildOctoGrid(input);

        for (int i = 0; i < 100; i++)
        {
            for (int y = 0; y < _octoGrid.GetLength(0); y++)
            {
                for (int x = 0; x < _octoGrid.GetLength(1); x++)
                {
                    var octo = _octoGrid[y, x];
                    octo.Increment();
                    if (octo.HasFlashed)
                    {
                        var neighbours = Octopus.NeighbouringOctopuses(_octoGrid, octo.Y, octo.X);
                        foreach (var neighbour in neighbours.Where(n => !n.HasFlashed))
                        {
                            neighbour.Increment();
                        }
                    }
                }
            }
        }

        return (ulong)_flashCount;
    }

    public ulong Part2(string input)
    {
        return 0;
    }





}
