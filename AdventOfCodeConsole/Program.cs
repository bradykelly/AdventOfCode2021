using AdventOfCodeConsole.Runners;
using AdventOfCodeConsole.Runners._2021;
using AdventOfCodeConsole.Tools;
using BenchmarkDotNet.Running;

#if !DEBUG
    BenchmarkRunner.Run<Day14Runner>();
#else

    // Create a sample graph
    Graph g = new Graph(6);
    g.AddEdge(0, 1);
    g.AddEdge(0, 2);
    g.AddEdge(1, 3);
    g.AddEdge(1, 2);
    g.AddEdge(2, 4);
    g.AddEdge(1, 5);
    g.AddEdge(2, 5);

    g.AddEdge(1, 0);
    g.AddEdge(2, 0);
    g.AddEdge(3, 1);
    g.AddEdge(2, 1);
    g.AddEdge(4, 2);
    g.AddEdge(5, 1);
    g.AddEdge(5, 2);

// arbitrary source
int s = 2;

    // arbitrary destination
    int d = 3;

    Console.WriteLine("Following are all different paths from " + s + " to " + d);
    Console.WriteLine();
    g.PrintAllPaths(s, d);
#endif
