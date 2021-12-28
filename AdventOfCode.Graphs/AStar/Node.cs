using AdventOfCode.Graphs.AStar;

// ReSharper disable once CheckNamespace
namespace AdventOfCode.Graphs;

public partial record Node : IHasNeighbours<Node>
{
    public IEnumerable<Node> Neighbours => EdgesOut!
        .Cast<EdgeToNeighbour<Node>>()
        .Select(etn => etn.Neighbor).ToList();
}