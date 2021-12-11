using AdventOfCodeConsole.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeConsole.Puzzles._2021
{
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

        private class Octopus
        {
            private int Y { get; }

            private int X { get; }

            public int Energy { get; set; }

            public bool HasFlashed { get; set; } = false;

            public int RecursiveFlashCount { get; set; } = 0;

            public Octopus(int y, int x, int energy)
            {
                Y = y;
                X = x;
                Energy = energy;
            }

            private IEnumerable<Octopus> NeighbouringOctopuses(Octopus[,] array, int row, int column)
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

            internal bool PowerUp(bool fromFlash = false)
            {
                if (Energy == 0 && fromFlash)
                {
                }
                else
                { 
                    Energy++; 
                }
                if (Energy > 9)
                {
                    Energy = 0;
                    if (!HasFlashed)
                    {
                        var neighbours = NeighbouringOctopuses(_octoGrid, Y, X).ToList();
                        foreach (var octo in neighbours)
                        {
                            var flashed = octo.PowerUp();
                            RecursiveFlashCount += flashed ? 1 : 0;
                        }
                        HasFlashed = true;
                    }
                }
                return HasFlashed;
            }

            public override string ToString()
            {
                return $"{Y},{X}: {Energy}";
            }

            internal void Flash()
            {
                if (HasFlashed) return;

                HasFlashed = true;
                var neighbours = NeighbouringOctopuses(_octoGrid, Y, X);
                foreach(var neighbour in neighbours)
                {
                    neighbour.Energy++;
                }  
                
                foreach(var neighbour in neighbours)
                {
                    if (neighbour.Energy > 9)
                    {
                        neighbour.Flash();
                        neighbour.Energy = 0;
                    }
                }
            }
        }

        public long Part1(string input)
        {
            var bigScore = 0;

            BuildOctoGrid(input);

            for (int i = 0; i < 10; i++)
            {
                for (int y = 0; y < _octoGrid.GetLength(0); y++)
                {
                    for (int x = 0; x < _octoGrid.GetLength(1); x++)
                    {
                        var octo = _octoGrid[y, x];
                        octo.Energy = octo.Energy + 1;
                    }
                }

                for (int y = 0; y < _octoGrid.GetLength(0); y++)
                {
                    for (int x = 0; x < _octoGrid.GetLength(1); x++)
                    {
                        var octo = _octoGrid[y, x];
                        if (octo.Energy > 9)
                        {
                            octo.Flash();
                            octo.Energy = 0;
                        }
                    }
                }
            }
            return bigScore;
        }

        public long Part2(string input)
        {
            return 0;
        }





    }
}
