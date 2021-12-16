namespace AdventOfCodeConsole.Tools;

public struct Node
{
    public string Name { get; set; }

    public Node(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }

    //public bool Equals(Node other)
    //{
    //    if (this.Name is null || other.Name is null) return false;
    //    return Name == other.Name;
    //}

    //public override int GetHashCode()
    //{
    //    return Name is null ? 0 : Name.GetHashCode();
    //}
}