namespace AdventOfCodeConsole.Tools.Graphs;

public readonly record struct Vertex(string Name)
{
    public Point Start { get; init; } = new();
    public Point End { get; init; } = new();
}