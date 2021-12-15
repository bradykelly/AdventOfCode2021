namespace AdventOfCodeConsole.Tools;

// A directed graph using adjacency list representation
public class Graph
{
    private int _verticeCount;

    private List<int>[] adjList;

    public Graph(int vertices)
    {

        this._verticeCount = vertices;

        InitAdjencyList();
    }

    private void InitAdjencyList()
    {
        adjList = new List<int>[_verticeCount];

        for (int i = 0; i < _verticeCount; i++)
        {
            adjList[i] = new List<int>();
        }
    }

    public void AddEdge(int u, int v)
    {
        adjList[u].Add(v);
    }

    public void PrintAllPaths(int s, int d)
    {
        bool[] isVisited = new bool[_verticeCount];
        List<int> pathList = new List<int>();

        // add source to path[]
        pathList.Add(s);

        // Call recursive utility
        PrintAllPathsUtil(s, d, isVisited, pathList);
    }

    // A recursive function to print all paths from 'u' to 'd'.
    // isVisited[] keeps track of vertices in current path.
    // localPathList<> stores actual vertices in the current path
    private void PrintAllPathsUtil(int u, int d,
                                bool[] isVisited,
                                List<int> localPathList)
    {

        if (u.Equals(d))
        {
            Console.WriteLine(string.Join(" ", localPathList));
            return;
        }

        isVisited[u] = true;

        foreach (int i in adjList[u])
        {
            if (!isVisited[i])
            {
                localPathList.Add(i);
                PrintAllPathsUtil(i, d, isVisited,
                                localPathList);
                localPathList.Remove(i);
            }
        }

        isVisited[u] = false;
    }
}
