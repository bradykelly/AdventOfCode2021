using System.Dynamic;

namespace AdventOfCodeConsole.Tools;

public record Point
{
    public long Y { get; init; }
    public long X { get; init; }

    public Point()
    {
    }

    public Point(long y, long x)
    {
        Y = y;
        X = x;
    }

    public override string ToString()
    {
        return $"{Y},{X}";
    }
}