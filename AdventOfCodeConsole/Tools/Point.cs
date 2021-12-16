using System.Dynamic;

namespace AdventOfCodeConsole.Tools;

// BKTODO Make struct
public record Point
{
    public int Y { get; init; }
    public int X { get; init; }

    public Point()
    {
    }

    public Point(int y, int x)
    {
        Y = y;
        X = x;
    }

    public override string ToString()
    {
        return $"{Y},{X}";
    }
}