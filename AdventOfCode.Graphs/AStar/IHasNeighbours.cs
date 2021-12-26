namespace AdventOfCode.Graphs.AStar;

public interface IHasNeighbours<Tnode>
{
    IEnumerable<Tnode> Neighbours { get; }
}