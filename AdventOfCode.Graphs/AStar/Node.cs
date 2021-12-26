using AdventOfCode.Graphs.AStar;

// ReSharper disable once CheckNamespace
namespace AdventOfCode.Graphs;

public partial record Node : IHasNeighbours<Node>
{
    public IEnumerable<Node> Neighbours => (from EdgeToNeighbour<Node> etn in Adjacencies! select etn.Neighbor).ToList();
}