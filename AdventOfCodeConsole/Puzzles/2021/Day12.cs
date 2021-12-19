using AdventOfCodeConsole.Tools.Graphs;

namespace AdventOfCodeConsole.Puzzles._2021
{
    public class Day12 : IDay
    {
        public static int DayNumber => 12;

        private Dictionary<string, List<string>> _graph = new();

        private void AddAdjacency(string start, HashSet<string> ends)
        {
            if (!_graph.ContainsKey(start))
                _graph.Add(start, ends.ToList());
            else
                _graph[start].AddRange(ends);
        }

        private IEnumerable<List<string>> Traverse(
                Dictionary<string, List<string>> graph,
                string current,
                string end,
                IEnumerable<string> path = null)
        {
            path ??= new List<string>();

            if (char.IsLower(current[0]))
            {
                if (path.Contains(current))
                    yield break;
            }

            path = path.Append(current);

            if (current == end)
            {
                yield return path.ToList();
                yield break;
            }

            foreach (var neighbour in graph[current])
            {
                foreach (var subPath in Traverse(graph, neighbour, end, path))
                {
                    yield return subPath;
                }
            }
        }

        public ulong Part1(string input)
        {
            var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var edgeSplit = line.Split('-');
                //AddAdjacencies(new Edge(new Vertex(edgeSplit[0]), new Vertex(edgeSplit[1])));
            }

            _graph.Add("start", new List<string> { "A", "b" });
            _graph.Add("A", new List<string> { "c", "b", "end" });
            _graph.Add("b", new List<string> { "A", "d", "end" });
            _graph.Add("c", new List<string> { "A" });
            _graph.Add("d", new List<string> { "b" });
            _graph.Add("end", new List<string> { "A", "b" });

            var result = Traverse(_graph, "start", "end");

            foreach (var path in result)
            {
                Console.WriteLine(string.Join(',', path));
            }

            return (ulong)result.Count();
        }

        public ulong Part2(string input)
        {
            return 0;
        }
    }
}
