namespace AdventOfCodeConsole.Tools;

public struct Edge
{
    public Node Start { get; }

    public Node End { get; }

    public Edge(Node start, Node end)
    {
        Start = start;
        End = end;
    }
}