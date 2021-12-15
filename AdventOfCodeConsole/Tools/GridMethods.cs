﻿namespace AdventOfCodeConsole.Tools;

public class GridMethods
{
    public static IEnumerable<Point> AdjacentPoints(int[,] array, int row, int column)
    {
        int rows = array.GetLength(0);
        int columns = array.GetLength(1);

        for (int y = row - 1; y <= row + 1; y++)
            for (int x = column - 1; x <= column + 1; x++)
                if (x >= 0 && y >= 0 && x < columns && y < rows)
                    if (!(y == row && x == column)
                        && !(y == row - 1 && x == column - 1)
                        && !(y == row + 1 && x == column + 1)
                        && !(y == row - 1 && x == column + 1)
                        && !(y == row + 1 && x == column - 1))
                    {
                        yield return new Point(y, x);
                    }
    }

    public static IEnumerable<Point> NeighbouringPoints(int[,] array, int row, int column)
    {
        int rows = array.GetLength(0);
        int columns = array.GetLength(1);

        for (int y = row - 1; y <= row + 1; y++)
            for (int x = column - 1; x <= column + 1; x++)
                if (x >= 0 && y >= 0 && x < columns && y < rows && !(y == row && x == column))
                    yield return new Point(y, x);
    }
}