namespace AdventOfCodeConsole.Tools;

// A directed graph using adjacency list representation
public class Graph
{
    private List<Edge> _edges = new();
    private Stack<Edge> _currentPath = new Stack<Edge>();
    private List<List<Node>> _paths = new();

    public void FindAllPaths(Node start, Node end)
    {
        var routes = _edges.Where(e => e.Start.Equals(start)).ToList();
        foreach (var edge in routes)
        {
            var next = edge.End;
            _currentPath.Push(edge);
            if (next.Equals(end))
            {
                break;
            }
            FindAllPaths(next, end);
        }
    }

    public void AddEdge(string start, string end)
    {
        _edges.Add(new Edge(start, end));
    }
}
