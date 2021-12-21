namespace AdventOfCodeConsole.Tools;

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

    /// <summary>
    /// Gets all neighbouring points around a given centre point
    /// </summary>
    /// <param name="array">The grid in which the given coordinates exist</param>
    /// <param name="row">The y coordinate of the centre point</param>
    /// <param name="column">The x coordinate of the centre point</param>
    /// <returns>
    /// A collection of points surrounding the centre coordinates,
    /// excluding points outside of the grid <paramref name="array"/>
    /// </returns>
    public static IEnumerable<Point> NeighbouringPoints(int[,] array, int row, int column)
    {
        int rows = array.GetLength(0);
        int columns = array.GetLength(1);

        for (int y = row - 1; y <= row + 1; y++)
            for (int x = column - 1; x <= column + 1; x++)
                if (x >= 0 && y >= 0 && x < columns && y < rows && !(y == row && x == column))
                    yield return new Point(y, x);
    }

    /// <summary>
    /// Gets all neighbouring points around a given centre point
    /// </summary>
    /// <param name="array">The grid in which the given coordinates exist</param>
    /// <param name="row">The y coordinate of the centre point</param>
    /// <param name="column">The x coordinate of the centre point</param>
    /// <returns>
    /// A collection of points surrounding and including the centre point,
    /// as well as points outside of the grid <paramref name="array"/>
    /// </returns>
    public static IEnumerable<Point> NeighbouringPointsExpanded(int[,] array, Point centre)
    {
        int rows = array.GetLength(0);
        int columns = array.GetLength(1);

        for (int y = centre.Y - 1; y <= centre.Y + 1; y++)
            for (int x = centre.X - 1; x <= centre.X + 1; x++)
                yield return new Point(y, x);
    }
}
