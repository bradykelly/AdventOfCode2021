using AdventOfCode.Graphs.AStar;

namespace AdventOfCode.Graphs;

public partial record Node: IHasNeighbours<Node>
{
    public IEnumerable<Node> Neighbours
    {
        get
        {
            List<Node> nodes = new List<Node>();

            foreach (EdgeToNeighbor<Node> etn in Neighbors!)
            {
                nodes.Add(etn.Neighbor);
            }

            return nodes;
        }
    }
}