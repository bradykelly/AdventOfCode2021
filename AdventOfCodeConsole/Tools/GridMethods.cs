namespace AdventOfCodeConsole.Tools;

public class GridMethods
{
    /// <summary>
    /// Gets all neighbouring points around a given centre point
    /// </summary>
    /// <param name="array">The grid in which the given coordinates exist</param>
    /// <param name="row">The y coordinate of the centre point</param>
    /// <param name="column">The x coordinate of the centre point</param>
    /// <returns>
    /// A collection of points surrounding the centre coordinates, excluding
    /// diagonally adjacent points and points outside of <paramref name="array"/>
    /// </returns>
    public static IEnumerable<Point> AdjacentPoints(long[,] array, long row, long column)
    {
        long rows = array.GetLongLength(0);
        long columns = array.GetLongLength(1);

        for (long y = row - 1; y <= row + 1; y++)
            for (long x = column - 1; x <= column + 1; x++)
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

    /// <summary>
    /// Gets all neighbouring points around a given centre point
    /// </summary>
    /// <param name="array">The grid in which the given coordinates exist</param>
    /// <param name="row">The y coordinate of the centre point</param>
    /// <param name="column">The x coordinate of the centre point</param>
    /// <returns>
    /// A collection of points surrounding the centre coordinates,
    /// excluding points outside of <paramref name="array"/>
    /// </returns>
    public static IEnumerable<Point> NeighbouringPoints(int[,] array, int row, int column)
    {
        long rows = array.GetLongLength(0);
        long columns = array.GetLongLength(1);

        for (int y = row - 1; y <= row + 1; y++)
            for (int x = column - 1; x <= column + 1; x++)
                if (x >= 0 && y >= 0 && x < columns && y < rows && !(y == row && x == column))
                    yield return new Point(y, x);
    }
}
