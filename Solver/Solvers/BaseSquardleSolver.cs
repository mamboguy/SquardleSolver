using ClassLibrary.DictionaryTrees;
using System.Text;

namespace ClassLibrary.Solvers;

internal abstract class BaseSquardleSolver : ISquardleSolver
{        
    protected string RawValues { get; set; }
    protected GridCell[,] Grid { get; set; }
    private ISquardleDictionary Dictionary { get; set; }
    private List<string> Words { get; set; } = new();

    protected BaseSquardleSolver(string? values, ISquardleDictionary dictionary)
    {
        RawValues = values ?? string.Empty;
        Dictionary = dictionary;

        GenerateGrid();

        ConnectGrid();
    }
    
    protected virtual void ConnectGrid()
    {
        var gridSize = GetGridSize();

        for (int i = 0; i < gridSize; i++)
        {
            // Check what type of node we are currently sitting on so that it can be hooked up properly
            bool hasAbove = i != 0;
            bool hasBelow = i != gridSize - 1;

            for (int j = 0; j < gridSize; j++)
            {
                bool hasLeft = j != 0;
                bool hasRight = j != gridSize - 1;

                CreateConnections(i, j, hasAbove, hasBelow, hasLeft, hasRight);
            }
        }
    }

    private void CreateConnections(int row, int col, bool hasAbove, bool hasBelow, bool hasLeft, bool hasRight)
    {
        CreateRowConnection(hasAbove, hasLeft, hasRight, row, col, -1); // Row above
        CreateRowConnection(true, hasLeft, hasRight, row, col, 0); // Current row
        CreateRowConnection(hasBelow, hasLeft, hasRight, row, col, 1); // Row below
    }

    private void CreateRowConnection(bool rowExists, bool hasLeft, bool hasRight, int row, int col, int rowAddition)
    {
        if (rowExists)
        {
            if (hasLeft)
            {
                Grid[row, col].AddNeighbor(Grid[row + rowAddition, col - 1]);
            }

            if (rowAddition != 0) // Don't connect a cell to itself
            {
                Grid[row, col].AddNeighbor(Grid[row + rowAddition, col]);
            }

            if (hasRight)
            {
                Grid[row, col].AddNeighbor(Grid[row + rowAddition, col + 1]);
            }
        }
    }

    protected virtual void GenerateGrid()
    {
        var gridSize = GetGridSize();

        Grid = new GridCell[gridSize, gridSize];

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                Grid[i, j] = new GridCell(RawValues[(i * gridSize) + j]);
            }
        }
    }

    public override string ToString()
    {
        var gridSize = GetGridSize();
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine("Raw value = " + RawValues);
        stringBuilder.AppendLine();
        stringBuilder.AppendLine("Grid = ");

        for (int i = 0; i < gridSize; i++)
        {
            var value = string.Empty;

            for (int j = 0; j < gridSize; j++)
            {
                value += $"{Grid[i, j].Value}, ";
            }

            stringBuilder.AppendLine(value[..^2]);
        }

        stringBuilder.AppendLine();

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                var connections = Grid[i, j].Neighbors;
                var value = string.Empty;

                foreach (var conn in connections)
                {
                    value += $"{conn.Value}, ";
                }

                stringBuilder.AppendLine($"Cell {Grid[i, j].Value} has connections to: {value[..^2]}");       
                
            }
        }

        return stringBuilder.ToString();
    }

    public virtual IEnumerable<string> Solve()
    {
        foreach (var gridNode in Grid)
        {
            TrawlRecursively(gridNode, gridNode.Value.ToString());

            gridNode.Reset();
        }

        return Words;
    }

    private void TrawlRecursively(GridCell gridNode, string currentSequence)
    {
        // Prevent the current node from being revisited
        gridNode.SetVisited();

        // If the current sequence is a word (and hasn't already been found), then add it to the word list
        if (Dictionary.IsWord(currentSequence) && !Words.Contains(currentSequence))
        {
            Words.Add(currentSequence);
        }

        // End case
        // If the sequence isn't valid, no reason to continue this branch
        if (!Dictionary.IsValidSequence(currentSequence))
        {
            return;
        }

        // Create a new branch for each neighbor that hasn't been visited
        foreach (var neighbor in gridNode.Neighbors)
        {
            if (!neighbor.HasVisited)
            {
                var newSequence = currentSequence + neighbor.Value;

                TrawlRecursively(neighbor, newSequence);

                // If a node has been returned from, reset its visited value to prevent improper pruning
                neighbor.Reset();
            }
        }
    }

    protected abstract int GetGridSize();
}