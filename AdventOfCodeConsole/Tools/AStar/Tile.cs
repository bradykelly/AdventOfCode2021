namespace AdventOfCodeConsole.Tools.AStar;

public record Tile : Point
{
    public char Content { get; set; }
    public ulong Cost { get; set; }
    public ulong Distance { get; set; }
    public ulong CostDistance => Cost + Distance;
    public Tile? Parent { get; set; }

    public Tile() { }

    public Tile(long y, long x): base(y, x) { }

    public Tile(long y, long x, char value) : base(y, x)
    {
        Content = value;
        Cost = (ulong)(value - '0');
    }

    //The distance is essentially the estimated distance, ignoring walls to our target. 
    //So how many tiles left and right, up and down, ignoring walls, to get there. 
    public void SetDistance(long targetX, long targetY)
    {
        this.Distance = (ulong)(Math.Abs((decimal)(targetX - X)) + Math.Abs((decimal)(targetY - Y)));
    }
}
