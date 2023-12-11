namespace ClassLibrary;

public class GridCell
{
    public List<GridCell> Neighbors { get; private set; } = new();
    public bool HasVisited { get; private set; }

    // The character of the current grid cell
    public char Value { get; init; }

    public GridCell(char value)
    {
        Value = value;
    }

    public void AddNeighbor(GridCell cell)
    {
        // Cells with a space as their value shouldn't be mapped to since its a "blank" in the board
        if (cell.Value == ' ')
        {
            return;
        }

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