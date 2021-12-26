// ReSharper disable PossibleMultipleEnumeration
namespace AdventOfCodeConsole.Puzzles._2021
{
    public class Day12 : IDay
    {
        public static int DayNumber => 12;

        private Dictionary<string, List<string>> _graph = new();

        private void AddAdjacency(string start, string end)
        {
            if (!_graph.ContainsKey(start))
                _graph.Add(start, new List<string> { end });
            else
                _graph[start].Add(end);

            if (start == "start")
                return;
            if (!_graph.ContainsKey(end))
                _graph.Add(end, new List<string> { start });
            else
                _graph[end].Add(start);
        }

        public ulong Part1(string input)
        {
            IEnumerable<List<string>> Traverse(
                Dictionary<string, List<string>> graph,
                string current,
                string end,
                IEnumerable<string>? path = null)
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

            var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var edgeSplit = line.Split('-');
                AddAdjacency(edgeSplit[0], edgeSplit[1]);
            }

            var result = Traverse(_graph, "start", "end");

            return (ulong)result.Count();
        }

        public ulong Part2(string input)
        {
            IEnumerable<List<string>> Traverse(
                Dictionary<string, List<string>> graph,
                string current,
                string end,
                IEnumerable<string>? path = null)
            {
                path ??= new List<string>();

                if (current is "start" or "end" && path.Contains(current))
                    yield break;

                if (char.IsLower(current[0]) && path.Contains(current))
                {
                    var hasDup = path.Where(c => char.IsLower(c[0])).GroupBy(n => n).Any(c => c.Count() > 1);
                    if (hasDup)
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

            _graph.Clear();
            var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var edgeSplit = line.Split('-');
                AddAdjacency(edgeSplit[0], edgeSplit[1]);
            }

            var result = Traverse(_graph, "start", "end");

            return (ulong)result.Count();
        }
    }
}
