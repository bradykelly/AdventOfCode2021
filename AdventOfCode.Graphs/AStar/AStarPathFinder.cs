namespace AdventOfCode.Graphs.AStar;

public static class AStarPathFinder
{
    public static Path<TNode>? FindPath<TNode>(
        TNode start,
        TNode destination,
        Func<TNode, TNode, double> distance,
        Func<TNode, double> estimate) where TNode : IHasNeighbours<TNode>
    {
        var closed = new HashSet<TNode>();

        var queue = new PriorityQueue<Path<TNode>, double>();

        queue.Enqueue(new Path<TNode>(start), 0);

        while (queue.Count != 0)
        {
            var path = queue.Dequeue();

            if (closed.Contains(path.LastStep))
                continue;

            if (path.LastStep.Equals(destination))
                return path;

            closed.Add(path.LastStep);

            foreach (TNode n in path.LastStep.Neighbours)
            {
                double d = distance(path.LastStep, n);

                var newPath = path.AddStep(n, d);

                queue.Enqueue(newPath, newPath.TotalCost + estimate(n));
            }
        }

        return null;
    }
}
