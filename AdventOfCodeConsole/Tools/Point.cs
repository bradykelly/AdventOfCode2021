namespace AdventOfCodeConsole.Tools;

// BKTODO Make struct
public class Point
{
    public int Y;
    public int X;

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