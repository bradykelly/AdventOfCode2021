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

    public Edge(string start, string end)
    {
        Start = new Node(start);
        End = new Node(end);
    }
}