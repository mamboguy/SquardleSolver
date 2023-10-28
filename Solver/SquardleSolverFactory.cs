using ClassLibrary.DictionaryTrees;
using ClassLibrary.Solvers;

namespace ClassLibrary;

public class SquardleSolverFactory
{
    // Returns an instance of a solver for the squardle (some of the special puzzles aren't build as grids)
    public ISquardleSolver? Create(string? value, ISquardleDictionary dictionary)
    {
        if (value is null)
        {
            return null;
        }

        if (value.Length == 16)
        {
            return new StandardSolver(value, dictionary);
        }
        else if (value.Length == 9)
        {
            return new ExpressSolver(value, dictionary);
        }

        return null;
    }
}
