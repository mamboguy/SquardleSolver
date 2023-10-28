namespace ClassLibrary;

internal class GridCell
{
    public List<GridCell> Neighbors { get; private set; } = new();
    public bool HasVisited { get; private set; }
    public char Value { get; init; }

    public GridCell(char value)
    {
        Value = value;
    }

    public void AddNeighbor(GridCell cell)
    {
        Neighbors.Add(cell);
    }

    public void SetVisited()
    {
        HasVisited = true;
    }

    public void Reset()
    {
        HasVisited = false;
    }

    public override string ToString()
    {
        return $"Cell value = {Value}";
    }
}